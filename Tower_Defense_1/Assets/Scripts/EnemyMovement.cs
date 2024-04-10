using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    public NavMeshAgent navMeshAgent;
    
    private Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = enemy.startSpeed;
    }

    void Update()
    {
        // Vector3 dir = target.GetComponent<Transform>().position - GetComponent<Transform>().position;
        // transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        navMeshAgent.SetDestination(target.position);
        float dist;
        if(navMeshAgent.pathPending)
        {
            dist = Vector3.Distance(transform.position, target.position);
        }
        else
        {
            dist = navMeshAgent.remainingDistance;
        }
         if (dist <= 0.2f)
         {
             Debug.Log("ARRIVED");
             EndPath();
         }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Wavespawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
