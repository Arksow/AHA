using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Interact : MonoBehaviour
{
    public Camera mainCamera;
    public RaycastHit hit;
    public Lock lockScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward,out hit,4f))
            {
                Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 100f, Color.yellow);
                Button_Script button_Script = hit.collider.GetComponent<Button_Script>();
                if (hit.collider.gameObject.tag == "Button")
                {
                    lockScript.SetInputValue(button_Script.number);
                }
            }
        }
    }
}
