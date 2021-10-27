using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.AI
{
    /// <summary>
    /// Support class for using NavMeshAgents in dynamically generated/updating environments common to AR
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    [MovedFrom("Unity.MARS")]
    public class MARSNavMeshAgent : MonoBehaviour
    {
        /// <summary>
        /// Implement this in sibling scripts to drive custom motion behavior when the NavAgent goes out of bounds
        /// </summary>
        public interface ICustomOutOfBoundsMotion
        {
            /// <summary>
            /// Function called by the MARSNavMeshAgent when the agent is detected as out of bounds
            /// </summary>
            /// <param name="start">Where the agent is currently located</param>
            /// <param name="destination">Where the agent should travel to to recover</param>
            void OutOfBoundsMotionBegin(Vector3 start, Vector3 destination);

            /// <summary>
            /// Set by the implementor when the out of bounds motion is complete
            /// </summary>
            bool Complete { get; set; }

            /// <summary>
            /// Set by the implementor where the agent should be while doing this custom motion
            /// </summary>
            Vector3 CustomPosition { get; }
        }

        /// <summary>
        /// Implement this in sibling scripts to drive custom motion behavior when the NavAgent needs to traverse directly
        /// </summary>
        public interface ICustomDynamicMotion
        {
            /// <summary>
            /// Function called by the MARSNavMeshAgent when the agent needs to do dynamic motion
            /// </summary>
            /// <param name="start">Where the agent is currently located</param>
            /// <param name="destination">Where the agent should travel to</param>
            void DynamicMotionBegin(Vector3 start, Vector3 destination);

            /// <summary>
            /// Set by the implementor when the dynamic motion is complete
            /// </summary>
            bool Complete { get; set; }

            /// <summary>
            /// Set by the implementor where the agent should be while doing this custom motion
            /// </summary>
            Vector3 CustomPosition { get; }
        }

        // How often to query for a valid NavMesh around the agent when it first starts up
        const float k_ValidStartInterval = 0.25f;

        // How far away from the expected position the NavMesh agent can end up before performing an out of bounds action
        const float k_PositionSyncRange = 0.1f;

        // An extra delta to use for stopping within range of a target, in case the NavMesh stopping distance is 0
        const float k_ManualSafeZone = 0.001f;

        // Distance to look for dynamic movement options as a function of an agent's speed
        const float k_DynamicLookAhead = .1f;

        /// <summary>
        /// Modes of operation for the NavMesh agent when the current NavMesh location or path is unavailable
        /// </summary>
        enum BackupMotion
        {
            /// <summary> Continue moving towards the last destination set </summary>
            Nothing,
            /// <summary> Move towards the nearest valid position after a short grace period </summary>
            MoveToValidPoint,
            /// <summary> Snap towards the nearest valid position after a short grace period </summary>
            SnapToValidPoint,
            /// <summary> Use event callbacks to drive motion  </summary>
            DriveWithEvent
        }

        /// <summary>
        /// The agent's current movement behavior
        /// </summary>
        enum AgentStatus
        {
            /// <summary> The agent has just spawned and is waiting for a valid position on the NavMesh </summary>
            LookingForValidStart,
            /// <summary> The agent is located and/or moving on the NavMesh normally </summary>
            Normal,
            /// <summary> The agent's position is no longer on a valid navmesh </summary>
            OutOfBounds,
            /// <summary> The agent is dynamically moving off the NavMesh to complete a partial path </summary>
            Dynamic,
        }

        [SerializeField]
        [Tooltip("How far to allow the start point to vary to attach to the NavMesh")]
        float m_StartPointRange = 1.0f;

        [SerializeField]
        [Tooltip("What to do if the surface the NavMesh is on suddenly is not available")]
        BackupMotion m_OutOfBoundsMotion = BackupMotion.MoveToValidPoint;

        [SerializeField]
        [Tooltip("What to do if the given NavMesh path cannot be completed")]
        BackupMotion m_DynamicMotion = BackupMotion.MoveToValidPoint;

        [SerializeField]
        [Tooltip("How long to wait before activating an out-of-bounds behavior.")]
        float m_OutOfBoundsGraceTime = 0.5f;

        NavMeshAgent m_Agent;
        Transform m_Transform;
        Vector3 m_CurrentPosition = Vector3.zero;
        float m_CurrentSpeed;

        Vector3 m_LastValidDestination = Vector3.zero;
        Vector3 m_LastValidPathEnd = Vector3.zero;

        AgentStatus m_AgentStatus = AgentStatus.LookingForValidStart;
        float m_ValidStartTimer;

        float m_GraceTimer;
        bool m_BackupMotionEventStarted;
        ICustomOutOfBoundsMotion m_BackupMotionProvider;

        Vector3 m_DynamicMotionStart;
        Vector3 m_DynamicMotionDestination;
        float m_DynamicMotionTimer;
        float m_DynamicMotionTime;
        ICustomDynamicMotion m_DynamicMotionProvider;

        /// <summary>
        /// Sets or updates the destination thus triggering the calculation for a new path
        /// You *must* call this, rather than the native NavMesh version, if you want dynamic path traversal
        /// </summary>
        /// <param name="target">The desired location, in world coordinates</param>
        /// <returns>True if the destination could be set</returns>
        public bool SetDestination(Vector3 target)
        {
            if (m_AgentStatus != AgentStatus.LookingForValidStart)
            {
                if (m_Agent.SetDestination(target))
                {
                    m_LastValidDestination = target;
                    return true;
                }
            }
            else
            {
                m_Transform.position = target;
            }

            return false;
        }

        void OnValidate()
        {
            SetupAgent();
        }

        void OnEnable()
        {
            SetupAgent();
        }

        void OnDisable()
        {
            ShutdownAgent();
        }

        /// <summary>
        /// Determines if the NavMesh is on a valid location for spawner and NavMesh operation
        /// and activates contingencies if that is not the case
        /// </summary>
        void Update()
        {
            m_CurrentPosition = m_Transform.position;

            switch (m_AgentStatus)
            {
                case AgentStatus.LookingForValidStart:
                    CheckForValidStartLocation();
                    break;
                case AgentStatus.Dynamic:
                    PerformDynamicMotion();
                    break;
                case AgentStatus.OutOfBounds:
                case AgentStatus.Normal:
                    CheckForBackupMotion();
                    if (m_AgentStatus == AgentStatus.Normal)
                    {
                        CheckForDynamicMotion();
                        MirrorAgent();
                    }
                    else
                        PerformBackupMotion();
                    break;
            }
        }

        /// <summary>
        /// Ensures the agent reference is set up, and the agent starts disabled until a valid NavMesh is detected
        /// </summary>
        void SetupAgent()
        {
            if (m_Agent == null)
            {
                m_Transform = transform;
                m_Agent = GetComponent<NavMeshAgent>();
            }

            m_Agent.enabled = false;
            m_Agent.updatePosition = false;
            m_AgentStatus = AgentStatus.LookingForValidStart;
            m_ValidStartTimer = k_ValidStartInterval;
            m_GraceTimer = m_OutOfBoundsGraceTime;

            if (m_OutOfBoundsMotion == BackupMotion.DriveWithEvent)
                m_BackupMotionProvider = GetComponentInChildren<ICustomOutOfBoundsMotion>(true);

            if (m_DynamicMotion == BackupMotion.DriveWithEvent)
                m_DynamicMotionProvider = GetComponentInChildren<ICustomDynamicMotion>(true);
        }

        /// <summary>
        /// Makes sure the NavMesh agent does not try to run without the support script backing it
        /// </summary>
        void ShutdownAgent()
        {
            if (m_Agent == null)
                return;

            m_Agent.enabled = false;
        }

        /// <summary>
        /// Pings the NavMesh for a valid start location, while waiting for AR NavMeshes to be discovered and built
        /// </summary>
        void CheckForValidStartLocation()
        {
            m_ValidStartTimer -= Time.deltaTime;
            if (m_ValidStartTimer > 0.0f)
            {
                return;
            }

            m_ValidStartTimer = k_ValidStartInterval;
            if (NavMesh.SamplePosition(m_CurrentPosition, out var hit, m_StartPointRange, m_Agent.areaMask))
            {
                m_CurrentPosition = hit.position;
                m_Transform.position = m_CurrentPosition;
                m_Agent.enabled = true;
                m_Agent.nextPosition = m_CurrentPosition;
                m_AgentStatus = AgentStatus.Normal;
            }
        }

        /// <summary>
        /// Sets up an agent to move from one world space location to another, independent of the actual NavMesh data involved
        /// </summary>
        /// <param name="startPosition">Where the motion begins</param>
        /// <param name="endPosition">Where the motion will complete</param>
        void SetupDynamicMotion(Vector3 startPosition, Vector3 endPosition)
        {
            m_AgentStatus = AgentStatus.Dynamic;
            m_DynamicMotionStart = startPosition;
            m_DynamicMotionDestination = endPosition;
            var speed = m_Agent.speed;
            m_DynamicMotionTime = (endPosition - startPosition).magnitude/speed;
            m_DynamicMotionTimer = m_DynamicMotionTime;
            m_CurrentSpeed = speed;
            m_LastValidPathEnd = m_LastValidDestination;
            if (m_DynamicMotion == BackupMotion.DriveWithEvent)
            {
                if (m_DynamicMotionProvider == null)
                {
                    Debug.LogWarning("Set to use script-driven dynamic motion but no ICustomDynamicMotionProvider available. Using snap action instead.");
                    m_DynamicMotion = BackupMotion.SnapToValidPoint;
                }
                else
                {
                    m_DynamicMotionProvider.Complete = false;
                    m_DynamicMotionProvider.DynamicMotionBegin(m_DynamicMotionStart, m_DynamicMotionDestination);
                }
            }
        }

        /// <summary>
        /// Moves the agent from one predefined location to another, independent of the actual NavMesh
        /// </summary>
        void PerformDynamicMotion()
        {
            switch (m_DynamicMotion)
            {
                case BackupMotion.Nothing:
                    Debug.LogError("This motion type should not be processed!");
                    return;
                case BackupMotion.MoveToValidPoint:
                    // Lerp to the end point before completing motion
                    m_DynamicMotionTimer -= Time.deltaTime;
                    m_CurrentPosition = Vector3.Lerp(m_DynamicMotionDestination, m_DynamicMotionStart, m_DynamicMotionTimer/m_DynamicMotionTime);
                    m_Transform.position = m_CurrentPosition;
                    if (m_DynamicMotionTimer > 0)
                        return;
                    break;
                case BackupMotion.DriveWithEvent:
                    // Wait until event tells this to move forward
                    if (m_DynamicMotionProvider != null)
                    {
                        m_CurrentPosition = m_DynamicMotionProvider.CustomPosition;
                        m_Transform.position = m_CurrentPosition;
                        if (!m_DynamicMotionProvider.Complete)
                            return;
                    }
                    break;
            }

            // When finished, look once again for a valid start point
            if (NavMesh.SamplePosition(m_DynamicMotionDestination, out var hit, k_PositionSyncRange, m_Agent.areaMask))
            {
                m_AgentStatus = AgentStatus.Normal;
                m_CurrentPosition = hit.position;
                m_Agent.Warp(m_CurrentPosition);
                MirrorAgent();
            }
            else
            {
                m_Transform.position = m_DynamicMotionDestination;
                m_AgentStatus = AgentStatus.OutOfBounds;
            }
            m_Agent.destination = m_LastValidDestination;
        }

        /// <summary>
        /// Determines if the agent has gotten in or out of sync with the NavMesh and changes behavior accordingly
        /// </summary>
        void CheckForBackupMotion()
        {
            // Determine if positions are out of sync
            var difference = (m_Agent.nextPosition - m_CurrentPosition).sqrMagnitude;

            // If the object has moved faster than it possibly should have, it is out of range
            // We have one exception to this rule, and that is during offmesh link traversal, which acts as teleportation
            var syncRange = m_Agent.speed * Time.deltaTime * 2.0f + k_PositionSyncRange;
            if (difference > (syncRange * syncRange) && !m_Agent.isOnOffMeshLink)
            {
                // See if the agent has gone out of bounds but could go back in-bounds
                if (NavMesh.SamplePosition(m_CurrentPosition, out var hit, syncRange, m_Agent.areaMask))
                {
                    m_GraceTimer = m_OutOfBoundsGraceTime;
                    m_AgentStatus = AgentStatus.Normal;
                    m_CurrentPosition = hit.position;
                    m_Agent.Warp(m_CurrentPosition);
                }
                else
                {
                    if (m_AgentStatus != AgentStatus.OutOfBounds)
                    {
                        Debug.LogWarning("External Nav Agent motion detected!");
                        m_AgentStatus = AgentStatus.OutOfBounds;
                        m_BackupMotionEventStarted = false;
                    }
                }
            }
            else
            {
                // If we were previously out of bounds, reset the flags and timers around the backup behavior
                if (m_AgentStatus == AgentStatus.OutOfBounds)
                {
                    m_GraceTimer = m_OutOfBoundsGraceTime;
                    m_AgentStatus = AgentStatus.Normal;
                }

                m_LastValidPathEnd = m_Agent.pathEndPosition;
                m_CurrentSpeed = m_Agent.velocity.magnitude;
            }
        }

        /// <summary>
        /// Checks if an agent needs to do a manual action to move to the desired destination
        /// </summary>
        void CheckForDynamicMotion()
        {
            // Only partial paths require dynamic behavior
            if (m_Agent.pathStatus != NavMeshPathStatus.PathPartial || m_DynamicMotion == BackupMotion.Nothing)
                return;

            // Transition to dynamic motion if we no longer have a path, or a surface at the target height is in range
            if (!m_Agent.hasPath)
            {
                var levelEdge = m_CurrentPosition;
                levelEdge.y = m_LastValidDestination.y;

                // Find the best location to step up/down along the path
                var dynamicDestination = NavMesh.Raycast(m_LastValidDestination, levelEdge, out var hit, m_Agent.areaMask) ? hit.position : levelEdge;

                SetupDynamicMotion(m_CurrentPosition, dynamicDestination);
            }
            else
            {
                // If traveling upwards, look forward along the path to see if there is a closer approach to
                // get to the NavMesh than just hitting the path end
                var toDestination = (m_LastValidDestination - m_CurrentPosition);
                if (toDestination.y > 0)
                {
                    toDestination.y = 0;
                    var distanceToDest = toDestination.magnitude;
                    var travelDistance = Mathf.Min(distanceToDest, m_Agent.speed * k_DynamicLookAhead);
                    var testPoint = m_CurrentPosition + (toDestination.normalized * travelDistance);
                    testPoint.y = m_LastValidDestination.y;

                    var sampleRange = m_Agent.speed * Time.deltaTime * 2.0f + k_PositionSyncRange;
                    if (NavMesh.SamplePosition(testPoint, out var hit, sampleRange, m_Agent.areaMask))
                    {
                        SetupDynamicMotion(m_CurrentPosition, hit.position);
                    }
                }
            }
        }

        /// <summary>
        /// Moves the agent in a scripted manner to recover to a valid NavMesh location
        /// </summary>
        void PerformBackupMotion()
        {
            switch (m_OutOfBoundsMotion)
            {
                case BackupMotion.Nothing:
                    MoveManual(m_CurrentPosition, m_LastValidPathEnd);
                    return;
                case BackupMotion.MoveToValidPoint:
                    // Continue moving to the destination, then to the new valid location
                    m_GraceTimer -= Time.deltaTime;
                    if (m_GraceTimer <= 0.0f && m_Agent.isOnNavMesh)
                        MoveManual(m_CurrentPosition, m_Agent.nextPosition);
                    else
                        MoveManual(m_CurrentPosition, m_LastValidPathEnd);

                    break;
                case BackupMotion.SnapToValidPoint:
                    // Continue moving to the destination, then warp to the new valid location
                    m_GraceTimer -= Time.deltaTime;
                    if (m_GraceTimer <= 0.0f && m_Agent.isOnNavMesh)
                        m_Transform.position = m_Agent.nextPosition;
                    else
                        MoveManual(m_CurrentPosition, m_LastValidPathEnd);
                    break;
                case BackupMotion.DriveWithEvent:
                    // Wait until the user has finished their custom motion, then recover to the given destination point
                    if (!m_BackupMotionEventStarted)
                    {
                        m_GraceTimer -= Time.deltaTime;

                        if (m_GraceTimer <= 0.0f)
                        {
                            if (m_OutOfBoundsMotion == BackupMotion.DriveWithEvent)
                            {
                                if (m_BackupMotionProvider == null)
                                {
                                    Debug.LogWarning("Set to use script-driven dynamic motion but no ICustomOutOfBoundsMotion available. Using snap action instead.");
                                    m_OutOfBoundsMotion = BackupMotion.SnapToValidPoint;
                                }
                                else
                                {
                                    m_BackupMotionEventStarted = true;
                                    m_BackupMotionProvider.Complete = false;
                                    m_BackupMotionProvider.OutOfBoundsMotionBegin(m_CurrentPosition, m_Agent.isOnNavMesh ? m_Agent.nextPosition : m_LastValidPathEnd);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (m_BackupMotionProvider.Complete)
                            MoveManual(m_CurrentPosition, m_Agent.nextPosition);
                        else
                        {
                            m_CurrentPosition = m_BackupMotionProvider.CustomPosition;
                            m_Transform.position = m_CurrentPosition;
                            m_Agent.nextPosition = m_CurrentPosition;
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// Ensures the internal state of the support script matches the NavMesh agent
        /// </summary>
        void MirrorAgent()
        {
            m_Transform.position = m_Agent.nextPosition;
        }

        /// <summary>
        /// Designed to continue moving the NavMesh agent seamless to a given location when the backing NavMesh
        /// is (temporarily) unavailable
        /// </summary>
        /// <param name="currentPosition">The current world space coordinates of the Agent's GameObject</param>
        /// <param name="destination">The current world space destination for the NavMesh agent</param>
        void MoveManual(Vector3 currentPosition, Vector3 destination)
        {
            // Very basic movement logic here
            // Accelerate towards destination, stop when getting close
            // Traverse *through* obstacles as this method is used as a recovery mechanism
            m_CurrentSpeed = Mathf.Min(m_Agent.speed, m_CurrentSpeed + (m_Agent.acceleration * Time.deltaTime));
            var toDestination = destination - currentPosition;
            var distance = Mathf.Min(toDestination.magnitude, m_CurrentSpeed * Time.deltaTime);
            if (toDestination.sqrMagnitude <= (m_Agent.stoppingDistance + k_ManualSafeZone))
            {
                m_CurrentSpeed = 0.0f;
                return;
            }

            var offset = toDestination.normalized * distance;
            currentPosition += offset;

            // Mirror the final position in both the transform and native NavMesh agent, so it can try to find a
            // valid nearby spot on the NavMesh
            m_Transform.position = currentPosition;
            m_Agent.nextPosition = currentPosition;
        }
    }
}
