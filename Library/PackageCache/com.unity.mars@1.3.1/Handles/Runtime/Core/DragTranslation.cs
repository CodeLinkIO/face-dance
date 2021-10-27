using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    struct DragTranslation
    {
        /// <summary>
        /// The initial world position when the drag was started.
        /// </summary>
        public Vector3 initialPosition { get; private set; }

        /// <summary>
        /// The current world position of the drag.
        /// </summary>
        public Vector3 currentPosition { get; private set; }

        // <summary>
        /// The delta of the drag in world position.
        /// </summary>
        public Vector3 delta { get; private set; }

        public DragTranslation(Vector3 initialPosition, Vector3 currentPosition, Vector3 delta) : this()
        {
            this.initialPosition = initialPosition;
            this.currentPosition = currentPosition;
            this.delta = delta;
        }
    }
}