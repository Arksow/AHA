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
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie)
        {
            Time.timeScale = 0;
            WinLosePanel.SetActive(true);
            nextLevel_Btn.SetActive(false);
            WinLoseText.text = "YOU DIE!!!";
            Cursor.lockState = CursorLockMode.None;
            crossHair.SetActive(false);
        }
        if (isWin)
        {
            Time.timeScale = 0;
            WinLosePanel.SetActive(true);
            WinLoseText.text = "YOU WIN!!!";
            Cursor.lockState = CursorLockMode.None;
            crossHair.SetActive(false);
        }


    }
}
