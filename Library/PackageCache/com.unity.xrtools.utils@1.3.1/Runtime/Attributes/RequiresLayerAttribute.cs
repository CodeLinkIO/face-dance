#if UNITY_EDITOR
using System;

namespace Unity.XRTools.Utils
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class RequiresLayerAttribute : Attribute
    {
        public string layer;

        public RequiresLayerAttribute(string layer)
        {
            this.layer = layer;
        }
    }
}
#endif
