using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PartyMonsterScript : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;

    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    public Gamemanager gm;

    public Vector3 initialPosition; // Store the initial position
    public Quaternion initialRotation; // Store the initial rotation

    public CharacterMovement characterMovement;
    bool canHearPlayer;
    float maxRaycastDistance = 5f;

    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        navMeshAgent.speed = 0f;

        initialPosition = transform.position; // Store the initial position
        initialRotation = transform.rotation; // Store the initial rotation
    }

    // Update is called once per frame
    void Update()
    {
        NoticedPlayer();
        PlayerHiding();
    }

    void NoticedPlayer()
    {
        if (canSeePlayer == true)
        {
            navMeshAgent.SetDestination(playerRef.transform.position);
            navMeshAgent.speed = 5f;
        }
    }

    void PlayerHiding()
    {
        if (characterMovement != null && characterMovement.LostPlayer)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, initialPosition - transform.position, out hit, maxRaycastDistance, obstructionMask))
            {
                // If there is an obstacle, adjust the destination to avoid it
                Vector3 adjustedDestination = hit.point - (hit.normal * navMeshAgent.radius);
                navMeshAgent.SetDestination(adjustedDestination);
            }
            else
            {
                // If the path is clear, go back to the initial position
                navMeshAgent.SetDestination(initialPosition);

                // Check if the enemy is close to the initial position
                if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
                {
                    // Set the rotation to the initial rotation
                    transform.rotation = initialRotation;
                }
            }

            navMeshAgent.speed = 5f; // Adjust the speed as needed
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2 || characterMovement.walking)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }

                else
                {
                    canSeePlayer = false;
                }
            }

            else
            {
                canSeePlayer = false;
            }
        }

        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
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


