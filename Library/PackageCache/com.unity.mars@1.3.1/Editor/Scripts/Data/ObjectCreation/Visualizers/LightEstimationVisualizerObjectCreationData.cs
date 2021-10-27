using Unity.MARS;
using Unity.MARS.Behaviors;
using Unity.MARS.Visualizers;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace UnityEditor.MARS
{
    class LightEstimationVisualizerObjectCreationData : ObjectCreationData
    {
        public override bool CreateGameObject(out GameObject createdObj, Transform parentTransform)
        {
            //Early out if we already have a MARSLightEstimationVisualizer
            var lightEstimationVisualizer = GameObject.FindObjectOfType<MARSLightEstimationVisualizer>();
            if (lightEstimationVisualizer)
            {
                createdObj = null;
                Selection.activeObject = lightEstimationVisualizer.gameObject;
                return false;
            }

            MARSSession.EnsureRuntimeState();

            Light existingDirectionalLight = null;

            Light[] existingLights = GameObject.FindObjectsOfType<Light>();
            for (int i = 0; i < existingLights.Length; i++)
            {
                if (existingLights[i].type == LightType.Directional)
                {
                    existingDirectionalLight = existingLights[i];
                    break;
                }
            }

            if (existingDirectionalLight != null)
            {
                createdObj = existingDirectionalLight.gameObject;
                var lightEstimate = Undo.AddComponent<MARSLightEstimationVisualizer>(createdObj);
                lightEstimate.Light = existingDirectionalLight;
            }
            else
            {
                //no light exists, lets create one and add the component
                createdObj = GenerateInitialGameObject(m_ObjectName, parentTransform);
                createdObj.AddComponent<Light>().type = LightType.Directional;
                createdObj.AddComponent<MARSLightEstimationVisualizer>();
                Undo.RegisterCreatedObjectUndo(createdObj, $"Create {createdObj.name}");
            }

            Selection.activeObject = createdObj;

            var simObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            simObjectsManager?.DirtySimulatableScene();

            return true;
        }
    }
}
