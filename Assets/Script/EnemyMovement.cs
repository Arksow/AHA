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
    public LayerMask obstacleLayer;

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
        for (int i = 0; i < 30; i++)
        {


            Vector3 randomPoint = center + Random.insideUnitSphere * range;

            NavMeshHit hit;

            Vector3 samplePosition = randomPoint;

            if(Physics.Raycast(samplePosition + Vector3.up * 2, Vector3.down, out RaycastHit hitInfo, 5f, obstacleLayer))
            {
                continue;
            }
            if (NavMesh.SamplePosition(samplePosition, out hit, 1f, NavMesh.AllAreas))
            {
                result = hit.position;
                Debug.DrawRay(hit.position, Vector3.up * 10, Color.green, 1f);
                return true;
            }
        }

        result= Vector3.zero;
        return false;
    }
}
