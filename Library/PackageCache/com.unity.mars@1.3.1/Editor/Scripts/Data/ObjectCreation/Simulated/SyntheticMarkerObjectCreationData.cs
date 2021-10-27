using Unity.MARS;
using UnityEditor;
using Unity.XRTools.Utils;
using Unity.MARS.Data;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace UnityEditor.MARS
{
    class SyntheticMarkerObjectCreationData : ObjectCreationData
    {
        const string k_SimulatedMarkersParentName = "Simulated Markers";

#pragma warning disable 649
        [SerializeField]
        Material m_SyntheticMarkersMaterial;

        [SerializeField]
        Mesh m_SyntheticMarkersMesh;
#pragma warning restore 649

        public override bool CreateGameObject(out GameObject createdObj, Transform parentTransform = null)
        {
            MARSSession.EnsureRuntimeState();

            createdObj = null;

            SimulationView activeView =  SimulationView.ActiveSimulationView as SimulationView;
            if(activeView != null)
                activeView.EnvironmentSceneActive = true;

            Tools.current = Tool.Move;

            GameObject markerGO;

            using (var undoBlock = new UndoBlock("Synthetic Marker Creation"))
            {
                var imageMarkerParent = GetOrGenerateUniqueParent(k_SimulatedMarkersParentName);
                if (imageMarkerParent == null)
                {
                    Debug.LogWarning("Unable to create synthetic marker.");
                    return false;
                }

                var syntheticMarker = CreateSyntheticMarker();
                var markerTransform = syntheticMarker.transform;
                markerTransform.parent = imageMarkerParent;

                // Zero out position and rotation, leave scale in case the user is working with other scale.
                markerTransform.localPosition = Vector3.zero;
                markerTransform.localRotation = Quaternion.identity;

                markerTransform.name = GameObjectUtility.GetUniqueNameForSibling(imageMarkerParent, m_ObjectName);

                markerGO = markerTransform.gameObject;
                undoBlock.RegisterCreatedObject(markerGO);

                Selection.activeTransform = markerTransform;

                var initialScale = Vector2.one * MarsWorldScaleModule.GetWorldScale();
                syntheticMarker.UpdateMarkerSize(initialScale);

                markerTransform.localScale = new Vector3(1, 0.01f, 1);
                createdObj = markerTransform.gameObject;
            }

            return true;
        }

        SynthesizedMarkerId CreateSyntheticMarker()
        {
            var synthesizedImageMarkerObj = new GameObject("Simulated marker");
            synthesizedImageMarkerObj.layer = SimulationConstants.SimulatedEnvironmentLayerIndex;

            synthesizedImageMarkerObj.SetActive(false);

            // Rest of components added by RequireComponent inside SynthesizedMarker
            synthesizedImageMarkerObj.AddComponent<SynthesizedMarker>();

            synthesizedImageMarkerObj.AddComponent<SimulatedObject>();
            synthesizedImageMarkerObj.AddComponent<MeshRenderer>();
            synthesizedImageMarkerObj.AddComponent<MeshFilter>().sharedMesh = m_SyntheticMarkersMesh;
            synthesizedImageMarkerObj.AddComponent<MeshCollider>();

            var synthesizedMarkerId = synthesizedImageMarkerObj.GetComponent<SynthesizedMarkerId>();
            synthesizedMarkerId.Initialize(m_SyntheticMarkersMaterial);

            synthesizedImageMarkerObj.SetActive(true);

            // Without delay, the non-instant framing gets lost in the object creation hiccup.
            EditorApplication.delayCall += () =>
            {
                SimulationView.ActiveSimulationView.Frame(
                    BoundsUtils.GetBounds(synthesizedImageMarkerObj.transform), false);
            };

            return synthesizedMarkerId;
        }
    }
}
