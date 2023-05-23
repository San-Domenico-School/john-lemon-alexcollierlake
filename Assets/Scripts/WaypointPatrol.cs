using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is attached to the  move the Ghosts between an 
 * assigned groups of waypoints.
 * 
 * Alexandra Collier-Lake
 * 05/23/2023
 * 
 */
public class WaypointPatrol : MonoBehaviour
{
    [SerializeField] private UnityEngine.AI.NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] waypoints;
    private int currentWaypointIndex;


    // Sets the initial destination of the Ghost
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Moves the Ghosts between destinations
    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}
