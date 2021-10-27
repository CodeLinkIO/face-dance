using System;
using System.Collections.Generic;
using Unity.MARS.MARSUtils;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Landmarks
{
    /// <summary>
    /// List of the polygon's landmark definitions as an enum
    /// </summary>
    enum BasicPolygonLandmarks
    {
        Centroid,
        Closest,
        BoundingRect
    }

    /// <summary>
    /// Component that contains polygon data for a landmark. Also a source for calculating other landmarks
    /// from the polygon data.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class LandmarkOutputPolygon : MonoBehaviour, ICalculateLandmarks, ILandmarkOutput
    {
        static readonly List<LandmarkDefinition> k_Definitions = new List<LandmarkDefinition>
        {
            new LandmarkDefinition(BasicPolygonLandmarks.Centroid.ToString(), new []{typeof(LandmarkOutputPoint)}),
            new LandmarkDefinition(BasicPolygonLandmarks.Closest.ToString(),
                new []{typeof(LandmarkOutputPoint), typeof(LandmarkOutputEdge), typeof(LandmarkOutputPose)},
                typeof(ClosestLandmarkSettings)),
            new LandmarkDefinition(BasicPolygonLandmarks.BoundingRect.ToString(),
                new[]{typeof(LandmarkOutputPolygon)})
        };

        [SerializeField]
        bool m_ShowDebugVisuals = true;

        [SerializeField]
        Color m_DebugColor = Color.cyan;

        readonly Vector3[] k_RectOutputVerts = new Vector3[4];

        public event Action<ICalculateLandmarks> dataChanged;

        public Pose pose { get; set; }
        readonly List<Vector3> m_WorldVerts = new List<Vector3>();
        readonly List<Vector3> m_LocalVerts = new List<Vector3>();

        public List<Vector3> worldVertices
        {
            get { return m_WorldVerts; }
        }

        public List<Vector3> localVertices
        {
            get { return m_LocalVerts; }
        }

        protected void FireDataChangeEvent()
        {
            if (dataChanged != null)
                dataChanged(this);
        }

        public void SetPolygonLocalSpace(List<Vector3> newLocalVertices, Pose newPose)
        {
            // Remove extra elements beyond size of input list
            if (newLocalVertices.Count < m_WorldVerts.Count)
                m_WorldVerts.RemoveRange(newLocalVertices.Count, m_WorldVerts.Count - newLocalVertices.Count);

            if (newLocalVertices.Count < m_LocalVerts.Count)
                m_LocalVerts.RemoveRange(newLocalVertices.Count, m_LocalVerts.Count - newLocalVertices.Count);

            // Copy values and transform from local to world
            for (var i = 0; i < newLocalVertices.Count; i++)
            {
                if (i < m_WorldVerts.Count)
                    m_WorldVerts[i] = newPose.ApplyOffsetTo(newLocalVertices[i]);
                else
                    m_WorldVerts.Add(newPose.ApplyOffsetTo(newLocalVertices[i]));

                if (i < m_LocalVerts.Count)
                    m_LocalVerts[i] = newLocalVertices[i];
                else
                    m_LocalVerts.Add(newLocalVertices[i]);
            }

            pose = newPose;
        }

        public void SetPolygonWorldSpace(List<Vector3> newWorldVertices, Pose newPose)
        {
            // Remove extra elements beyond size of input list
            if (newWorldVertices.Count < m_WorldVerts.Count)
                m_WorldVerts.RemoveRange(newWorldVertices.Count, m_WorldVerts.Count - newWorldVertices.Count);

            if (newWorldVertices.Count < m_LocalVerts.Count)
                m_LocalVerts.RemoveRange(newWorldVertices.Count, m_LocalVerts.Count - newWorldVertices.Count);

            // Copy values and transform from world to local
            for (var i = 0; i < newWorldVertices.Count; i++)
            {
                if (i < m_WorldVerts.Count)
                    m_WorldVerts[i] = newWorldVertices[i];
                else
                    m_WorldVerts.Add(newWorldVertices[i]);

                if (i < m_LocalVerts.Count)
                    m_LocalVerts[i] = newPose.ApplyInverseOffsetTo(newWorldVertices[i]);
                else
                    m_LocalVerts.Add(newPose.ApplyInverseOffsetTo(newWorldVertices[i]));
            }

            pose = newPose;
        }

        public virtual List<LandmarkDefinition> AvailableLandmarkDefinitions { get { return k_Definitions; } }

        /// <inheritdoc />
        public void SetupLandmark(ILandmarkController landmark)
        {
            // Use MARS session camera as the default target for "closest" landmark
            if (landmark.landmarkDefinition.GetEnumName<BasicPolygonLandmarks>() == BasicPolygonLandmarks.Closest)
            {
                var settings = landmark.settings as ClosestLandmarkSettings;
                if (settings != null)
                {
                    if (settings.target != null)
                        return;

                    var sessionCamera = MarsRuntimeUtils.GetSessionAssociatedCamera();
                    if (sessionCamera != null)
                        settings.target = sessionCamera.transform;
                }
                else
                    Debug.LogError("Closest landmark is missing valid settings component", gameObject);
            }
        }

        /// <inheritdoc />
        public virtual Action<ILandmarkController> GetLandmarkCalculation(LandmarkDefinition definition)
        {
            var landmarkType = definition.GetEnumName<BasicPolygonLandmarks>();
            switch (landmarkType)
            {
                case BasicPolygonLandmarks.Centroid:
                    return CalculateCentroidLandmark;
                case BasicPolygonLandmarks.Closest:
                    return CalculateClosestLandmark;
                case BasicPolygonLandmarks.BoundingRect:
                    return CalculateBoundingRectangle;
                default:
                    Debug.LogError("Attempting to get a landmark outside the range of available landmarks.", this);
                    return null;
            }
        }

        void CalculateBoundingRectangle(ILandmarkController landmark)
        {
            var polygonOutput = landmark.output as LandmarkOutputPolygon;
            if (polygonOutput != null)
            {
                if (m_LocalVerts.Count > 3)
                {
                    GeometryUtils.OrientedMinimumBoundingBox2D(m_LocalVerts, k_RectOutputVerts);
                    var rectCenter = Vector3.zero;
                    polygonOutput.localVertices.Clear();
                    for (int i = 0; i < k_RectOutputVerts.Length; i++)
                        rectCenter += k_RectOutputVerts[i];

                    rectCenter /= k_RectOutputVerts.Length;
                    for (int i = k_RectOutputVerts.Length - 1; i >= 0; i--)
                    {
                        // Add in reverse order because we want vertices in clockwise order to match plane vertex order
                        polygonOutput.localVertices.Add(k_RectOutputVerts[i] - rectCenter);
                    }

                    rectCenter = pose.ApplyOffsetTo(rectCenter);
                    polygonOutput.SetPolygonLocalSpace(polygonOutput.localVertices, new Pose(rectCenter, pose.rotation));
                }
            }
        }

        void CalculateClosestLandmark(ILandmarkController landmark)
        {
            var settings = landmark.settings as ClosestLandmarkSettings;
            if (settings == null)
                return;

            if (worldVertices == null || settings.target == null)
                return;

            if (m_WorldVerts.Count < 3)
                return;

            Vector3 edgeVertA;
            Vector3 edgeVertB;
            switch (landmark.output)
            {
                case LandmarkOutputPoint landmarkPoint:
                    {
                        var targetPolygon = settings.target as LandmarkOutputPolygon;
                        if (targetPolygon && targetPolygon.worldVertices.Count > 0)
                        {
                            Vector3 closestOnThis, closestOnOther;
                            GeometryUtils.ClosestPolygonApproach(m_WorldVerts, targetPolygon.worldVertices, out closestOnThis, out closestOnOther);
                            landmarkPoint.position = closestOnThis;
                        }
                        else
                        {
                            var targetPosition = settings.target.transform.position;
                            var planeNormal = Vector3.Cross(m_WorldVerts[0] - m_WorldVerts[1], m_WorldVerts[2] - m_WorldVerts[1]).normalized;
                            var pointOnInfinitePlane = GeometryUtils.ProjectPointOnPlane(planeNormal, m_WorldVerts[1], targetPosition);
                            if (GeometryUtils.PointInPolygon3D(pointOnInfinitePlane, m_WorldVerts))
                            {
                                landmarkPoint.position = pointOnInfinitePlane;
                            }
                            else
                            {
                                GeometryUtils.FindClosestEdge(m_WorldVerts, targetPosition, out edgeVertA, out edgeVertB);
                                landmarkPoint.position = GeometryUtils.ClosestPointOnLineSegment(targetPosition, edgeVertA, edgeVertB);
                            }
                        }
                    }
                    break;

                case LandmarkOutputEdge landmarkEdge:
                    {
                        var targetPosition = settings.target.transform.position;
                        GeometryUtils.FindClosestEdge(m_WorldVerts, targetPosition, out edgeVertA, out edgeVertB);
                        landmarkEdge.startPoint = edgeVertA;
                        landmarkEdge.endPoint = edgeVertB;
                    }
                    break;

                case LandmarkOutputPose landmarkPose:
                    {
                        var targetPolygon = settings.target as LandmarkOutputPolygon;
                        Vector3 closestOnThis, closestOnOther;

                        if (targetPolygon && targetPolygon.worldVertices.Count > 0)
                        {
                            GeometryUtils.ClosestPolygonApproach(m_WorldVerts, targetPolygon.worldVertices, out closestOnThis, out closestOnOther);
                        }
                        else
                        {
                            closestOnOther = settings.target.transform.position;
                            var planeNormal = Vector3.Cross(m_WorldVerts[0] - m_WorldVerts[1], m_WorldVerts[2] - m_WorldVerts[1]).normalized;
                            var pointOnInfinitePlane = GeometryUtils.ProjectPointOnPlane(planeNormal, m_WorldVerts[1], closestOnOther);
                            if (GeometryUtils.PointInPolygon3D(pointOnInfinitePlane, m_WorldVerts))
                            {
                                closestOnThis = pointOnInfinitePlane;
                            }
                            else
                            {
                                GeometryUtils.FindClosestEdge(m_WorldVerts, closestOnOther, out edgeVertA, out edgeVertB);
                                closestOnThis = GeometryUtils.ClosestPointOnLineSegment(closestOnOther, edgeVertA, edgeVertB);
                            }
                        }
                        // Make sure look direction is flattened along the plane
                        var lookDirection = closestOnOther - closestOnThis;
                        lookDirection = Vector3.Cross(Vector3.Cross(lookDirection, transform.up), transform.up);
                        landmarkPose.currentPose = new Pose { position = closestOnThis, rotation = Quaternion.LookRotation(lookDirection) };
                    }
                    break;
            }
        }

        void CalculateCentroidLandmark(ILandmarkController landmark)
        {
            if (m_LocalVerts.Count < 1)
                return;

            var landmarkPoint = landmark.output as LandmarkOutputPoint;
            if (landmarkPoint != null)
                landmarkPoint.position = pose.ApplyOffsetTo(GeometryUtils.PolygonCentroid2D(m_LocalVerts));
        }

        /// <inheritdoc />
        public void UpdateOutput()
        {
            if (m_WorldVerts.Count > 3)
                transform.position = pose.position;

            FireDataChangeEvent();
        }

        void OnDrawGizmosSelected()
        {
            if (!m_ShowDebugVisuals)
                return;

            if (worldVertices.Count > 2)
            {
                Gizmos.color = m_DebugColor;
                for (int i = 0; i < worldVertices.Count; i++)
                    Gizmos.DrawLine(worldVertices[i], worldVertices[(i + 1) % worldVertices.Count]);
            }
        }
    }
}
