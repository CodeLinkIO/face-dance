using System;
using System.Collections.Generic;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Collections of different types of bi-directional data filters, and the constraints of child MR objects involved
    /// </summary>
    public partial class Relations
    {
        /// <summary>
        /// Child MR objects involved in the relations, and the constraints of those children
        /// </summary>
        public Dictionary<IMRObject, SetChildArgs> children;

        public int Count { get; protected set; }

        public Relations(GameObject gameObject, Dictionary<IMRObject, SetChildArgs> children)
        {
            this.children = children;
            InitFromGameObject(gameObject);
        }

        void InitFromGameObject(GameObject go)
        {
            var set = go.GetComponent<ProxyGroup>();
            if (set == null)
                return;

            FilterRelations(set);
        }

        public Relations(Relation relation, SetChildArgs child1Args, SetChildArgs child2Args)
        {
            Count = 1;
            children = new Dictionary<IMRObject, SetChildArgs>
            {
                { relation.child1, child1Args },
                { relation.child2, child2Args }
            };

            FromRelation(relation);
        }

        public Relations(IRelation[] relations, Dictionary<IMRObject, SetChildArgs> children = null)
        {
            this.children = children;
            using (var componentFilter = new CachedComponentFilter<IRelation, Component>(relations, false))
            {
                GatherComponents(componentFilter);
            }
        }

        void FilterRelations(ProxyGroup target)
        {
            Count = 0;
            using (var componentFilter = new CachedComponentFilter<IRelation, ProxyGroup>(target, CachedSearchType.Self | CachedSearchType.Parents, false))
            {
                GatherComponents(componentFilter);
            }
        }

        // ReSharper disable UnusedMember.Local
        // ReSharper disable UnusedParameter.Local
        void FromRelation(object self) { }

        void GatherComponents(object self) { }

        public bool TryGetType<T>(out IRelation<T>[] conditions) where T: struct
        {
            conditions = default;
            return default;
        }

        /// <summary>
        /// This method exists in order for MARS to compile before type-specific code is generated. Use the type-specific version of this method
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        [Obsolete("This method exists in order for MARS to compile before type-specific code is generated. Use the type-specific version of this method")]
        public bool TryGetType(out object[] conditions)
        {
            conditions = default;
            return default;
        }

        // ReSharper restore UnusedMember.Local
        // ReSharper restore UnusedParameter.Local
    }
}
