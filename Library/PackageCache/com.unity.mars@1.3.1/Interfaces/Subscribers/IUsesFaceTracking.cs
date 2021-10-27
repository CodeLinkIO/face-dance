using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to face tracking features
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesFaceTracking : IFunctionalitySubscriber<IProvidesFaceTracking>, IFaceFeature
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesFaceTrackingMethods
    {
        internal const string GetMaxFaceCountObsoleteMessage = "Use CurrentMaximumFaceCount/SupportedFaceCount instead";

        /// <summary>
        /// Get the total number of faces that can be tracked by this provider simultaneously
        /// </summary>
        /// <returns>The maximum possible number of simultaneously tracked faces, -1 if there is no theoretical limit</returns>
        [Obsolete(GetMaxFaceCountObsoleteMessage)]
        public static int GetMaxFaceCount(this IUsesFaceTracking obj)
        {
            return obj.provider.GetMaxFaceCount();
        }

        /// <summary>
        /// Gets the current number of faces to track simultaneously.
        /// </summary>
        public static int GetRequestedMaximumFaceCount(this IUsesFaceTracking obj)
        {
            return obj.provider.RequestedMaximumFaceCount;
        }

        /// <summary>
        /// Sets the current maximum faces to track simultaneously.
        /// </summary>
        public static void SetRequestedMaximumFaceCount(this IUsesFaceTracking obj, int requestedFaceCount)
        {
            obj.provider.RequestedMaximumFaceCount = requestedFaceCount;
        }

        /// <summary>
        /// Gets the current maximum face count.
        /// If RequestedMaximumFaceCount set is supported,
        /// will reflect that value once the provider has
        /// been updated.
        /// </summary>
        public static int GetCurrentMaximumFaceCount(this IUsesFaceTracking obj)
        {
            return obj.provider.CurrentMaximumFaceCount;
        }

        /// <summary>
        /// The absolute maximum number of faces that can be supported by the provider.
        /// -1 if unlimited.
        /// </summary>
        public static int GetSupportedFaceCount(this IUsesFaceTracking obj)
        {
            return obj.provider.SupportedFaceCount;
        }

        /// <summary>
        /// Get the currently tracked faces
        /// </summary>
        /// <param name="faces">A list of IMRFace objects to which the currently tracked planes will be added</param>
        public static void GetFaces(this IUsesFaceTracking obj, List<IMRFace> faces)
        {
            obj.provider.GetFaces(faces);
        }

        /// <summary>
        /// Subscribe to the faceAdded event, which is called whenever a face becomes tracked for the first time
        /// </summary>
        /// <param name="faceAdded">The delegate to subscribe</param>
        public static void SubscribeFaceAdded(this IUsesFaceTracking obj, Action<IMRFace> faceAdded)
        {
            obj.provider.FaceAdded += faceAdded;
        }

        /// <summary>
        /// Unsubscribe a delegate from the faceAdded event
        /// </summary>
        /// <param name="faceAdded">The delegate to unsubscribe</param>
        public static void UnsubscribeFaceAdded(this IUsesFaceTracking obj, Action<IMRFace> faceAdded)
        {
            obj.provider.FaceAdded -= faceAdded;
        }

        /// <summary>
        /// Subscribe to the faceUpdated event, which is called when a tracked face has updated data
        /// </summary>
        /// <param name="faceUpdated">The delegate to subscribe</param>
        public static void SubscribeFaceUpdated(this IUsesFaceTracking obj, Action<IMRFace> faceUpdated)
        {
            obj.provider.FaceUpdated += faceUpdated;
        }

        /// <summary>
        /// Unsubscribe a delegate from the faceUpdated event
        /// </summary>
        /// <param name="faceUpdated">The delegate to unsubscribe</param>
        public static void UnsubscribeFaceUpdated(this IUsesFaceTracking obj, Action<IMRFace> faceUpdated)
        {
            obj.provider.FaceUpdated -= faceUpdated;
        }

        /// <summary>
        /// Subscribe to the faceRemoved event, which is called whenever a tracked face is removed (lost)
        /// </summary>
        /// <param name="faceRemoved">The delegate to subscribe</param>
        public static void SubscribeFaceRemoved(this IUsesFaceTracking obj, Action<IMRFace> faceRemoved)
        {
            obj.provider.FaceRemoved += faceRemoved;
        }

        /// <summary>
        /// Unsubscribe a delegate from the faceRemoved event
        /// </summary>
        /// <param name="faceRemoved">The delegate to unsubscribe</param>
        public static void UnsubscribeFaceRemoved(this IUsesFaceTracking obj, Action<IMRFace> faceRemoved)
        {
            obj.provider.FaceRemoved -= faceRemoved;
        }
    }
}
