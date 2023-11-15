using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Lock : MonoBehaviour
{
    int firstNum;
    int seccondNum;
    int thirdNum;
    int fourthNum;

    [SerializeField]int wholeNum;
    
    int[] lockNum = new int[4];
    int[] inputLockNum = new int[3];

    public TMP_Text firstNumTMP;
    public TMP_Text secondNumTMP;
    public TMP_Text thirdNumTMP;
    public TMP_Text fourthNumTMP;

    public Animator elevatorAnim;

    public TMP_Text inputLockText;

    public AudioSource source;
    public AudioClip cliclSound;
    // Start is called before the first frame update
    void Start()
    {
        lockNum[0] = Random.Range(1, 9);
        lockNum[1] = Random.Range(0, 9);
        lockNum[2] = Random.Range(0, 9);
        lockNum[3] = Random.Range(0, 9);

        firstNum = lockNum[0];
        seccondNum = lockNum[1];
        thirdNum = lockNum[2];
        fourthNum = lockNum[3];

        firstNumTMP.text = firstNum.ToString();
        secondNumTMP.text = seccondNum.ToString();
        thirdNumTMP.text = thirdNum.ToString();
        fourthNumTMP.text = fourthNum.ToString();

        wholeNum = firstNum * 1000 + seccondNum * 100 + thirdNum * 10 + fourthNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputLockText.text == wholeNum.ToString())
        {
            elevatorAnim.SetBool("OpenDoor",true);
        }
    }

    public void SetInputValue(string s)
    {
        inputLockText.text += s;
        source.PlayOneShot(cliclSound);
    }
}
