using UnityEngine;

namespace Unity.XRTools.ModuleLoader.Example
{
    class UsesLogging : MonoBehaviour, IUsesLogging
    {
        public IProvidesLogging provider { get; set; }

        void Start()
        {
            this.Log("Logging Subscriber Start");
        }
    }
}
