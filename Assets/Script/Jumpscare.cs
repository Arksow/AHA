using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject scareObject;
    public AudioSource audiosource;
    public AudioClip scare;



    // Start is called before the first frame update
    void Start()
    {
        scareObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scareObject.SetActive(true);
            audiosource.PlayOneShot(scare);
            Destroy(scareObject, 2);
            Destroy(gameObject, 3f);
        }
    }
}
