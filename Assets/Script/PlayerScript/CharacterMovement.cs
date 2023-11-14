using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CharacterMovement : MonoBehaviour
{
    public Camera PlayerCam;
    public CharacterController controller;
    [SerializeField]private Vector3 playerVelocity;
    [SerializeField]private bool groundedPlayer;
    [SerializeField]float speed;
    public float playerWalkSpeed;
    public float playerRunSpeed;
    public float playerCrouchSpeed;
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
        PlayerCam = GetComponentInChildren<Camera>();

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
            jumpSource.PlayOneShot(JumpSound,0.1f);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift)&&groundedPlayer&&!Input.GetKey(KeyCode.C))
        {
            PlayerCam.transform.localPosition = new Vector3(0, 0.5f, 0);
            speed = playerRunSpeed;
            controller.height = 1.8f;
            controller.center = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.C) && groundedPlayer)
        {
            PlayerCam.transform.localPosition = new Vector3(0, 0.25f, 0);
            speed = playerCrouchSpeed;
            controller.height = 1.2f;
            controller.center = new Vector3(0, -0.3f, 0);
        }       
        else
        {
            PlayerCam.transform.localPosition = new Vector3(0, 0.5f, 0);
            
            controller.height = 1.8f;
            controller.center = new Vector3(0, 0, 0);
            speed = playerWalkSpeed;
        }
        
        if((Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetButton("Jump") && groundedPlayer)
        {
            footStep.enabled = true;
            footStep.pitch = 0.8f;
        }
        else if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift) && !Input.GetButton("Jump") && groundedPlayer)
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
