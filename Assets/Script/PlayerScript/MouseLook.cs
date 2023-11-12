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

    public Camera enemyCamera;
    public bool enemyLookAtMe;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = enemyCamera.WorldToViewportPoint(transform.position);
        enemyLookAtMe = screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1 && screenPoint.z > 1;

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
