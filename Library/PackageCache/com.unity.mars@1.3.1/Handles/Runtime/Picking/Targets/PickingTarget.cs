using UnityEngine;

namespace Unity.MARS.MARSHandles.Picking
{
    /// <summary>
    /// Information used to calculate picking.
    /// </summary>
    struct PickingData
    {
        public static readonly PickingData invalid = new PickingData();

        /// <summary>
        /// Returns the transformation matrix used to place the mesh in world space.
        /// </summary>
        public Matrix4x4 matrix { get; private set; }

        /// <summary>
        /// Mesh used tgo calculate picking.
        /// </summary>
        public Mesh mesh { get; private set; }

        /// <summary>
        /// Returns true if the picking mesh has valid data.
        /// </summary>
        public bool valid
        {
            get { return mesh != null; }
        }

        
        public PickingData(Matrix4x4 matrix, Mesh mesh) : this()
        {
            this.matrix = matrix;
            this.mesh = mesh;
        }

        public PickingData(Transform trs, Mesh mesh) : this(trs.localToWorldMatrix, mesh)
        {
        }
    }

    /// <summary>
    /// Generic target for picking. Derived from to create a new type of picking target.  
    /// </summary>
    interface IPickingTarget
    {
        /// <summary>
        /// Get a mesh representation of the picking target information.
        /// </summary>
        /// <returns>Returns a mesh representation of the picking target. This mesh can be invalid.</returns>
        PickingData GetPickingData();
    }
}