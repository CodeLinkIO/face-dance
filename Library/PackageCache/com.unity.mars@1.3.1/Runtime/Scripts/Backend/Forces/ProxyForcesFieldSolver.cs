using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Forces.ForceDefinitions;
using UnityEngine;
using Unity.MARS.Forces.ForceFieldSolving;

namespace Unity.MARS.Forces
{
    internal class ProxyForcesFieldSolver : System.IDisposable
    {
        Dictionary<ProxyForceFieldId, ProxyForceField> m_ProxyDef = new Dictionary<ProxyForceFieldId, ProxyForceField>();
        Dictionary<ProxyForceFieldId, ProxyForceFieldMotion> m_ProxyMotions = new Dictionary<ProxyForceFieldId, ProxyForceFieldMotion>();
        Dictionary<ProxyForceFieldId, SolverFieldState> m_ProxyStates = new Dictionary<ProxyForceFieldId, SolverFieldState>();
        ProxyForceFieldPrimitive.DistanceSample[][] m_BestSampleByPointByResponce = null;
        bool m_ShowForcesAsLines = false;

        const int k_DefaultStepCount = 35;
        const float k_DefaultStepDuration = 0.31f;

        public bool ShowForcesAsLines
        {
            get { return m_ShowForcesAsLines; }
            set
            {
#if UNITY_EDITOR
                m_ShowForcesAsLines = value;
#else
                m_ShowForcesAsLines = false;
#endif
            }
        }

        public bool HasProxyId(ProxyForceFieldId id)
        {
            if (m_ProxyDef.ContainsKey(id))
            {
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            foreach (var kv in m_ProxyDef)
            {
                kv.Value.Dispose();
            }
            m_ProxyDef.Clear();
            m_ProxyMotions.Clear();
            m_ProxyStates.Clear();
        }

        public int DEBUG_NumProxies()
        {
            return m_ProxyDef.Count;
        }

        public void UpdateFieldPoseOnly(ProxyForceFieldId id, Pose worldPose)
        {
            ProxyForceFieldMotion motion;
            if (m_ProxyMotions.ContainsKey(id))
            {
                motion = m_ProxyMotions[id];
                motion.location = worldPose;
            }
            else
            {
                motion = new ProxyForceFieldMotion(worldPose, Pose.identity);
            }
            m_ProxyMotions[id] = motion;
        }

        internal void UpdateFieldProxy(ProxyForceField def, Pose pose)
        {
            var id = def.proxyId;

            ProxyForceField cur = default;
            if (m_ProxyDef.ContainsKey(id))
            {
                cur = m_ProxyDef[id];
            }
            cur.CloneFrom(def);
            m_ProxyDef[id] = cur;
            UpdateFieldPoseOnly(id, pose);
        }

        public Pose UpdateProxyMotion(ProxyForceFieldId id, ProxyForceFieldMotion askedMotion)
        {
            var def = m_ProxyDef[id];
            var oldPose = m_ProxyMotions[id];

            var newPose = def.allowedMotion.TrimMotionUpdate(oldPose, askedMotion);

            m_ProxyMotions[id] = newPose;

            return newPose.location;
        }

        public void Clear()
        {
            foreach (var od in m_ProxyDef)
            {
                od.Value.Dispose();
            }

            m_ProxyDef.Clear();
            m_ProxyMotions.Clear();
            m_ProxyStates.Clear();
        }

        public ProxyForceFieldMotion GetProxyMotion(ProxyForceFieldId id)
        {
            return m_ProxyMotions[id];
        }


        public void CloneFrom(ProxyForcesFieldSolver other)
        {
            foreach (var kv in other.m_ProxyDef)
            {
                var motion = other.GetProxyMotion(kv.Key);
                UpdateFieldProxy(kv.Value, motion.location);
                UpdateProxyMotion(kv.Value.proxyId, motion);
            }
        }

        internal SolverFieldErrorScore ScorePose(ProxyForceFieldId id, Pose pose)
        {
            var state = new SolverFieldState();
            var motion = new ProxyForceFieldMotion(pose, Pose.identity);
            state.FrameReset(motion);

            var oldPose = m_ProxyMotions[id];
            m_ProxyMotions[id] = motion;

            var def = m_ProxyDef[id];
            def.isActive = true;
            CalculateForces(ref state, def, id);

            m_ProxyMotions[id] = oldPose;

            state.errorScore.UpdateFinalScore();
            return state.errorScore;
        }

        ProxyForceFieldPrimitive.DistanceSample[][] EnsureAndClearCachedResponces(int numPoints)
        {
            var maxPoints = 64;
            var maxResponces = (int)ProxyForceRegionResponce.COUNT_TYPES;
            Debug.Assert(numPoints < maxPoints);
            if (m_BestSampleByPointByResponce == null)
            {
                m_BestSampleByPointByResponce = new ProxyForceFieldPrimitive.DistanceSample[maxPoints][];
                for (var pi = 0; pi < maxPoints; pi++)
                {
                    m_BestSampleByPointByResponce[pi] = new ProxyForceFieldPrimitive.DistanceSample[maxResponces];
                }
            }

            for (var pi=0; pi< numPoints; pi++)
            {
                m_BestSampleByPointByResponce[pi] = new ProxyForceFieldPrimitive.DistanceSample[maxResponces];
                for (var ri=0; ri<maxResponces; ri++)
                {
                    m_BestSampleByPointByResponce[pi][ri] = default;
                }
            }

            return m_BestSampleByPointByResponce;
        }

        bool CalculateForces(ref SolverFieldState state, ProxyForceField def, ProxyForceFieldId pi)
        {
            if ((!def.isActive) || (!def.allowedMotion.IsMoving()))
            {
                return false;
            }

            //Debug.Log("Calculating forces...");

            var proxyPose = state.worldMotion;
            var didUpdate = false;

            state.FrameReset(proxyPose);

            foreach (var alignmentForce in def.alignments)
            {
                if ((!alignmentForce.isActive) || (!alignmentForce.targetProxyId.IsValid)) continue;

                var hasTarget = (m_ProxyDef.ContainsKey(alignmentForce.targetProxyId));
                if (hasTarget)
                {
                    var targetDef = m_ProxyDef[alignmentForce.targetProxyId];
                    if ((!targetDef.isActive) || targetDef.isNotTracking)
                    {
                        hasTarget = false;
                    }
                }
                if (hasTarget)
                {
                    var targetPose = m_ProxyMotions[alignmentForce.targetProxyId].location;

                    var appliedForce = alignmentForce.alignmentDefinition.AddAlignmentForce(ref state.forces, proxyPose.location, targetPose);
                    if (appliedForce)
                    {
                        didUpdate = true;
                        state.errorScore.scoreErrorForces += alignmentForce.alignmentDefinition.RatePoseMatch(proxyPose.location, targetPose);
                        state.errorScore.scoreErrorForcesCount++;
                    }
                }
                else
                {
                    state.errorScore.scoreFatalErrorCount++; // fail, item is not trackable
                }
            }

            var keys = m_ProxyDef.Keys;

            foreach (var region in def.regions)
            {
                if ((!region.isActive) || (region.regionDefinition.regionType == ProxyRegionForceType.None))
                {
                    continue;
                }

                // for each point in region:
                var unitPnts = ProxyForceFieldPrimitive.UnitSamplesPointsForType(region.regionDefinition.shapePrimitive.primitiveType);
                var dUnitPnt = 1.0f / ((float)unitPnts.Length);

                var regionPose = region.proxyRelativePose.GetTransformedBy(proxyPose.location);
                var regionPrim = new ProxyForceFieldPrimitivePosed(region.regionDefinition.shapePrimitive, regionPose);
                var regionAttractorRequired = ((region.regionDefinition.regionType == ProxyRegionForceType.TowardsOccupiedEdge)
                    || (region.regionDefinition.regionType == ProxyRegionForceType.TowardsOccupiedSpace));
                var regionAttractorFound = false;

                var responcesByUnitByResponce = EnsureAndClearCachedResponces(unitPnts.Length);

                foreach (var otherProxy in m_ProxyDef)
                {
                    if (otherProxy.Value.proxyId.Equals(def.proxyId)) continue; // same proxy, ignore self collision
                    if (!otherProxy.Value.isActive || (otherProxy.Value.regions == null))
                        continue;

                    var otherProxyPose = m_ProxyMotions[otherProxy.Key];
                    foreach (var otherRegion in otherProxy.Value.regions)
                    {
                        if (!otherRegion.isActive) continue;

                        if ((region.requireOtherId != MarsTrackableId.InvalidId) &&
                            (region.requireOtherId != otherRegion.trackableId))
                            continue;

                        var responce = region.regionDefinition.GetResponceTypeToOtherRegion(otherRegion.regionDefinition);
                        if (responce == ProxyForceRegionResponce.Nothing)
                        {
                            // done
                        }
                        else
                        {
                            var otherRegionPose = otherRegion.proxyRelativePose.GetTransformedBy(otherProxyPose.location);
                            var otherRegionPrim = new ProxyForceFieldPrimitivePosed(otherRegion.regionDefinition.shapePrimitive, otherRegionPose);

                            var worthTest = false;
                            if (responce == ProxyForceRegionResponce.StayOutOf)
                            {
                                if (regionPrim.EstimateCollision(otherRegionPrim))
                                {
                                    worthTest = true;

                                    if (regionPrim.TryDecollisionSample(otherRegionPrim, out Vector3 decolMotion))
                                    {
                                        var moveVector = decolMotion * otherRegion.regionDefinition.fieldWeightScalar;

                                        state.forces.AddDecollisionDirection(moveVector);
                                        state.errorScore.scoreErrorRegion += decolMotion.magnitude;
                                        state.errorScore.scoreErrorRegionCount++;
                                        didUpdate = true;

                                        worthTest = false; // already done
                                    }
                                }
                            }
                            else if ((responce == ProxyForceRegionResponce.AlignWithEdge) || (responce == ProxyForceRegionResponce.AlignWithVolume))
                            {
                                if (regionPrim.EstimateAttraction(otherRegionPrim))
                                {
                                    worthTest = true;
                                }
                            }

                            if (worthTest)
                            {
                                var pointIndex = -1;
                                foreach (var unitPnt in unitPnts)
                                {
                                    pointIndex++;
                                    var refUnitPoint = regionPrim.Primitive.UnitFromReferenceVector(unitPnt);
                                    var worldPoint = regionPrim.WorldFromUnitPoint(refUnitPoint * 0.99f);

                                    var regionSample = regionPrim.SampleDistanceFieldWorld(worldPoint, ProxyForceFieldPrimitive.ShapeSample.Fill);

                                    var otherSample = otherRegionPrim.SampleDistanceFieldWorld(worldPoint, (responce == ProxyForceRegionResponce.AlignWithEdge) ? ProxyForceFieldPrimitive.ShapeSample.Edge : ProxyForceFieldPrimitive.ShapeSample.Fill);

                                    otherSample = otherSample.AdjustedForResponce(responce, worldPoint, regionPose);
                                    otherSample.RegionToSurface = regionSample.ToSurface;
                                    otherSample.SampleWeight = otherRegion.regionDefinition.fieldWeightScalar;

                                    if (otherSample.HasSample)
                                    {
                                        if (regionAttractorRequired) regionAttractorFound = true;

                                        //Debug.Log("Responce=" + responce);
                                        //Debug.DrawLine(worldPoint, worldPoint + (otherSample.ToSurface * 1.0f), Color.white);

                                        var s = responcesByUnitByResponce[pointIndex][(int)responce];
                                        var t = s.CombinedWith(otherSample);
                                        responcesByUnitByResponce[pointIndex][(int)responce] = t;
                                    }

                                    // end of a point
                                }
                            }
                            // end of region to region test
                        }
                    } // end of other region
                } // end of other proxy

                // Now apply values from all points in the region:
                if (regionAttractorRequired && !regionAttractorFound)
                {
                    state.errorScore.scoreFatalErrorCount++; // was missing an attractor!
                }
                for (int pointIndex=0; pointIndex < unitPnts.Length; pointIndex++)
                {
                    for (var ri=0; ri<(int)ProxyForceRegionResponce.COUNT_TYPES; ri++)
                    {
                        var s = responcesByUnitByResponce[pointIndex][ri];
                        if (s.HasSample)
                        {
                            var responce = (ProxyForceRegionResponce)ri;
                            var responceWeight = ProxyForceRegionDefintion.GetResponceWeight(responce);

                            var cw = s.SampleWeight * dUnitPnt * responceWeight;
                            var qb = s.ToSurface;//NOTE: we are not taking the SDF distance which would be: s.ToSurface - s.RegionToSurface;
                            var qw = qb * cw;

                            if (ShowForcesAsLines)
                            {
                                Debug.DrawLine(s.WorldPoint, s.WorldPoint + s.ToSurface, Color.grey);
                                Debug.DrawLine(s.WorldPoint, s.WorldPoint + qw, Color.white);
                            }

                            state.forces.AddForceAtWorldPoint(s.WorldPoint, qw);
                            didUpdate = true;

                            state.errorScore.scoreErrorRegion += s.Distance;
                            state.errorScore.scoreErrorRegionCount++;
                        }
                    }
                }

            }

            state.didUpdate = didUpdate;
            return didUpdate;
        }

        public ProxyForceFieldMotion IterateSingleDefault(ProxyForceFieldId id, bool isSingleStep, float timeDelta)
        {
            var numSteps = isSingleStep ? 1 : ProxyForcesFieldSolver.k_DefaultStepCount;
            var stepTimeDelta = isSingleStep ? timeDelta : ProxyForcesFieldSolver.k_DefaultStepDuration;
            IterateSingle(id, numSteps, stepTimeDelta);

            return GetProxyMotion(id);
        }

        public bool IterateSingle(ProxyForceFieldId id, int stepCount, float initialTimeDelta)
        {
            var didFinalUpdate = false;

            for (var si = 0; si < stepCount; si++)
            {
                var didFrameUpdate = false;

                {
                    var def = m_ProxyDef[id];
                    var proxyPose = m_ProxyMotions[id];
                    var state = SolverFieldState.Create(proxyPose);

                    if (CalculateForces(ref state, def, id))
                    {
                        state.didUpdate = true;
                        didFrameUpdate = true;
                        didFinalUpdate = true;
                    }

                    m_ProxyStates[id] = state;
                }

                if (!didFrameUpdate) return didFinalUpdate;

                {
                    var state = m_ProxyStates[id];
                    if (state.didUpdate)
                    {
                        state.forces.AddMotionDragForces();

                        float timeDelta = initialTimeDelta;
                        if (stepCount > 1)
                        {
                            // slowly decrease the time delta:
                            timeDelta *= Mathf.Pow(1.0f - (((float)si) / ((float)(stepCount + 1))), 0.5f);
                        }
                        var forcedPose = state.forces.ApplyForceToMotion(timeDelta);
                        var oldPose = state.worldMotion;

                        bool isDisableForceApply = false;
                        if (isDisableForceApply)
                        {
                            forcedPose = oldPose;
                        }

                        var def = m_ProxyDef[id];
                        var newPose = def.allowedMotion.TrimMotionUpdate(oldPose, forcedPose);

                        if (ShowForcesAsLines)
                        {
                            Debug.DrawLine(oldPose.location.position, newPose.location.position, Color.green);
                        }

                        m_ProxyMotions[id] = newPose;
                    }
                }
            }

            return didFinalUpdate;
        }

        public bool IterateAll(int stepCount, float timeDelta)
        {
            var didFinalUpdate = false;
            var keys = m_ProxyDef.Keys; // TODO: check that this doesn't cause any allocations

            for (var si=0; si<stepCount; si++)
            {
                var didFrameUpdate = false;

                foreach (var pi in keys)
                {
                    var def = m_ProxyDef[pi];
                    var proxyPose = m_ProxyMotions[pi];
                    var state = SolverFieldState.Create(proxyPose);

                    if (CalculateForces(ref state, def, pi))
                    {
                        state.didUpdate = true;
                        didFrameUpdate = true;
                        didFinalUpdate = true;
                    }

                    m_ProxyStates[pi] = state;
                }

                if (!didFrameUpdate) return didFinalUpdate;

                foreach (var pi in keys)
                {
                    var state = m_ProxyStates[pi];
                    if (state.didUpdate)
                    {
                        state.forces.AddMotionDragForces();
                        var forcedPose = state.forces.ApplyForceToMotion(timeDelta);
                        var oldPose = state.worldMotion;

                        var def = m_ProxyDef[pi];
                        var newPose = def.allowedMotion.TrimMotionUpdate(oldPose, forcedPose);

                        m_ProxyMotions[pi] = newPose;
                    }
                }
            }

            return didFinalUpdate;
        }
    }


}
