using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    [MovedFrom("Unity.MARS")]
    public class RedirectSelection : MonoBehaviour
    {
        // When this gameObject is selected, the target is the GameObject that should be selected instead
        [field: SerializeField]
        public GameObject target { get; set; }
    }
}
