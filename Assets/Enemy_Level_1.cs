using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Level_1 : MonoBehaviour
{
    public MouseLook mouseLook;
    public NavMeshAgent agent;
    public GameObject Player;
    public Animator animator;

    private void Update()
    {
        if (mouseLook.enemyLookAtMe)
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


