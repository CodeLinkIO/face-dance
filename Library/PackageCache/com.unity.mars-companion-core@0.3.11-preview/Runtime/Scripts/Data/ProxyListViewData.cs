using System;
using System.Collections.Generic;
using System.Linq;
using Unity.ListViewFramework;
using Unity.MARS.Attributes;
using Unity.MARS.Query;
using Unity.Properties;
using Unity.RuntimeSceneSerialization;
using Unity.RuntimeSceneSerialization.Prefabs;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    class ProxyListViewData : NestedListViewItemData<ProxyListViewData, int>
    {
        class OptionalConstraintPropertyPathGetterVisitor : PropertyVisitor
        {
            public readonly Dictionary<string, string> OptionalConstraintProperties = new Dictionary<string, string>();

            string m_PropertyPath;

            protected override void VisitProperty<TContainer, TValue>(Property<TContainer, TValue> property, ref TContainer container, ref TValue value)
            {
                var previousPropertyPath = m_PropertyPath;

                m_PropertyPath = string.IsNullOrEmpty(m_PropertyPath) ? property.Name : $"{m_PropertyPath}.{property.Name}";

                var name = property.Name;
                if (property.HasAttribute<HideInInspector>())
                    return;

                if (k_IgnoredProperties.Contains(name))
                    return;

                var optionalConstraintAttribute = property.GetAttribute<OptionalConstraintAttribute>();
                if (optionalConstraintAttribute != null)
                    OptionalConstraintProperties[optionalConstraintAttribute.BoolPropertyName] = m_PropertyPath;

                m_PropertyPath = previousPropertyPath;
            }
        }

        class OptionalConstraintPropertyGetterVisitor : PropertyVisitor
        {
            public Dictionary<string, string> OptionalConstraintProperties;
            public readonly Dictionary<string, IProperty> OptionalConstraintBoolProperties = new Dictionary<string, IProperty>();

            string m_PropertyPath;

            protected override void VisitProperty<TContainer, TValue>(Property<TContainer, TValue> property, ref TContainer container, ref TValue value)
            {
                var previousPropertyPath = m_PropertyPath;

                m_PropertyPath = string.IsNullOrEmpty(m_PropertyPath) ? property.Name : $"{m_PropertyPath}.{property.Name}";

                var name = property.Name;
                if (property.HasAttribute<HideInInspector>())
                    return;

                if (k_IgnoredProperties.Contains(name))
                    return;

                if (OptionalConstraintProperties.TryGetValue(m_PropertyPath, out var propertyPath))
                    OptionalConstraintBoolProperties[propertyPath] = property;

                m_PropertyPath = previousPropertyPath;
            }
        }

        class PropertyGetterVisitor : PropertyVisitor
        {
            public ProxyListViewData ParentData;
            public int AutoIncrement;
            public PrefabMetadata PrefabMetadata;
            public string TransformPath;
            public int ComponentIndex;
            public Dictionary<string, string> OptionalConstraintProperties;
            public Dictionary<string, IProperty> OptionalConstraintBoolProperties;

            string m_PropertyPath;

            protected override void VisitProperty<TContainer, TValue>(Property<TContainer, TValue> property, ref TContainer container, ref TValue value)
            {
                var previousPropertyPath = m_PropertyPath;
                m_PropertyPath = string.IsNullOrEmpty(m_PropertyPath) ? property.Name : $"{m_PropertyPath}.{property.Name}";

                var name = property.Name;
                if (property.HasAttribute<HideInInspector>())
                    return;

                if (k_IgnoredProperties.Contains(name))
                    return;

                if (OptionalConstraintProperties.ContainsKey(m_PropertyPath))
                    return;

                var depth = ParentData.m_Depth;
                OptionalConstraintBoolProperties.TryGetValue(m_PropertyPath, out var optionalConstraintProperty);

                var propertyData = PropertyToPropertyData(property, ref container, AutoIncrement++,
                    m_PropertyPath, PrefabMetadata, TransformPath, depth + 1, ComponentIndex, optionalConstraintProperty);

                var children = ParentData.children;
                if (children == null)
                {
                    children = new List<ProxyListViewData>();
                    ParentData.children = children;
                }

                children.Add(propertyData);
                var previousParent = ParentData;
                ParentData = propertyData;
                if (!IsCollapsedProperty(property))
                    base.VisitProperty(property, ref container, ref value);

                ParentData = previousParent;
                m_PropertyPath = previousPropertyPath;
            }

            static bool IsCollapsedProperty<TContainer, TValue>(Property<TContainer, TValue> property)
            {
                var propertyType = typeof(TValue);
                if (propertyType == typeof(Vector2) || propertyType == typeof(Vector3) || propertyType == typeof(Vector4) || propertyType == typeof(Quaternion))
                    return true;
                if (propertyType == typeof(Bounds))
                    return true;
                if (propertyType == typeof(Color) || propertyType == typeof(Color32))
                    return true;
                if (propertyType == typeof(LayerMask))
                    return true;
                if (property is IUnityObjectReferenceValueProperty<TContainer>)
                    return true;

                return false;
            }
        }

        static readonly string[] k_IgnoredProperties =
        {
            "hideFlags",
            "enabled"
        };

        const string k_ActivePropertyPath = "active";
        const string k_NamePropertyPath = "name";
        const string k_ColorPropertyPath = "m_Color";
        const string k_ComponentTemplate = "ProxyListComponentItem";
        const string k_ProxyGameObjectItemTemplate = "ProxyListGameObjectItem";
        const string k_ProxyListVectorItemTemplate = "ProxyListVectorItem";
        const string k_ProxyListStringItemTemplate = "ProxyListStringItem";
        const string k_ProxyListUnimplementedItemTemplate = "ProxyListUnimplementedItem";
        const string k_ProxyListColorItemTemplate = "ProxyListColorItem";
        const string k_ProxyListBoolItem = "ProxyListBoolItem";
        const string k_ProxyListDropdownItemTemplate = "ProxyListDropDownItem";
        const string k_ProxyListNumberItem = "ProxyListNumberItem";
        const string k_ProxyListObjectFieldItemTemplate = "ProxyListObjectFieldItem";
        const string k_ProxyListGenericItemTemplate = "ProxyListGenericItem";
        const HideFlags k_DontSaveFlags = HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor;

        readonly Proxy m_Proxy;
        readonly string m_Template;
        readonly int m_Index;
        readonly int m_Depth;
        protected readonly PrefabMetadata m_PrefabMetadata;
        protected readonly string m_TransformPath;
        protected readonly int m_ComponentIndex;

        public override int index => m_Index;
        public override string template => m_Template;
        public object Container { get; }

        public Proxy Proxy => m_Proxy;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<Component> k_Components = new List<Component>();

        public static ProxyListViewData CreateProxyListViewData(Proxy proxy, ref int autoIncrement, int depth = 0)
        {
            string transformPath = null;
            var gameObject = proxy.gameObject;
            var prefabMetadata = gameObject.GetComponentInParent<PrefabMetadata>();
            if (prefabMetadata != null)
                transformPath = prefabMetadata.transform.GetTransformPath(gameObject.transform);

            var proxyData = new ProxyListViewData(k_ProxyGameObjectItemTemplate, proxy, autoIncrement++, depth, prefabMetadata, transformPath);
            var children = new List<ProxyListViewData>();
            proxyData.children = children;

            if (PropertyContainer.TryGetProperty(ref gameObject, new PropertyPath(k_ActivePropertyPath), out var activeProperty))
            {
                children.Add(PropertyToPropertyData((Property<GameObject, bool>)activeProperty, ref gameObject,
                    autoIncrement++, k_ActivePropertyPath, prefabMetadata, transformPath));
            }

            if (PropertyContainer.TryGetProperty(ref gameObject, new PropertyPath(k_NamePropertyPath), out var nameProperty))
            {
                children.Add(PropertyToPropertyData((Property<GameObject, string>)nameProperty, ref gameObject,
                    autoIncrement++, k_NamePropertyPath, prefabMetadata, transformPath));
            }

#if !NET_DOTS && !ENABLE_IL2CPP
            SceneSerialization.RegisterPropertyBag(typeof(Proxy));
#endif

            if (PropertyContainer.TryGetProperty(ref proxy, new PropertyPath(k_ColorPropertyPath), out var colorProperty))
            {
                children.Add(PropertyToPropertyData((Property<Proxy, Color>)colorProperty, ref proxy, autoIncrement++,
                    k_ColorPropertyPath, prefabMetadata, transformPath));
            }

            var components = gameObject.GetComponents<ICondition>();
            foreach (var condition in components)
            {
                if (condition == null)
                    continue;

                if (!(condition is Component component))
                    continue;

                var componentIndex = GetComponentIndex(component);
                CreateProxyListViewData(component, componentIndex, prefabMetadata, transformPath, children, ref autoIncrement);
            }

            return proxyData;
        }

        static int GetComponentIndex(Component component)
        {
            // k_Components is cleared by GetComponents
            component.gameObject.GetComponents(k_Components);
            var componentIndex = -1;
            var count = 0;
            foreach (var searchComponent in k_Components)
            {
                // Skip PrefabMetadata since it won't be on the final object
                if (searchComponent == null || searchComponent is PrefabMetadata)
                    continue;

                if ((searchComponent.hideFlags & k_DontSaveFlags) != 0)
                    continue;

                if (searchComponent == component)
                {
                    componentIndex = count;
                    break;
                }

                count++;
            }

            return componentIndex;
        }

        static void CreateProxyListViewData(Component component, int componentIndex, PrefabMetadata prefabMetadata,
            string transformPath, List<ProxyListViewData> listViewData, ref int autoIncrement, int depth = 0)
        {
#if !NET_DOTS && !ENABLE_IL2CPP
            SceneSerialization.RegisterPropertyBagRecursively(component.GetType());
#endif

            var componentProperty = new ProxyListViewData(k_ComponentTemplate, component,
                autoIncrement++, depth, prefabMetadata, transformPath, componentIndex);

            listViewData.Add(componentProperty);

            var optionalPropertyPathVisitor = new OptionalConstraintPropertyPathGetterVisitor();
            PropertyContainer.Visit(component, optionalPropertyPathVisitor);

            var optionalPropertyVisitor = new OptionalConstraintPropertyGetterVisitor
            {
                OptionalConstraintProperties = optionalPropertyPathVisitor.OptionalConstraintProperties
            };

            PropertyContainer.Visit(component, optionalPropertyVisitor);

            var visitor = new PropertyGetterVisitor
            {
                ParentData = componentProperty,
                PrefabMetadata = prefabMetadata,
                TransformPath = transformPath,
                ComponentIndex = componentIndex,
                AutoIncrement = autoIncrement,
                OptionalConstraintProperties = optionalPropertyPathVisitor.OptionalConstraintProperties,
                OptionalConstraintBoolProperties = optionalPropertyVisitor.OptionalConstraintBoolProperties
            };

            PropertyContainer.Visit(component, visitor);
            autoIncrement = visitor.AutoIncrement;
        }

        ProxyListViewData(string template, Proxy proxy, int index, int depth, PrefabMetadata prefabMetadata,
            string transformPath, List<ProxyListViewData> children = null)
        {
            m_Template = template;
            m_Proxy = proxy;
            m_Index = index;
            m_Depth = depth;
            m_Children = children;
            m_PrefabMetadata = prefabMetadata;
            m_TransformPath = transformPath;
            m_ComponentIndex = -1;
        }

        protected ProxyListViewData(string template, object container, int index, int depth, PrefabMetadata prefabMetadata,
            string transformPath, int componentIndex, List<ProxyListViewData> children = null)
        {
            m_Template = template;
            Container = container;
            m_Index = index;
            m_Depth = depth;
            m_Children = children;
            m_PrefabMetadata = prefabMetadata;
            m_TransformPath = transformPath;
            m_ComponentIndex = componentIndex;
        }

        static ProxyListViewPropertyData<TContainer> PropertyToPropertyData<TContainer>(IProperty<TContainer> property,
            ref TContainer container, int index, string propertyPath, PrefabMetadata prefabMetadata, string transformPath,
            int depth = 0, int componentIndex = -1, IProperty optionalConstraint = null)
        {
            string template;
            var propertyType = property.DeclaredValueType();
            if (propertyType == typeof(Vector2) || propertyType == typeof(Vector3) || propertyType == typeof(Vector4) || propertyType == typeof(Quaternion))
                template = k_ProxyListVectorItemTemplate;
            else if (propertyType == typeof(string) || propertyType == typeof(char))
                template = k_ProxyListStringItemTemplate;
            else if (propertyType == typeof(Bounds))
                template = k_ProxyListUnimplementedItemTemplate;
            else if (propertyType == typeof(Color) || propertyType == typeof(Color32))
                template = k_ProxyListColorItemTemplate;
            else if (propertyType == typeof(Rect))
                template = k_ProxyListUnimplementedItemTemplate;
            else if (propertyType == typeof(bool))
                template = k_ProxyListBoolItem;
            else if (propertyType.IsEnum || propertyType == typeof(LayerMask))
                template = k_ProxyListDropdownItemTemplate;
            else if (propertyType.IsPrimitive)
                template = k_ProxyListNumberItem;
            else if (property is IUnityObjectReferenceValueProperty<TContainer>)
                template = k_ProxyListObjectFieldItemTemplate;
            else
                template = k_ProxyListGenericItemTemplate;

            var propertyData = new ProxyListViewPropertyData<TContainer>(template, container, index, depth, null, property, propertyPath,
                prefabMetadata, transformPath, componentIndex);

            if (optionalConstraint != null)
                propertyData.SetOptionalConstraintProperty(optionalConstraint);

            return propertyData;
        }
    }
}
