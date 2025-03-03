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

    // Used for volume
    public Text masterVolumeShower;
    public Slider masterVolumeSlider;
    public Text musicVolumeShower;
    public Slider musicVolumeSlider;
    public Text soundEffectVolumeShower;
    public Slider soundEffectVolumeSlider;



    void Start()
    {
        // Sets current title music to the title screen music
        gameManager.setMain_wantedMusic("Title Screen");
    }



    void Update()
    {
        // Toggles pausemenu when escape is pressed
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            togglePausemenu();
        }

        

        // Updates volume settings when settings menu is open
        if (settingsMenu.activeSelf)
        {
            gameManager.setMain_MasterVolume(masterVolumeSlider.value);
            masterVolumeShower.text = masterVolumeSlider.value.ToString();

            gameManager.setMain_MusicVolume(musicVolumeSlider.value);
            musicVolumeShower.text = musicVolumeSlider.value.ToString();

            gameManager.setMain_SoundEffectVolume(soundEffectVolumeSlider.value);
            soundEffectVolumeShower.text = soundEffectVolumeSlider.value.ToString();
        }
    }



    // Called by the VN buttons to simulate what should be done when the point and click needs to start a VN scene
    public void openVisualNovel(string wantedScript)
    {
        // Stores the wanted script into the game manager so the VN knows what scene is wanted
        gameManager.setVN_Script(wantedScript);

        // Sets the music
        gameManager.setMain_wantedMusic("VNTest");

        // Loads the scene
        SceneManager.LoadScene("Visual Novel", LoadSceneMode.Additive);

        // Hides title screen
        titleScreen.SetActive(false);
    }


    // Use this to test opening the point and click scene
    public void openPointAndClick()
    {
        SceneManager.LoadScene("Point and Click", LoadSceneMode.Additive);
        titleScreen.SetActive(false);
    }



    // Toggles pausemenu
    public void togglePausemenu()
    {
        // Causes the pause menu active state to because the opposite of what it currently is
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        // Sets the game to be paused or unpaused
        gameManager.setMain_Paused(pauseMenu.activeSelf);

        // If the menu is now closed it should close the settings menu and hide the unpause button
        if (!pauseMenu.activeSelf) 
        {
            settingsMenu.SetActive(false);
            settingsUnpauseButton.SetActive(false);
        }
        // If the menu is now open it allows the Unpause buttons to be in the settings menu
        else
        {
            settingsUnpauseButton.SetActive(true);
        }

    }



    // Changes the settings menu to be its opposite active state
    public void toggleSettings()
    {
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }




    public void returnToTitle()
    {
        // Sets the only active scene to be main
        SceneManager.LoadScene("Main");

        // Closes the pause menu
        togglePausemenu();
    }



}


