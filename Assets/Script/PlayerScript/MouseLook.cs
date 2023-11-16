using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform player;
    float xRotation;

    public float vibrationIntensity = 0.1f;
    public float vibrationSpeed = 5f;

    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        if(Input.GetAxis("Horizontal")!=0|| Input.GetAxis("Vertical") != 0)
        {
            float vibrationX = Mathf.PerlinNoise(Time.time * vibrationSpeed, 0) * 2 - 1;
            float vibrationY = Mathf.PerlinNoise(0, Time.time * vibrationSpeed) * 2 - 1;

            transform.localRotation *= Quaternion.Euler(vibrationX * vibrationIntensity, vibrationY * vibrationIntensity, 0);
        }
    }
}
