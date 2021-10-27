#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Unity.XRTools.Utils
{
    [InitializeOnLoad]
    static class TagManager
    {
        const int k_MaxLayer = 31;
        const int k_MinLayer = 8;

        static TagManager()
        {
            HashSet<string> requiredTags;
            HashSet<string> requiredLayers;
            GetRequiredTagsAndLayers(out requiredTags, out requiredLayers);
            AddTags(requiredTags);
            AddLayers(requiredLayers);
        }

        /// <summary>
        /// Add a tag to the tag manager if it doesn't already exist
        /// </summary>
        /// <param name="tagList">List of tags to add</param>
        public static void AddTags(HashSet<string> tagList)
        {
            SerializedObject so;
            var tagsProperty = GetTagManagerProperty("tags", out so);
            if (tagsProperty != null)
            {
                foreach (var tag in tagList)
                {
                    var found = false;
                    for (var i = 0; i < tagsProperty.arraySize; i++)
                    {
                        if (tagsProperty.GetArrayElementAtIndex(i).stringValue == tag)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        var arraySize = tagsProperty.arraySize;
                        tagsProperty.InsertArrayElementAtIndex(arraySize);
                        tagsProperty.GetArrayElementAtIndex(arraySize).stringValue = tag;
                    }
                }

                so.ApplyModifiedProperties();
                so.Update();
            }
        }

        /// <summary>
        /// Add a layer to the tag manager if it doesn't already exist
        /// Start at layer 31 (max) and work down
        /// </summary>
        /// <param name="layerNames">List of layer names to add</param>
        static void AddLayers(HashSet<string> layerNames)
        {
            SerializedObject so;
            var layers = GetTagManagerProperty("layers", out so);
            if (layers != null)
            {
                foreach (var layerName in layerNames)
                {
                    var found = false;
                    for (var i = 0; i < layers.arraySize; i++)
                    {
                        if (layers.GetArrayElementAtIndex(i).stringValue == layerName)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        var added = false;
                        for (var i = k_MaxLayer; i >= k_MinLayer; i--)
                        {
                            var layer = layers.GetArrayElementAtIndex(i);
                            if (!string.IsNullOrEmpty(layer.stringValue))
                                continue;

                            layer.stringValue = layerName;
                            added = true;
                            break;
                        }

                        if (!added)
                            Debug.LogWarningFormat("Could not add layer {0} because there are no free layers", layerName);
                    }
                }

                so.ApplyModifiedProperties();
                so.Update();
            }
        }

        internal static SerializedProperty GetTagManagerProperty(string name, out SerializedObject so)
        {
            var asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
            if (asset != null && asset.Length > 0)
            {
                so = new SerializedObject(asset[0]);
                return so.FindProperty(name);
            }

            so = null;
            return null;
        }

        internal static void GetRequiredTagsAndLayers(out HashSet<string> requiredTags, out HashSet<string> requiredLayers)
        {
            var tags = new HashSet<string>();
            var layers = new HashSet<string>();
#if UNITY_2019_2_OR_NEWER
            var typeCollection = TypeCache.GetTypesWithAttribute<RequiresLayerAttribute>();
            foreach (var type in typeCollection)
            {
                var attributes = type.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    var layerAttribute = attribute as RequiresLayerAttribute;
                    if (layerAttribute != null)
                        layers.Add(layerAttribute.layer);
                }
            }

            typeCollection = TypeCache.GetTypesWithAttribute<RequiresTagAttribute>();
            foreach (var type in typeCollection)
            {
                var attributes = type.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    var tagAttribute = attribute as RequiresTagAttribute;
                    if (tagAttribute != null)
                        tags.Add(tagAttribute.tag);
                }
            }
#else
            ReflectionUtils.ForEachType(t =>
            {
                var attributes = t.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    var tagAttribute = attribute as RequiresTagAttribute;
                    if (tagAttribute != null)
                        tags.Add(tagAttribute.tag);

                    var layerAttribute = attribute as RequiresLayerAttribute;
                    if (layerAttribute != null)
                        layers.Add(layerAttribute.layer);
                }
            });
#endif

            requiredTags = tags;
            requiredLayers = layers;
        }
    }
}
#endif
