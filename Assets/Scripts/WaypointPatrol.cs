using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent ghostNavMeshAgent;
    [SerializeField]
    private Transform[] ghostWaypoints;

    private int m_CurrentWaypointIndex = 0;

    void Start()
    {
        ghostNavMeshAgent.SetDestination(ghostWaypoints[0].position);
    }

    void Update()
    {
        if (ghostNavMeshAgent.remainingDistance < ghostNavMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % ghostWaypoints.Length;
            ghostNavMeshAgent.SetDestination(ghostWaypoints[m_CurrentWaypointIndex].position);
        }
    }
}
