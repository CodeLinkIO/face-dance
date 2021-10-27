using Unity.MARS;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Inspector for a spatial condition that can be drawn in a component list editor.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public abstract class SpatialConditionInspector : ConditionBaseInspector
    {
        /// <summary>
        /// Condition object for the inspected condition
        /// </summary>
        protected Condition condition { get; private set; }

        /// <inheritdoc/>
        public override void OnEnable()
        {
            condition = (Condition)target;
            base.OnEnable();
        }
    }
}
