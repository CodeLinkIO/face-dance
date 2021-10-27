using System;
using System.Collections.Generic;
using Unity.ListViewFramework;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class DataUsageOrganization : IListViewItemData<int>
    {
        const string k_Template = "DataUsageListOrganization";

#pragma warning disable 649
        // ReSharper disable InconsistentNaming
        [SerializeField]
        string name;

        [SerializeField]
        long storageCap;

        [SerializeField]
        long sizeBytesTotal;

        [SerializeField]
        List<DataUsageProject> projects;
        // ReSharper restore InconsistentNaming
#pragma warning restore 649

        public int index { get; set; }
        public bool selected => false;
        public string template => k_Template;
        public string Name => name;
        public long StorageCap => storageCap;
        public long SizeBytesTotal => sizeBytesTotal;
        public List<DataUsageProject> Projects => projects;
        public bool expanded { get; set; }
    }
}
