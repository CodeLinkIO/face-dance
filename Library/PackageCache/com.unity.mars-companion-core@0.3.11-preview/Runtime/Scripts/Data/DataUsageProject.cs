using System;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class DataUsageProject
    {
#pragma warning disable 649
        // ReSharper disable InconsistentNaming
        [SerializeField]
        string name;

        [SerializeField]
        long storageUsage;
        // ReSharper restore InconsistentNaming
#pragma warning restore 649

        public string Name => name;
        public long StorageUsage => storageUsage;
    }
}
