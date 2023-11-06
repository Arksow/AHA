using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Camera playerCamera;
    public Transform player;
    public NavMeshAgent navMeshAgent;
    [SerializeField] private bool playerLookAtMe;

    public float range;
    public Transform centerPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //For camera Player camera looking on enemy
        //Vector3 screenPoint = playerCamera.WorldToViewportPoint(transform.position);

        //playerLookAtMe = screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1 && screenPoint.z > 1;

        //if (playerLookAtMe)
        //{
        //    navMeshAgent.isStopped = true;
        //}
        //else
        //{
        //    navMeshAgent.isStopped = false;

        //    Vector3 moveDirectionToPlayer = (player.position - transform.position).normalized;

        //    navMeshAgent.SetDestination(player.position);
        //}
        //------------------------------------------

        //For enemy to patrol when he cant find the player
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            Vector3 point;
            if(RandomPoint(centerPoint.position,range,out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1f);
                navMeshAgent.SetDestination(point);
            }
        }
    }

    private bool RandomPoint(Vector3 center, float range,out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;

        NavMeshHit hit;

        if(NavMesh.SamplePosition(randomPoint,out hit, 1f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result= Vector3.zero;
        return false;
    }
}
