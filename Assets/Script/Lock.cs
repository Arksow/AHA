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
    
    public TMP_Text firstNumTMP;
    public TMP_Text secondNumTMP;
    public TMP_Text thirdNumTMP;
    public TMP_Text fourthNumTMP;

    public Animator elevatorAnim;

    public TMP_Text inputLockText;

    public AudioSource source;
    public AudioClip clickSound;
    public AudioClip wrongSound;

    public GameObject elivator;
    // Start is called before the first frame update
    void Start()
    {
        firstNum = Random.Range(1, 9);
        seccondNum = Random.Range(0, 9);
        thirdNum = Random.Range(0, 9);
        fourthNum = Random.Range(0, 9);

        firstNumTMP.text = firstNum.ToString();
        secondNumTMP.text = seccondNum.ToString();
        thirdNumTMP.text = thirdNum.ToString();
        fourthNumTMP.text = fourthNum.ToString();

        wholeNum = firstNum * 1000 + seccondNum * 100 + thirdNum * 10 + fourthNum;
    }

    // Update is called once per frame
    void Update()
    {
        string targetString = wholeNum.ToString();

        if (inputLockText.text == targetString)
        {
            inputLockText.text = "Correct";
            elevatorAnim.SetBool("OpenDoor",true);
            StartCoroutine("ElevatorCoroutine");
        }
        if (inputLockText.text != targetString && inputLockText.text.Length == 4)
        { 
            inputLockText.text = "";
            source.PlayOneShot(wrongSound, 0.5f);
        }
    }

    public void SetInputValue(string s)
    {
        inputLockText.text += s;
        source.PlayOneShot(clickSound);
    }

    IEnumerator ElevatorCoroutine()
    {
        yield return new WaitForSeconds(10f);
        elivator.GetComponent<BoxCollider>().enabled = false;
    }
}
