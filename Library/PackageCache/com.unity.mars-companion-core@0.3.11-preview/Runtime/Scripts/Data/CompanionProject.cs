using System;
using System.IO;
using Unity.ListViewFramework;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class CompanionProject : IListViewItemData<string>
    {
        const string k_Template = "ProjectTile";

        [SerializeField]
        string m_ProjectID;

        [SerializeField]
        string m_Name;

        [SerializeField]
        bool m_Linked;

        public string index { get { return m_ProjectID; } }
        public string name { get { return m_Name; } set { m_Name = value; } }
        public string template { get { return k_Template; } }
        public bool linked { get { return m_Linked; } set { m_Linked = value; } }
        public bool selected { get; set; }
        internal string projectId { set => m_ProjectID = value; }

        public CompanionProject() { }

        public CompanionProject(string projectID, string name, bool linked)
        {
            m_ProjectID = projectID;
            m_Name = name;
            m_Linked = linked;
        }

        public void Link(string id, string newName)
        {
            m_ProjectID = id;
            m_Name = newName;
            m_Linked = true;
        }

        public void Unlink(string id)
        {
            m_ProjectID = id;
            m_Linked = false;
        }

        internal static string GetProjectPath(string projectId)
        {
            var root = Application.persistentDataPath;
            return Path.Combine(root, projectId);
        }

        public string GetLocalPath() { return GetProjectPath(m_ProjectID); }
    }
}
