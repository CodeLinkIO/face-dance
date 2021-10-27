using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Used to track the objects using the Simulation Scene across Assembly and Module loading.
    /// This is used since the Simulation Scene Module can be reloaded outside of normal times when object would try
    /// and start or stop using the Simulation Scene.
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public class SimulationSceneUsers : ScriptableObject
    {
        static SimulationSceneUsers s_Instance;

        [SerializeField]
        HashSet<ScriptableObject> m_UsingSimulation = new HashSet<ScriptableObject>();

        /// <summary>
        /// Active instance of the <c>SimulationSceneUsers</c>
        /// </summary>
        public static SimulationSceneUsers instance
        {
            get
            {
                if (!s_Instance)
                {
                    var simulationSceneUsers = Resources.FindObjectsOfTypeAll<SimulationSceneUsers>();
                    if (simulationSceneUsers.Length > 0)
                        s_Instance = simulationSceneUsers[0];
                }

                return s_Instance;
            }
        }

        /// <summary>
        /// Create the <c>SimulationSceneUsers</c> instance
        /// </summary>
        /// <returns>The created instance</returns>
        public static SimulationSceneUsers CreateSimulationSceneSubscribers()
        {
            if (!instance)
                s_Instance = CreateInstance<SimulationSceneUsers>();

            s_Instance.hideFlags = HideFlags.DontSave;

            return s_Instance;
        }

        /// <summary>
        /// Add the object as a using the Simulation Scene
        /// </summary>
        /// <param name="usingModule">The object using the sim Scene</param>
        public void AddSimulationUser(ScriptableObject usingModule) { m_UsingSimulation.Add(usingModule); }

        /// <summary>
        /// Removes the object from using the Simulation Scene
        /// </summary>
        /// <param name="usingModule">The object no longer using the sim Scene</param>
        public void RemoveSimulationUser(ScriptableObject usingModule) { m_UsingSimulation.Remove(usingModule); }

        /// <summary>
        /// Checks if the object is using the Simulation Scene
        /// </summary>
        /// <param name="usingModule">The object to check</param>
        /// <returns>Whether the object is using the Simulation Scene</returns>
        public bool ContainsSimulationUser(ScriptableObject usingModule) { return m_UsingSimulation.Contains(usingModule); }

        /// <summary>
        /// The current number of objects using the Simulation Scene.
        /// </summary>
        public int simulationSceneUserCount { get { return m_UsingSimulation.Count; } }

        void OnEnable()
        {
            if (instance != this)
                Debug.LogWarning(string.Format("Leaked SimulationSceneUsers {0}", GetInstanceID()));
        }

        void OnDestroy()
        {
            m_UsingSimulation.Clear();
            if (s_Instance)
                s_Instance = null;
        }
    }
}
