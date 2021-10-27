using System;
using System.Collections.Generic;
using System.Globalization;
using Unity.MARS.Forces.ForceDefinitions;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS.Forces.EditorExtensions
{
    /// <summary>
    /// Manages the drawing for proxy forces.
    /// </summary>
    internal class ProxyForcesHandles
    {
        List<ProxyAlignmentForce> m_Alignments = new List<ProxyAlignmentForce>();
        List<ProxyRegionForceBase> m_Regions = new List<ProxyRegionForceBase>();
        ProxyForces m_LatestObject;

        static ProxyForcesHandles s_MainInstance = null;

        static Color k_ColorTowardsEdge = Color.Lerp(Color.red, Color.yellow, 0.25f); // red-ish
        static Color k_ColorTowardsSurface = Color.Lerp(Color.red, Color.yellow, 0.75f); // yellow-ish

        public static ProxyForcesHandles main
        {
            get
            {
                if (s_MainInstance != null) return s_MainInstance;
                s_MainInstance = new ProxyForcesHandles();
                return s_MainInstance;
            }
        }

        public void CustomForcesHandles(ProxyForces vf)
        {
            if (vf != m_LatestObject)
            {
                ResetQueries(vf);
            }

            if (vf)
            {
                CustomDrawGizmosSelected();
            }
        }

        void ResetQueries(ProxyForces vf)
        {
            m_LatestObject = vf;
            m_Alignments.Clear();
            m_Regions.Clear();
            if (vf)
            {
                m_Alignments.AddRange(vf.GetComponents<ProxyAlignmentForce>());
                m_Regions.AddRange(vf.GetComponents<ProxyRegionForceBase>());
            }
        }

        public void CustomAlignmentHandles(ProxyAlignmentForce alignmentForce)
        {

            Handles.matrix = Matrix4x4.identity;
            if (!alignmentForce || (!alignmentForce.enabled) || !alignmentForce.targetProxy)
                return;


            Pose myPose = PoseUtils.FromTransform(alignmentForce.transform);
            if (!alignmentForce.TryGetTargetPose(out Pose targetPose, true))
                return;
            if (!alignmentForce.TryGetGoalPose(out Pose goalPose, true))
                return;
            Handles.color = Color.gray;
            Handles.DrawLine(targetPose.position, goalPose.position);
            Handles.color = Color.green;
            Handles.DrawLine(myPose.position, goalPose.position);
        }

        public void CustomRegionHandles(ProxyRegionForceBase regionSource)
        {
            var region = regionSource.GetRegionForce();
            if (regionSource.regionTransform)
                Handles.matrix = regionSource.regionTransform.localToWorldMatrix;
            else
                Handles.matrix = regionSource.transform.localToWorldMatrix;
            switch ( region.regionDefinition.regionType)
            {
                case ProxyRegionForceType.OccupiedSpace:
                    Handles.color = Color.cyan;
                    break;
                case ProxyRegionForceType.PaddingKeptEmpty:
                    Handles.color = Color.gray;
                    break;
                case ProxyRegionForceType.TowardsOccupiedEdge:
                    Handles.color = k_ColorTowardsEdge;
                    break;
                case ProxyRegionForceType.TowardsOccupiedSpace:
                    Handles.color = k_ColorTowardsSurface;
                    break;
                default:
                    Handles.color = Color.red;
                    break;
            }
            switch (region.regionDefinition.shapePrimitive.primitiveType)
            {
                case ProxyForceFieldPrimitive.FieldPrimitiveType.Box:
                case ProxyForceFieldPrimitive.FieldPrimitiveType.PlaneForward:
                    Handles.DrawWireCube(Vector3.zero, Vector3.one);
                    break;
                case ProxyForceFieldPrimitive.FieldPrimitiveType.Sphere:
                    break;
                case ProxyForceFieldPrimitive.FieldPrimitiveType.LineOnX:
                    break;
            }
        }

        void CustomDrawGizmosSelected()
        {
            var vf = m_LatestObject;
            if (!vf)
                return;

            var prevMatrix = Handles.matrix;
            Handles.matrix = vf.transform.localToWorldMatrix;

            foreach (var r in m_Regions)
            {
                if (r)
                    CustomRegionHandles(r);
            }

            foreach (var a in m_Alignments)
            {
                if (a)
                    CustomAlignmentHandles(a);
            }

            Handles.matrix = prevMatrix;
        }
    }
}
