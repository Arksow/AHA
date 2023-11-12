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

    public AudioSource footStep;
    public AudioSource jumpSource;
    public AudioClip JumpSound;

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

        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravityValue);
            jumpSource.PlayOneShot(JumpSound,0.2f);
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
        
        if(x > 0 || z > 0 && !Input.GetKey(KeyCode.LeftShift)&&!Input.GetButton("Jump") && groundedPlayer)
        {
            footStep.enabled = true;
            footStep.pitch = 0.8f;
        }
        else if((x > 0 || z > 0)&& Input.GetKey(KeyCode.LeftShift) && !Input.GetButton("Jump") && groundedPlayer)
        {
            footStep.enabled = true;
            footStep.pitch = 1f;
        }
        else
        {
            footStep.enabled = false;
        }
        
    }
}
