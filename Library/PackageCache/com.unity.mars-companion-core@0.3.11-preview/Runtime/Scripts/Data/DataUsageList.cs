using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class DataUsageList : ISerializationCallbackReceiver
    {
#pragma warning disable 649
        // ReSharper disable InconsistentNaming
        [SerializeField]
        List<DataUsageOrganization> organizations;

        [SerializeField]
        string[] errors;
        // ReSharper restore InconsistentNaming
#pragma warning restore 649

        public List<DataUsageOrganization> Organizations => organizations;
        public string[] Errors => errors;

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            var count = 0;
            foreach (var organization in organizations)
            {
                organization.index = count++;
                organization.Projects.Sort((a, b) => b.StorageUsage.CompareTo(a.StorageUsage));
            }
        }
    }
}
