using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Level_1 : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public GameObject Player;
    public Animator animator;

    public Camera enemyCamera;
    public bool enemyLookAtMe;
    private void Start()
    {
        Player = GameObject.Find("Player");
    }
    private void Update()
    {
        Vector3 screenPoint = enemyCamera.WorldToViewportPoint(Player.transform.position);
        enemyLookAtMe = screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1 && screenPoint.z > 1;

        if (enemyLookAtMe)
        {
            Vector3 moveDirectionToPlayer = (Player.transform.position - transform.position).normalized;
            agent.SetDestination(Player.transform.position);
            animator.SetBool("Run", true);
        }
        else
        {
            if (agent.velocity.sqrMagnitude < 0.01f)
            {
                animator.SetBool("Run", false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("DIE");

        }
    }
}


