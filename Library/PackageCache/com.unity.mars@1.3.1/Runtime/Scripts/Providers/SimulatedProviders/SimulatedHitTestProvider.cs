using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.MARSUtils;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers.Synthetic
{
#if UNITY_EDITOR
    [ProviderSelectionOptions(ProviderPriorities.SimulatedProviderPriority)]
    [MovedFrom("Unity.MARS.Providers")]
    public class SimulatedHitTestProvider : IProvidesMRHitTesting, IUsesPlaneFinding, IUsesPointCloud
    {
        // Distance threshold for hit testing against points
        const float k_PointDistanceThresholdSquared = .01f * .01f;

        Camera m_Camera;
        bool m_Enabled;

        List<MRPlane> m_Planes = new List<MRPlane>();

        IProvidesPlaneFinding IFunctionalitySubscriber<IProvidesPlaneFinding>.provider { get; set; }
        IProvidesPointCloud IFunctionalitySubscriber<IProvidesPointCloud>.provider { get; set; }

        void IFunctionalityProvider.LoadProvider()
        {
            m_Camera = MarsRuntimeUtils.GetActiveCamera(true);

            m_Enabled = true;
        }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesMRHitTesting>(obj);
        }

        void IFunctionalityProvider.UnloadProvider() { }

        public bool ScreenHitTest(Vector2 screenPosition, out MRHitTestResult result, MRHitTestResultTypes types = MRHitTestResultTypes.Any)
        {
            if (m_Camera == null)
            {
                result = default;
                return false;
            }

            var ray = m_Camera.ScreenPointToRay(screenPosition);
            return Raycast(ray, out result, types);
        }

        public bool WorldHitTest(Ray ray, out MRHitTestResult result, MRHitTestResultTypes types = MRHitTestResultTypes.Any)
        {
            return Raycast(ray, out result, types);
        }

        bool Raycast(Ray ray, out MRHitTestResult result, MRHitTestResultTypes types)
        {
            if (!m_Enabled)
            {
                result = default;
                return false;
            }

            if (types.HasFlag(MRHitTestResultTypes.HorizontalPlane) || types.HasFlag(MRHitTestResultTypes.VerticalPlane))
            {
                this.GetPlanes(m_Planes);
                var checkAllOrientations = types.HasFlag(MRHitTestResultTypes.Plane);
                var checkHorizontal = types.HasFlag(MRHitTestResultTypes.HorizontalPlane);
                var checkVertical = types.HasFlag(MRHitTestResultTypes.VerticalPlane);
                foreach (var marsPlane in m_Planes)
                {
                    if (!checkAllOrientations)
                    {
                        // Test orientation
                        var normal = marsPlane.pose.up;
                        if (checkHorizontal
                            && (marsPlane.alignment & (MarsPlaneAlignment.HorizontalUp | MarsPlaneAlignment.HorizontalDown)) == 0)
                            continue;
                        if (checkVertical && !marsPlane.alignment.HasFlag(MarsPlaneAlignment.Vertical))
                            continue;
                    }

                    var plane = new Plane(marsPlane.pose.up, marsPlane.pose.position);
                    if (plane.Raycast(ray, out var distance))
                    {
                        var worldSpacePoint = ray.GetPoint(distance);
                        var planeSpacePoint =
                            Quaternion.Inverse(marsPlane.pose.rotation) * (worldSpacePoint - marsPlane.pose.position);
                        if (GeometryUtils.PointInPolygon(planeSpacePoint, marsPlane.vertices))
                        {
                            result = new MRHitTestResult();
                            result.pose = new Pose(ray.GetPoint(distance), marsPlane.pose.rotation);
                            return true;
                        }
                    }
                }
            }

            if (types.HasFlag(MRHitTestResultTypes.FeaturePoint))
            {
                var points = this.GetPoints();
                foreach (var pointCloud in points.Values)
                {
                    foreach (var p in pointCloud.Positions)
                    {
                        // Ray-sphere intersection
                        var eo = p - ray.origin;
                        var v = Vector3.Dot(eo, ray.direction);
                        var disc = k_PointDistanceThresholdSquared - (Vector3.Dot(eo, eo) - v * v);
                        if (disc >= 0)
                        {
                            result = new MRHitTestResult();
                            result.pose = new Pose(p, Quaternion.identity);
                            return true;
                        }
                    }
                }
            }

            result = default;
            return false;
        }

        public void StopHitTesting() { m_Enabled = false; }
        public void StartHitTesting() { m_Enabled = true; }
    }
#endif
}
