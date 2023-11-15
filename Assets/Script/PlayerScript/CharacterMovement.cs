using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public Camera PlayerCam;
    public CharacterController controller;
    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] float speed;
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

    bool canStand;
    [SerializeField] GameObject HeadPos;
    public bool walking;
    bool crouched;
    public bool LostPlayer;

    public Text clue;
    [SerializeField] GameObject SettingPanel;
    void Start()
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

        if (Physics.Raycast(HeadPos.transform.position, Vector3.up, 0.5f))
        {
            canStand = false;
        }
        else
        {
            canStand = true;
        }

        if (Input.GetKey(KeyCode.LeftShift) && groundedPlayer && !Input.GetKey(KeyCode.C) && canStand)
            {
            PlayerCam.transform.localPosition = new Vector3(0, 0.5f, 0);
            HeadPos.transform.localPosition = new Vector3(0, 0.9f, 0);
            speed = playerRunSpeed;
            controller.height = 2f;
            controller.center = new Vector3(0, 0, 0);
            crouched = false;
        }
        else if (Input.GetKey(KeyCode.C) && groundedPlayer)
        {
            HeadPos.transform.localPosition = new Vector3(0, 0.3f, 0);
            PlayerCam.transform.localPosition = new Vector3(0, 0.25f, 0);
            speed = playerCrouchSpeed;
            controller.height = 0.5f;
            controller.center = new Vector3(0, -0.3f, 0);
            crouched = true;
        }
        else
        {
            if (canStand)
            {
                PlayerCam.transform.localPosition = new Vector3(0, 0.5f, 0);
                HeadPos.transform.localPosition = new Vector3(0, 0.9f, 0);
                controller.height = 2f;
                controller.center = new Vector3(0, 0, 0);
                speed = playerWalkSpeed;
                crouched = false;
            }
        }

        if ((Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetButton("Jump") && groundedPlayer)
        {
            footStep.enabled = true;
            footStep.pitch = 0.8f;

            if (!crouched)
            {
                walking = true;
            }
        }
        else if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift) && !Input.GetButton("Jump") && groundedPlayer)
        {
            footStep.enabled = true;
            footStep.pitch = 1f;

            if (!crouched)
            {
                walking = true;
            }
        }
        else 
        {
            footStep.enabled = false;
            walking = false;
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            PauseGame();

        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SettingPanel.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HidingSpot")
        {
            LostPlayer = true;
        }

        if (other.gameObject.tag == "Info" && SceneManager.GetActiveScene().name == "Lvl2")
        {
            clue.text = "The number must be important. I need to remember it.";
            Destroy(other);
            StartCoroutine("ClueCoroutine");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HidingSpot")
        {
            LostPlayer = false;
        }
    }

    IEnumerator ClueCoroutine()
    {
        yield return new WaitForSeconds(5f);
        clue.text = "";
    }
}
