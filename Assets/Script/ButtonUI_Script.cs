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
        SettingPanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        crossHair.SetActive(true);
    }
    public void Resstart_BTN()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
