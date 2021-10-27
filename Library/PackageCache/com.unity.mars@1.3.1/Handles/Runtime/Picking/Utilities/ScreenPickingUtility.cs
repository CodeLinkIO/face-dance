using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Picking
{
    /// <summary>
    /// Picking utility to get the hovered picking targets in screen space.
    /// </summary>
    static class ScreenPickingUtility
    {
        static readonly List<PickingHit> s_HitsBuffer = new List<PickingHit>(64);
        static readonly List<IPickingTarget> s_TargetsBuffer = new List<IPickingTarget>(64);
        static readonly List<IPickingTarget> s_ComponentBuffer = new List<IPickingTarget>(64);

        /// <summary>
        /// Get the nearest hovered picking targets.
        /// </summary>
        /// <param name="targets">The picking targets to test for hovered.</param>
        /// <param name="screenPosition">The position in camera screen space.</param>
        /// <param name="camera">The target camera to use for picking.</param>
        /// <param name="maxDistance">The maximum distance for a picking target to be considered hovered.</param>
        /// <param name="hit">Returns a single picking hit for the nearest hit.</param>
        /// <returns>Returns true if a picking target was within the maxDistance.</returns>
        public static bool GetHovered(
            IReadOnlyList<IPickingTarget> targets,
            Vector2 screenPosition, 
            Camera camera,
            float maxDistance, 
            out PickingHit hit)
        {
            if (targets == null)
                throw new ArgumentNullException(nameof(targets));

            if (camera == null)
                throw new ArgumentNullException(nameof(camera));

            if (!GetHoveredAll(targets, screenPosition, camera, maxDistance, s_HitsBuffer))
            {
                hit = new PickingHit(null, float.MaxValue);
                return false;
            }

            PickingHit closest = new PickingHit(null, float.MaxValue);
            foreach (var h in s_HitsBuffer)
            {
                if (h.distance < closest.distance)
                {
                    closest = h;
                }
            }

            hit = closest;
            return hit.valid;
        }

        /// <summary>
        /// Get the nearest hovered picking targets.
        /// </summary>
        /// <param name="targets">The game objects to query for picking targets and test for hovered.</param>
        /// <param name="screenPosition">The position in camera screen space.</param>
        /// <param name="camera">The target camera to use for picking.</param>
        /// <param name="maxDistance">The maximum distance for a picking target to be considered hovered.</param>
        /// <param name="hit">Returns a single picking hit for the nearest hit.</param>
        /// <returns>Returns true if a picking target was within the maxDistance.</returns>
        public static bool GetHovered(
            IReadOnlyList<GameObject> targets,
            Vector2 screenPosition,
            Camera camera,
            float maxDistance,
            out PickingHit hit)
        {
            if (targets == null)
                throw new ArgumentNullException(nameof(targets));

            if (camera == null)
                throw new ArgumentNullException(nameof(camera));

            GetPickingTargets(targets, s_TargetsBuffer);
            return GetHovered(s_TargetsBuffer, screenPosition, camera, maxDistance, out hit);
        }

        /// <summary>
        /// Get the nearest hovered picking targets.
        /// </summary>
        /// <param name="targets">The picking targets to test for hovered.</param>
        /// <param name="screenPosition">The position in camera screen space.</param>
        /// <param name="camera">The target camera to use for picking.</param>
        /// <param name="maxDistance">The maximum distance for a picking target to be considered hovered.</param>
        /// <param name="results">Result array is cleared and filled with the result hits.</param>
        /// <returns>Returns true if at least one picking target was within the maxDistance.</returns>
        public static bool GetHoveredAll(
            IReadOnlyList<IPickingTarget> targets,
            Vector2 screenPosition,
            Camera camera,
            float maxDistance,
            List<PickingHit> results)
        {
            if (targets == null)
                throw new ArgumentNullException(nameof(targets));

            if (camera == null)
                throw new ArgumentNullException(nameof(camera));

            if (results == null)
                throw new ArgumentNullException(nameof(results));

            results.Clear();
            for (int i = 0, count = targets.Count; i < count; ++i)
            {
                var target = targets[i];
                if (target == null)
                    continue;

                var pickingData = target.GetPickingData();
                if (!pickingData.valid)
                    continue;

                var distance = ScreenDistanceUtility.DistanceToMesh(
                    screenPosition,
                    camera,
                    pickingData.matrix,
                    pickingData.mesh);

                if (distance <= maxDistance)
                    results.Add(new PickingHit(target, distance));
            }

            return results.Count > 0;
        }

        /// <summary>
        /// Get the nearest hovered picking targets.
        /// </summary>
        /// <param name="targets">The game objects to query for picking targets and test for hovered.</param>
        /// <param name="screenPosition">The position in camera screen space.</param>
        /// <param name="camera">The target camera to use for picking.</param>
        /// <param name="maxDistance">The maximum distance for a picking target to be considered hovered.</param>
        /// <param name="results">Result array is cleared and filled with the result hits.</param>
        /// <returns>Returns true if at least one picking target was within the maxDistance.</returns>
        public static bool GetHoveredAll(
            IReadOnlyList<GameObject> targets,
            Vector2 screenPosition,
            Camera camera, 
            float maxDistance,
            List<PickingHit> results)
        {
            if (targets == null)
                throw new ArgumentNullException(nameof(targets));

            if (camera == null)
                throw new ArgumentNullException(nameof(camera));

            if (results == null)
                throw new ArgumentNullException(nameof(results));

            GetPickingTargets(targets, s_TargetsBuffer);
            return GetHoveredAll(s_TargetsBuffer, screenPosition, camera, maxDistance, results);
        }

        /// <summary>
        /// Get the nearest hovered picking targets.
        /// </summary>
        /// <param name="targets">The picking targets to test for hovered.</param>
        /// <param name="screenPosition">The position in camera screen space.</param>
        /// <param name="camera">The target camera to use for picking.</param>
        /// <param name="maxDistance">The maximum distance for a picking target to be considered hovered.</param>
        /// <returns>Returns an array of result hits.</returns>
        public static PickingHit[] GetHoveredAll(
            IReadOnlyList<IPickingTarget> targets,
            Vector2 screenPosition,
            Camera camera,
            float maxDistance)
        {
            if (targets == null)
                throw new ArgumentNullException(nameof(targets));

            if (camera == null)
                throw new ArgumentNullException(nameof(camera));

            GetHoveredAll(targets, screenPosition, camera, maxDistance, s_HitsBuffer);
            return s_HitsBuffer.ToArray();
        }

        /// <summary>
        /// Get the nearest hovered picking targets.
        /// </summary>
        /// <param name="targets">The game objects to query for picking targets and test for hovered.</param>
        /// <param name="screenPosition">The position in camera screen space.</param>
        /// <param name="camera">The target camera to use for picking.</param>
        /// <param name="maxDistance">The maximum distance for a picking target to be considered hovered.</param>
        /// <returns>Returns an array of result hits.</returns>
        public static PickingHit[] GetHoveredAll(
            IReadOnlyList<GameObject> targets,
            Vector2 screenPosition,
            Camera camera, 
            float maxDistance)
        {
            if (targets == null)
                throw new ArgumentNullException(nameof(targets));

            if (camera == null)
                throw new ArgumentNullException(nameof(camera));

            GetPickingTargets(targets, s_TargetsBuffer);
            return GetHoveredAll(s_TargetsBuffer, screenPosition, camera, maxDistance);
        }

        static void GetPickingTargets(IReadOnlyList<GameObject> gameObjects, List<IPickingTarget> results)
        {
            results.Clear();
            for (int i = 0, count = gameObjects.Count; i < count; ++i)
            {
                var gameObject = gameObjects[i];
                if (gameObject == null || !gameObject.activeInHierarchy)
                    continue;

                gameObject.GetComponentsInChildren(false, s_ComponentBuffer);
                results.AddRange(s_ComponentBuffer);
            }
        }
    }
}