using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Reasoning
{
    [MovedFrom("Unity.MARS")]
    public class ReasoningDefaultsModule : ScriptableSettings<ReasoningDefaultsModule>
    {
        [SerializeField]
        [Tooltip("All objects that interact with the Data API.")]
        List<ScriptableObject> m_ReasoningDefaultApis = new List<ScriptableObject>();

        public List<ScriptableObject> DefaultReasoningApis => m_ReasoningDefaultApis;
    }
}
