using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public GameObject WinLosePanel;
    public GameObject nextLevel_Btn;
    public Text WinLoseText;
    public GameObject crossHair;
    public Text clue;
    public GameObject settingPanel;


    public bool isDie=false;
    public bool isWin = false;

    // Start is called before the first frame update
    void Start()
    {

        if (instance != null)
        {
            instance = this;
        }

        WinLosePanel.SetActive(false);
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "Lvl1")
        {
            clue.text = "Find The Exit";
            StartCoroutine(ClueCoroutine());

        }
        if (SceneManager.GetActiveScene().name == "Lvl2")
        {
            clue.text = "The table seem useful. I can hide under them if something chases me.";
            StartCoroutine("ClueCoroutine");
        }
        settingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie)
        {
            Time.timeScale = 0;
            WinLosePanel.SetActive(true);
            nextLevel_Btn.SetActive(false);
            WinLoseText.text = "YOU DIE";
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            crossHair.SetActive(false);
        }
        if (isWin)
        {
            Time.timeScale = 0;
            WinLosePanel.SetActive(true);
            WinLoseText.text = "YOU WIN";
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            crossHair.SetActive(false);
        }

        
    }

    IEnumerator ClueCoroutine()
    {
        yield return new WaitForSeconds(5f);
        clue.text = "";
    }
}
