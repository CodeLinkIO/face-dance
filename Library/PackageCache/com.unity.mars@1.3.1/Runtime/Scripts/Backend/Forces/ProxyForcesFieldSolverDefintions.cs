using System.Collections.Generic;
using Unity.Collections;
using Unity.MARS.Forces.ForceDefinitions;
using UnityEngine;

namespace Unity.MARS.Forces.ForceFieldSolving
{
    internal struct SolverFieldState
    {
        public ProxyForceFieldMotion worldMotion;
        public SolverFieldForceAccumulator forces;
        public SolverFieldErrorScore errorScore;
        public bool didUpdate;

        public void FrameReset(ProxyForceFieldMotion motion)
        {
            worldMotion = motion;
            forces.Reset(worldMotion);
            errorScore.Reset();
            didUpdate = false;
        }

        public static SolverFieldState Create(ProxyForceFieldMotion motion)
        {
            var f = new SolverFieldForceAccumulator();
            f.Reset(motion);
            return new SolverFieldState()
            {
                worldMotion = motion,
                forces = f,
            };
        }
    }


    internal struct SolverFieldForceAccumulator
    {
        public ProxyForceFieldMotion currentMotion;
        public Vector3 forceDir;
        public Vector3 forceDecollision;
        public Quaternion forceTorque;
        public float forceDirMagnitude;
        public int forceCount;

        public void Reset(ProxyForceFieldMotion motion)
        {
            currentMotion = motion;
            forceDir = Vector3.zero;
            forceTorque = Quaternion.identity;
            forceDecollision = Vector3.zero;
            forceCount = 0;
            forceDirMagnitude = 0.0f;
        }

        public const float k_ScaleAddForce = 1.0f;
        public const float k_ScaleAddTorque = 1.0f;
        public const float k_ScaleApplyForce = 1.0f;
        public const float k_ScaleRegionTorque = 4.0f;

        public const float k_DefaultConvergenceTime = 0.33f;
        public const float k_MaxUnitTimeStep = 1.0f;

        public const float k_DragCoeffecient = 0.75f;
        public const float k_DragCoeffecientScalarForRotation = 0.5f;

        public void AddDecollisionDirection(Vector3 worldVector)
        {
            forceDecollision += worldVector;
            forceCount++;
        }

        public void AddForceAtWorldPoint(Vector3 worldPoint, Vector3 worldVector)
        {
            forceDir += worldVector;
            forceDirMagnitude += worldVector.magnitude;

            Vector3 localOffset = worldPoint - currentMotion.location.position;

            if (!Mathf.Approximately(localOffset.magnitude, 0.0f) && !Mathf.Approximately(worldVector.magnitude, 0.0f))
            {
                var torqueAxis = -Vector3.Cross(worldVector, localOffset );
                var angle = Mathf.Clamp(Mathf.Asin(torqueAxis.magnitude) * Mathf.Rad2Deg * k_ScaleRegionTorque, -180.0f, 180.0f);
                var torqueRot = Quaternion.AngleAxis(angle, torqueAxis);
                forceTorque *= torqueRot;
            }

            forceCount++;
        }

        public void AddForceAndTorque(Vector3 force, Quaternion torque, ProxyAlignmentForceScaling scaling)
        {
            var finalForceDir = force * k_ScaleAddForce;
            forceDir += finalForceDir;
            forceDirMagnitude += finalForceDir.magnitude;
            forceTorque *= ScaleQuat(torque, k_ScaleAddTorque);
            forceCount++;
        }

        static Quaternion ScaleQuat(Quaternion quat, float scale)
        {
            return Quaternion.SlerpUnclamped( Quaternion.identity, quat, scale);
        }

        public void AddMotionDragForces(float drag = k_DragCoeffecient)
        {
            forceDir += (currentMotion.velocity.position * (-drag));
            forceTorque *= ScaleQuat(currentMotion.velocity.rotation, -drag * k_DragCoeffecientScalarForRotation);
        }

        public ProxyForceFieldMotion ApplyForceToMotion(float rawTimeDelta)
        {
            var ans = currentMotion;
            if (forceCount > 0)
            {
                var clampedTimeDelta = Mathf.Min((rawTimeDelta / k_DefaultConvergenceTime), k_MaxUnitTimeStep);

                var accelDir = forceDir;
                var accelTorque = forceTorque;

                ans.location.position += (ans.velocity.position * clampedTimeDelta)
                    + (accelDir * (0.5f * clampedTimeDelta * clampedTimeDelta))
                    + (forceDecollision * clampedTimeDelta);
                ans.location.rotation *= ScaleQuat(ans.velocity.rotation, clampedTimeDelta) * ScaleQuat(accelTorque, 0.5f * clampedTimeDelta * clampedTimeDelta);
                ans.velocity.position += accelDir * clampedTimeDelta;
                ans.velocity.rotation *= ScaleQuat(accelTorque, clampedTimeDelta);

                ans.velocity.rotation.ToAngleAxis(out float angle, out Vector3 axis);
                float maxRotationalVelocity = 10.0f;
                if (angle >= maxRotationalVelocity)
                {
                    ans.velocity.rotation = Quaternion.AngleAxis(maxRotationalVelocity, axis);
                }
            }
            return ans;
        }

        public float ScoreErrorMagnitude()
        {
            const float unitErrorPos = 1.0f; // one meter
            const float unitErrorRot = 180.0f; // side angle

            if (forceCount == 0) return 0.0f;

            var poseError = forceDir.magnitude / unitErrorPos;

            float rotAngle; Vector3 rotAxis;
            forceTorque.ToAngleAxis(out rotAngle, out rotAxis);
            var rotError = (Mathf.Abs(rotAngle) / unitErrorRot);

            return (poseError + rotError);

        }
    }

    internal struct SolverFieldErrorScore
    {
        public float scoreErrorTotal;

        public int scoreFatalErrorCount;
        public float scoreErrorForces;
        public int scoreErrorForcesCount;
        public float scoreErrorRegion;
        public int scoreErrorRegionCount;

        public void UpdateFinalScore()
        {
            scoreErrorTotal = CalcuateFinalScore();
        }

        public bool DidPass
        {
            get { return (scoreErrorTotal < 1.0f) && (scoreFatalErrorCount == 0); }
        }

        public float CalcuateFinalScore()
        {
            var ps = this;
            const float regionDistanceUnit = 1.0f;
            float regionError = scoreErrorRegion / regionDistanceUnit;
            if (scoreErrorRegionCount > 0)
            {
                regionError /= (float)scoreErrorRegionCount;
            }
            float forceError = scoreErrorForces; // already averaged
            float error = regionError + forceError;

            if (scoreFatalErrorCount > 0)
            {
                error += (float)scoreFatalErrorCount; // failed
            }
            return error;
        }

        public void Reset()
        {
            scoreErrorTotal = 0.0f;
            scoreErrorForces = 0.0f;
            scoreErrorForcesCount = 0;
            scoreErrorRegion = 0.0f;
            scoreErrorRegionCount = 0;
            scoreFatalErrorCount = 0;
        }
    }



}
