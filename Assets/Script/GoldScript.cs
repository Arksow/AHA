using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScript : MonoBehaviour
{
    public Gamemanager gm;
    private void Start()
    {
        gm = FindObjectOfType<Gamemanager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            gm.isWin = true;
        }
    }
}
