using System;
using System.Collections.Generic;
using System.Text;
using Unity.RuntimeSceneSerialization;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class ProjectList : IFormatVersion
    {
        const int k_FormatVersion = 1;

        [SerializeField]
        int m_FormatVersion = k_FormatVersion;

        [SerializeField]
        List<CompanionProject> m_Projects = new List<CompanionProject>();

        public List<CompanionProject> projects { get { return m_Projects; } }

        public void AddProject(string id, string name, bool linked)
        {
            m_Projects.Add(new CompanionProject(id, name, linked));
        }

        public void RemoveProject(string id) { m_Projects.RemoveAll(project => project.index == id); }

        public string GetListAsString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Projects ({m_Projects.Count}):\n");
            var count = 0;
            foreach (var project in m_Projects)
            {
                if (count++ > 0)
                    stringBuilder.Append("\n");

                stringBuilder.Append(project.name);
            }

            return stringBuilder.ToString();
        }

        public void CheckFormatVersion()
        {
            if (m_FormatVersion != k_FormatVersion)
                throw new FormatException($"Serialization format mismatch. Expected {k_FormatVersion} but was {m_FormatVersion}.");
        }
    }
}
