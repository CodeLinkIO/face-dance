using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    class TraitPresenceFilterStageTests
    {
        MARSDatabase m_Database;

        [OneTimeSetUp]
        public void Setup()
        {
            MARSSession.TestMode = true;
            m_Database = new MARSDatabase();
            var dbModule = (IModule)m_Database;
            dbModule.LoadModule();
        }

        [SetUp]
        public void SetupBeforeEach()
        {
            // Ensure a consistent random seed for all test runs
            Random.InitState(0);
        }



        [OneTimeTearDown]
        public void TearDown()
        {
            MARSSession.TestMode = false;
            var dbModule = (IModule)m_Database;
            dbModule.UnloadModule();
        }

        [Test]
        public void BasicFilterTest()
        {
            m_Database.GetTraitProvider(out MARSTraitDataProvider<bool> tagTraits);
            // if we get a null provider, code generation hasn't run yet
            if (tagTraits == null)
                return;

            m_Database.GetTraitProvider(out MARSTraitDataProvider<Vector2> vector2Traits);
            m_Database.GetTraitProvider(out MARSTraitDataProvider<float> floatTraits);
            m_Database.GetTraitProvider(out MARSTraitDataProvider<int> intTraits);
            const string presentTrait = "present";
            // add a trait by this name to every type we support, so we can be sure it works for all of them
            for (var i = 0; i < 5; i++)
            {
                intTraits.AddOrUpdateTrait(i, presentTrait, Random.Range(0, 10));
                floatTraits.AddOrUpdateTrait(i, presentTrait, Random.Range(0f, 10f));
                tagTraits.AddOrUpdateTrait(i, presentTrait, true);
                vector2Traits.AddOrUpdateTrait(i, presentTrait, new Vector2());
            }

            var indices = new List<int> { 0, 1, 2, 3};
            var setToFilter = new HashSet<int> {3, 4, 5, 6, 7};
            var preFilterCount = setToFilter.Count;
            var matchSets = new []
            {
                // we re-use this same filter set for every instance, because the only difference is type
                setToFilter, setToFilter, setToFilter, setToFilter
            };
            var requirements = new []
            {
                RequirementsForType<int>(presentTrait),  RequirementsForType<float>(presentTrait),
                RequirementsForType<bool>(presentTrait), RequirementsForType<Vector2>(presentTrait)
            };

            TraitRequirementFilterTransform.ProcessStage(indices, m_Database.TypeToFilterAction, requirements, ref matchSets);

            // we expect ids > 4 to be filtered from each set, because only IDs 0-4 have the trait.
            var expectedCountAfterFilter = preFilterCount - 3;
            foreach (var set in matchSets)
            {
                Assert.AreEqual(expectedCountAfterFilter, set.Count);
                Assert.True(set.Contains(3));
                Assert.True(set.Contains(4));
            }
        }

        [Test]
        public void MissingTraitTest()
        {
            const string missingTrait = "missing";

            var indices = new List<int> {0, 1, 2, 3, 4, 5};
            var setToFilter = new HashSet<int> {3, 4, 5, 6, 7};
            var matchSets = new []
            {
                // we re-use this same filter set for every instance, because the only difference is type
                setToFilter, setToFilter, setToFilter, setToFilter, setToFilter, setToFilter
            };
            var requirements = new []
            {
                RequirementsForType<int>(missingTrait),  RequirementsForType<float>(missingTrait),
                RequirementsForType<bool>(missingTrait), RequirementsForType<Vector2>(missingTrait),
                RequirementsForType<Vector3>(missingTrait), RequirementsForType<Pose>(missingTrait),
            };

            TraitRequirementFilterTransform.ProcessStage(indices, m_Database.TypeToFilterAction, requirements, ref matchSets);

            // we expect all IDs to be filtered from each set, because the trait does not exist in the DB
            foreach (var set in matchSets)
            {
                Assert.AreEqual(0, set.Count);
            }
        }

        static ProxyTraitRequirements RequirementsForType<T>(string trait)
        {
            var requirement = new TraitRequirement(trait, typeof(T));
            return new ProxyTraitRequirements(new List<TraitRequirement> {requirement});
        }
    }
}
