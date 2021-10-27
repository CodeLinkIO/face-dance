#if !UNITY_2019_2_OR_NEWER || INCLUDE_UGUI
using UnityEngine;
using UnityEngine.UI;

// this class exists to allow testing of the overload for
// MaterialUtils.GetMaterialClone that takes a Graphic-derived class

namespace Unity.XRTools.Utils
{
    [AddComponentMenu("")]
    public class TestImage : Graphic
    {
        protected override void OnPopulateMesh(VertexHelper vh) {}
    }
}
#endif
