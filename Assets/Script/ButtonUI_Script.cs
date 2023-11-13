using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI_Script : MonoBehaviour
{
    public GameObject InstructionPanal;

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
    public void Resstart_BTN()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel_BTN()
    {
        if(SceneManager.GetActiveScene().name== "Lvl1")
        {
            SceneManager.LoadScene("Level_2");
        }
        else
        {
            SceneManager.LoadScene("StartScene");
        }
    }


}
