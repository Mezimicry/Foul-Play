using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// The main scene will include things like the title screen and pause menu

public class Main_LogicScript : MonoBehaviour
{
    // Used to access the different menus
    public GameObject titleScreen;
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    // Used so the unpause button in the settings only shows up when the game is paused
    public GameObject settingsUnpauseButton;


    void Start()
    {

    }

    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            togglePausemenu();
        }
    }




    // Called by the VN buttons to simulate what should be done when the point and click needs to start a VN scene
    public void openVisualNovel(string wantedScript)
    {
        // Stores the wanted script into the game manager so the VN knows what scene is wanted
        gameManager.setVN_Script(wantedScript);
        SceneManager.LoadScene("Visual Novel", LoadSceneMode.Additive);
        titleScreen.SetActive(false);
    }


    // Use this to test opening the point and click scene
    public void openPointAndClick()
    {
        SceneManager.LoadScene("AddSceneNameHere", LoadSceneMode.Additive);
        titleScreen.SetActive(false);
    }



    public void togglePausemenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        gameManager.setMain_Paused(pauseMenu.activeSelf);
        if (!pauseMenu.activeSelf) 
        {
            settingsMenu.SetActive(false);
            settingsUnpauseButton.SetActive(false);
        }
        else
        {
            settingsUnpauseButton.SetActive(true);
        }

    }

    public void toggleSettings()
    {
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }


    public void returnToTitle()
    {
        SceneManager.LoadScene("Main");
        togglePausemenu();
    }




}


