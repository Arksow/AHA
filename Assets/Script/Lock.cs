using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Lock : MonoBehaviour
{
    int firstNum;
    int seccondNum;
    int thirdNum;
    int wholeNum;
    int[] lockNum = new int[3];
    int[] inputLockNum = new int[3];

    public TMP_Text inputLockText;
    // Start is called before the first frame update
    void Start()
    {
        lockNum[0] = Random.Range(1, 9);
        lockNum[1] = Random.Range(0, 9);
        lockNum[2] = Random.Range(0, 9);


    }

    // Update is called once per frame
    void Update()
    {
        firstNum = lockNum[0];
        seccondNum = lockNum[1];
        thirdNum = lockNum[2];

        wholeNum = firstNum * 100 + seccondNum * 10 + thirdNum;
        if (inputLockText.text == wholeNum.ToString())
        {
            inputLockText.text = "Win";
        }
    }

    public void SetInputValue(string s)
    {
        inputLockText.text += s;
       
    }
}
