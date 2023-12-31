﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip scare;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audiosource.PlayOneShot(scare);
            
            Destroy(gameObject, 3f);
        }
    }
}
