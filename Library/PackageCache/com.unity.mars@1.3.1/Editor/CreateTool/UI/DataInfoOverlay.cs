using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace UnityEditor.MARS
{
    /// <summary>
    /// UI for overlay box in simulation view
    /// </summary>
    class DataInfoOverlay : VisualElement
    {
        const string k_UxmlPath = MarsUIResources.EditorFolderPath + "CreateTool/UI/DataInfoOverlay.uxml";

        public new class UxmlFactory : UxmlFactory<DataInfoOverlay> { }

        TraitDataSnapshot m_HoverDataSnapshot = new TraitDataSnapshot();

        Label MainLabel { get; set; }
        Label TagsLabel { get; set; }
        Label TraitsLabel { get; set; }

        List<string> m_TraitNames = new List<string>();

        public DataInfoOverlay()
        {
            SetupFromTemplate();
            DisablePickingRecursively(this);
        }

        void SetupFromTemplate()
        {
            var template = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(k_UxmlPath);
            template.CloneTree(this);
            this.StretchToParentSize();
            MainLabel = this.Q<Label>("Header");
            TagsLabel = this.Q<Label>("Tags");
            TraitsLabel = this.Q<Label>("Traits");
        }

        static void DisablePickingRecursively(VisualElement element)
        {
            element.pickingMode = PickingMode.Ignore;
            foreach (var child in element.Children())
            {
                DisablePickingRecursively(child);
            }
        }

        public void UpdateInfo(QueryResult proxyData)
        {
            MainLabel.text = "MARS Data #" + proxyData.DataID;

            // Separate bool traits as "Tags" and group other types as "Traits"
            var tagsString = "";
            var traitsString = "";

            m_HoverDataSnapshot.TakeSnapshot(proxyData);
            m_TraitNames.Clear();
            m_HoverDataSnapshot.GetAllTraitNames(m_TraitNames);

            m_HoverDataSnapshot.GetTraits(out Dictionary<string, bool> traitDataTagData);
            foreach (var boolTrait in traitDataTagData)
            {
                tagsString += boolTrait.Key + ", ";
                m_TraitNames.Remove(boolTrait.Key);
            }

            foreach (var traitName in m_TraitNames)
                traitsString += traitName + ", ";

            if (tagsString.Length > 1)
                tagsString = tagsString.Remove(tagsString.Length - 2);

            if (traitsString.Length > 1)
                traitsString = traitsString.Remove(traitsString.Length - 2);

            TagsLabel.text = tagsString;
            TraitsLabel.text = traitsString;
        }
    }
}

