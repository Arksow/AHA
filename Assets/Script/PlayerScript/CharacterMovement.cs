using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField]private Vector3 playerVelocity;
    [SerializeField]private bool groundedPlayer;
    [SerializeField]float speed;
    public float playerWalkSpeed;
    public float playerRunSpeed;
    public float jumpHeight;
    public float gravityValue;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    private void Start()
    {
       

    }

    void Update()
    {
        groundedPlayer = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        if (playerVelocity.y < 0 && groundedPlayer)
        {
            playerVelocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift)&&groundedPlayer)
        {
            speed = playerRunSpeed;
        }
        else
        {
            speed = playerWalkSpeed;
        }
        
        
        
    }
}
