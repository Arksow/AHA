using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BacteriaEnemyScript : MonoBehaviour
{
    public GameObject player;
    public float chaseTime = 20f;

    private NavMeshAgent navMeshAgent;
    private bool isChasing = false;
    private float elapsedTime = 0f;

    public Gamemanager gm;
    [SerializeField] Animator animator;
    [SerializeField] GameObject Wall;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        navMeshAgent.destination = transform.position;
        gm = FindObjectOfType<Gamemanager>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= chaseTime && !isChasing)
        {
            StartChasing();
            Destroy(Wall);
        }

        if (isChasing)
        {
            ChasePlayer();
            animator.SetBool("Chasing", true);
        }
    }

    void StartChasing()
    {
        isChasing = true;

        navMeshAgent.destination = player.transform.position;

    }

    void ChasePlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("DIE");
            gm.isDie = true;
        }
    }
}
