#if UNITY_EDITOR
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Tests
{
    class DatabaseUtils : IProvidesTraits<bool>, IProvidesTraits<Pose>, IProvidesTraits<Vector2>, IUsesMARSTrackableData<MRPlane>
    {
        static readonly DatabaseUtils Instance = new DatabaseUtils();

        public static void AddPlane(int id, Pose pose = default, Vector2 bounds = default)
        {
            Instance.AddPlaneInternal(id, pose, bounds);
        }

        public static void RemovePlane(int id)
        {
            Instance.RemovePlaneInternal(id);
        }

        void AddPlaneInternal(int id, Pose pose = default, Vector2 bounds = default)
        {
            var plane = new MRPlane
            {
                id = new MarsTrackableId(0, (ulong)id),
                pose = pose,
                extents = bounds
            };
            this.AddData(id, plane);
            this.AddOrUpdateTrait(id, TraitNames.Plane, true);
            this.AddOrUpdateTrait(id, TraitNames.Pose, pose);
            if (bounds != default)
                this.AddOrUpdateTrait(id, TraitNames.Bounds2D, bounds);
        }
        
        void RemovePlaneInternal(int id)
        {
            this.RemoveData(new MRPlane { id = new MarsTrackableId(0, (ulong)id) });
            this.RemoveTrait<bool>(id, TraitNames.Plane);
            this.RemoveTrait<Pose>(id, TraitNames.Pose);
            this.RemoveTrait<Vector2>(id, TraitNames.Bounds2D);
        }

        static readonly TraitDefinition[] k_ProvidedTraits = new TraitDefinition[0];
        public TraitDefinition[] GetProvidedTraits() => k_ProvidedTraits;
    }
}
#endif