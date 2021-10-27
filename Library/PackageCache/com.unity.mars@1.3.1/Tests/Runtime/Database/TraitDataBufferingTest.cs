#if UNITY_EDITOR
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    /// <summary>Runtime / integration test for the buffering of trait data changes</summary>
    [AddComponentMenu("")]
    class TraitDataBufferingTest : RuntimeQueryTest, IUsesQueryResults,
        IProvidesTraits<Vector2>, IRequiresTraits<Vector2>, IProvidesTraits<bool>, IRequiresTraits<bool>
    {
        const int k_DataId = 100;
        static readonly Vector2 k_BoundsIncrement = new Vector2(0.001f, 0.001f);
        static readonly TraitRequirement[] k_RequiredTraits = new TraitRequirement[0];

        QueryPipelinesModule m_PipelinesModule;
        QueryPipelinesModule.AcquireCycleState m_PreviousState;

        Vector2 m_BoundsValue = Vector2.zero;
        Vector2 m_LastBufferedUpdateBoundsValue = Vector2.zero;

        public void Start()
        {
            m_FrameCount = 60;
            m_PipelinesModule = ModuleLoaderCore.instance.GetModule<QueryPipelinesModule>();
            this.SetEvaluationMode(MarsSceneEvaluationMode.WaitForRequest);
        }

        protected override void OnMarsUpdate()
        {
            var frameCount = MarsTime.FrameCount - m_StartFrame;
            // trigger the query cycle twice during the test
            if (frameCount == 5 || frameCount == 35)
                this.RequestSceneEvaluation();

            switch (m_PipelinesModule.State)
            {
                case QueryPipelinesModule.AcquireCycleState.UpdatesOnly:
                {
                    switch (m_PreviousState)
                    {
                        case QueryPipelinesModule.AcquireCycleState.UpdatesOnly:
                            // add/update the bounds value
                            m_BoundsValue += k_BoundsIncrement;
                            this.AddOrUpdateTrait(k_DataId, TraitNames.Bounds2D, m_BoundsValue);

                            // make sure the add/update is immediately reflected, since we're not buffering
                            Assert.IsTrue(this.TryGetTraitValue(k_DataId, TraitNames.Bounds2D, out Vector2 retrievedBounds));
                            Assert.AreEqual(m_BoundsValue, retrievedBounds);

                            // removing the trait should also be immediately reflected
                            Assert.IsTrue(this.RemoveTrait<Vector2>(k_DataId, TraitNames.Bounds2D));
                            Assert.IsFalse(this.TryGetTraitValue(k_DataId, TraitNames.Bounds2D, out retrievedBounds));
                            break;
                        case QueryPipelinesModule.AcquireCycleState.RunningSets:
                        case QueryPipelinesModule.AcquireCycleState.RunningStandalone:
                            // this case occurs the frame after a query cycle finishes, when buffered changes should be reflected

                            // did the last buffered add/update take effect for Bounds2D ?
                            Assert.IsTrue(this.TryGetTraitValue(k_DataId, TraitNames.Bounds2D, out retrievedBounds));
                            Assert.AreEqual(m_LastBufferedUpdateBoundsValue, retrievedBounds);

                            // did the buffered removal of the 'floor' tag take effect ?
                            Assert.IsFalse(this.TryGetTraitValue(k_DataId, TraitNames.Floor, out bool floorTagValue));
                            break;
                    }

                    // make sure the id is tagged as 'floor' before buffering starts, so we can test buffered removes
                    this.AddOrUpdateTrait(k_DataId, TraitNames.Floor, true);
                    Assert.IsTrue(this.TryGetTraitValue(k_DataId, TraitNames.Floor, out bool retrievedFloorValue));
                    break;
                }
                case QueryPipelinesModule.AcquireCycleState.RunningSets:
                case QueryPipelinesModule.AcquireCycleState.RunningStandalone:
                {
                    // to simplify the amount of changes happening, only try buffered operations once,
                    // on the frame we start the cycle
                    if(m_PreviousState == QueryPipelinesModule.AcquireCycleState.UpdatesOnly)
                    {
                        m_BoundsValue += k_BoundsIncrement;
                        m_LastBufferedUpdateBoundsValue = m_BoundsValue;

                        // try to add/update the 'bounds2d' value - the change should not be immediately reflected
                        var valueExistsPrior = this.TryGetTraitValue(k_DataId, TraitNames.Bounds2D, out Vector2 retrievedBeforeBufferedUpdate);

                        this.AddOrUpdateTrait(k_DataId, TraitNames.Bounds2D, m_LastBufferedUpdateBoundsValue);

                        var valueExistsAfter = this.TryGetTraitValue(k_DataId, TraitNames.Bounds2D, out Vector2 retrievedAfterBufferedUpdate);

                        Assert.AreEqual(valueExistsPrior, valueExistsAfter);
                        Assert.AreEqual(retrievedBeforeBufferedUpdate, retrievedAfterBufferedUpdate);

                        Assert.IsTrue(this.TryGetTraitValue(k_DataId, TraitNames.Floor, out bool floorTagValue));
                        // try to remove the 'floor' tag - should also not be reflected until cycle stops
                        // buffered remove should return true if the trait exists
                        Assert.IsTrue(this.RemoveTrait<bool>(k_DataId, TraitNames.Floor));
                        // and false if it doesn't
                        Assert.IsFalse(this.RemoveTrait<bool>(k_DataId, "doesn't exist"));
                        Assert.IsTrue(this.TryGetTraitValue(k_DataId, TraitNames.Floor, out floorTagValue));
                    }

                    break;
                }
            }

            m_PreviousState = m_PipelinesModule.State;
        }

        public TraitRequirement[] GetRequiredTraits() => k_RequiredTraits;
    }
}
#endif
