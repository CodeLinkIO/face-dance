using System.Collections;
using System.Collections.Generic;
using Unity.MARS.Forces.ForceFieldSolving;
using UnityEngine;

namespace Unity.MARS.Forces.ForceDefinitions
{
    internal struct ProxyForceAlignmentDefinition
    {
        public ProxyAlignmentForceType alignmentType;
        public ProxyAlignmentForceScaling scaleForces;
        [HideInInspector]
        public Pose relativeFromTargetPose;

        const float k_MaxDistance = 1000.0f;
        const float k_MaxAngle = 360.0f;
        const float k_GlobalScaleAlignmentMotion = 0.20f;
        const float k_GlobalScaleAlignmentAngle = 0.16f;


        public static ProxyForceAlignmentDefinition Default {
            get
            {
                return new ProxyForceAlignmentDefinition()
                {
                    alignmentType = ProxyAlignmentForceType.SceneInitialRelativePose,
                    scaleForces = ProxyAlignmentForceScaling.Default,
                    relativeFromTargetPose = Pose.identity,
                };
            }
        }

        public Pose GoalPose(Pose myPose, Pose targetPose)
        {
            return CalcGoalPose(myPose, targetPose, alignmentType, relativeFromTargetPose);
        }

        public static Pose CalcGoalPose(Pose myPose, Pose targetPose, ProxyAlignmentForceType forceType, Pose relativePose)
        {
            var goalPose = targetPose;

            switch (forceType)
            {
                case ProxyAlignmentForceType.MoveToAndAlignWith:
                    break; // simply the other pose
                case ProxyAlignmentForceType.MoveToAndFace:
                    goalPose.rotation = PoseUtils.LookRotationSafe(targetPose.position - myPose.position, Vector3.up);
                    break; // done
                case ProxyAlignmentForceType.MoveToAndFaceAwayFrom:
                    goalPose.rotation = PoseUtils.LookRotationSafe(targetPose.position - myPose.position, Vector3.up);
                    goalPose.rotation = goalPose.rotation * Quaternion.Euler(0, 180f, 0);
                    break; // done
                case ProxyAlignmentForceType.CenterInFrontOfAndFace:
                {
                     var ray = new Ray(targetPose.position, targetPose.forward);
                     var dist = Vector3.Dot(myPose.position - ray.origin, ray.direction.normalized);
                     var nearest = ray.GetPoint(dist);
                     goalPose.position = nearest;
                     goalPose.rotation = PoseUtils.LookRotationSafe(targetPose.position - goalPose.position, Vector3.up);
                }
                     break;
                case ProxyAlignmentForceType.SceneInitialRelativePose:
                    goalPose = PoseUtils.WorldFromLocalPose(targetPose, relativePose);
                    break;
                case ProxyAlignmentForceType.SceneInitialRelativeAngle:
                {
                    var relGoal = PoseUtils.WorldFromLocalPose(targetPose, relativePose);
                    var ray = new Ray(relGoal.position, (relGoal.position - targetPose.position).normalized);
                    var dist = Vector3.Dot(myPose.position - ray.origin, ray.direction.normalized);
                    var nearest = ray.GetPoint(dist);
                    goalPose = new Pose(nearest, relGoal.rotation);
                }
                    break;
            }

            return goalPose;
        }

        internal bool AddAlignmentForce(ref SolverFieldForceAccumulator forces, Pose myPose, Pose otherPose)
        {
            var goal = ProxyForceAlignmentDefinition.CalcGoalPose(myPose, otherPose, alignmentType, relativeFromTargetPose);

            var torque = (Quaternion.Inverse(myPose.rotation) * goal.rotation);
            torque = Quaternion.SlerpUnclamped(Quaternion.identity, torque, scaleForces.rotationScale * k_GlobalScaleAlignmentAngle);
            var force = (goal.position - myPose.position) * (scaleForces.movementScale * k_GlobalScaleAlignmentMotion);

            forces.AddForceAndTorque(force, torque, scaleForces);
            return true;
        }

        public float RatePoseMatch(Pose myPose, Pose otherPose)
        {
            var goal = GoalPose(myPose, otherPose);

            var errorRot = (myPose.rotation * Quaternion.Inverse(goal.rotation));
            Vector3 errorRotAxis; float errorRotAngle;
            errorRot.ToAngleAxis(out errorRotAngle, out errorRotAxis);
            errorRotAngle = Mathf.Clamp01(errorRotAngle / k_MaxAngle);

            var errorPos = Mathf.Clamp01((myPose.position - goal.position).magnitude / k_MaxDistance);

            var finalError = Mathf.Clamp01(errorPos * errorRotAngle);
            var goodness = 1.0f - finalError;
            return goodness;
        }
    }


}
