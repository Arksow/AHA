using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI_Script : MonoBehaviour
{
    [Header("for start scene only")]
    public GameObject InstructionPanal;

    [Header("for level 1 and 2")]
    public GameObject SettingPanel;
    public GameObject crossHair;

    public void Start_BTN()
    {
        SceneManager.LoadScene("Lvl1");
    }
    
    public void Exit_BTN()
    {
        Application.Quit();
    }

    public void Instruction_BTN()
    {
        InstructionPanal.SetActive(true);
    }
    public void Close_BTN()
    {
        InstructionPanal.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ContinueButton()
    {
        Time.timeScale = 1;
        SettingPanel.SetActive(false);

        CrossHair_Lock();
        crossHair.SetActive(true);
    }

    private static void CrossHair_Lock()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Resstart_BTN()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CrossHair_Lock();
    }
    public void NextLevel_BTN()
    {
        if(SceneManager.GetActiveScene().name== "Lvl1")
        {
            SceneManager.LoadScene("Lvl2");
        }
        else
        {
            SceneManager.LoadScene("StartScene");
        }
    }


}
