using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
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
    public GameObject cutsceneScreen;
    public GameObject continueMenu;
    public GameObject skipCutsceneBox;

    // Used so the unpause button in the settings only shows up when the game is paused
    public GameObject settingsUnpauseButton;

    // Used for volume
    public Text masterVolumeShower;
    public Slider masterVolumeSlider;
    public Text musicVolumeShower;
    public Slider musicVolumeSlider;
    public Text soundEffectVolumeShower;
    public Slider soundEffectVolumeSlider;

    public Dropdown scriptDropdown;


    // Save Data
    public Text currentSaveDebug;
    public InputField changeSaveDataDebug;
    public Dropdown currentSaveDropdownTemp;
    int saveSlot;

    gameManager.saveData[] playerSaves;

    void Start()
    {
        // Loads save data
        loadPrefs();

        // Sets sliders to correct locations
        masterVolumeSlider.value = gameManager.getMain_MasterVolume();
        musicVolumeSlider.value = gameManager.getMain_TrueMusicVolume();
        soundEffectVolumeSlider.value = gameManager.getMain_TrueSoundEffectVolume();


        // Creates an array of the save data
        playerSaves = new gameManager.saveData[3];
        playerSaves[0] = new gameManager.saveData();
        playerSaves[1] = new gameManager.saveData();
        playerSaves[2] = new gameManager.saveData();

        playerSaves[0].aRandomString = "One";
        playerSaves[1].aRandomString = "Two";
        playerSaves[2].aRandomString = "Three";

        // Sets current title music to the title screen music
        gameManager.setMain_wantedMusic("Title Screen");
    }



    void Update()
    {
        // Toggles pausemenu when escape is pressed
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && !titleScreen.activeSelf && !cutsceneScreen.activeSelf)
        {
            togglePausemenu();
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && cutsceneScreen.activeSelf)
        {
            GetComponent<Main_CutsceneManager>().toggleCutscenePausemenu();
        }


        saveSlot = currentSaveDropdownTemp.value;

        currentSaveDebug.text = playerSaves[saveSlot].aRandomString;
        

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

    public void saveData()
    {
        playerSaves[saveSlot].aRandomString = changeSaveDataDebug.text;
    }





    /// <summary>
    /// Used by the VN buttons to simulate the VN being opened
    /// </summary>
    /// <param name="wantedScript"></param>
    public void openVisualNovel()
    {
        // Stores the wanted script into the game manager so the VN knows what scene is wanted
        gameManager.setVN_Script(scriptDropdown.options[scriptDropdown.value].text);

        // Sets the music
        gameManager.setMain_wantedMusic("Opening Music");

        // Loads the scene
        SceneManager.LoadScene("Visual Novel", LoadSceneMode.Additive);

        // Hides title screen
        titleScreen.SetActive(false);
    }


    /// <summary>
    /// Used to start a new game
    /// </summary>
    public void newGame()
    {
        titleScreen.SetActive(false);
        GetComponent<Main_CutsceneManager>().playCutscene("Opening Cutscene");
    }

    /// <summary>
    /// Used to continue a saved game then starts the game
    /// </summary>
    public void continueGame()
    {
        gameManager.setSaveData(playerSaves[saveSlot]);
        startGame();
    }

    public void startGame()
    {
        SceneManager.LoadScene("Point and Click", LoadSceneMode.Additive);
        titleScreen.SetActive(false);
        continueMenu.SetActive(false);
    }


    /// <summary>
    /// Used to open the point and click scene
    /// </summary>
    public void openPointAndClick()
    {
        SceneManager.LoadScene("Point and Click", LoadSceneMode.Additive);
        titleScreen.SetActive(false);
    }



    /// <summary>
    /// Opens and closes the pause menu
    /// </summary>
    public void togglePausemenu()
    {
        // Causes the pause menu active state to because the opposite of what it currently is
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        // Sets the game to be paused or unpaused
        gameManager.setMain_Paused(pauseMenu.activeSelf);

        // If the menu is now closed it should close the settings menu and hide the unpause button
        if (!pauseMenu.activeSelf)
        {
            settingsUnpauseButton.SetActive(false);

            if (settingsMenu.activeSelf)
            {
                toggleSettings();
            }
        }
        // If the menu is now open it allows the Unpause buttons to be in the settings menu
        else
        {
            settingsUnpauseButton.SetActive(true);
        }
        
    }


    public void savePrefs()

    {

        PlayerPrefs.SetFloat("Master Volume", gameManager.getMain_MasterVolume());
        PlayerPrefs.SetFloat("Music Volume", gameManager.getMain_TrueMusicVolume());
        PlayerPrefs.SetFloat("Sound Effect Volume", gameManager.getMain_TrueSoundEffectVolume());
        PlayerPrefs.Save();

    }
    public void loadPrefs()

    {

        gameManager.setMain_MasterVolume( PlayerPrefs.GetFloat("Master Volume", 50));
        gameManager.setMain_MusicVolume(PlayerPrefs.GetFloat("Music Volume", 50));
        gameManager.setMain_SoundEffectVolume(PlayerPrefs.GetFloat("Sound Effect Volume", 50));


    }



    /// <summary>
    /// Opens and closes the settings menu
    /// </summary>
    public void toggleSettings()
    {
        settingsMenu.SetActive(!settingsMenu.activeSelf);

        if (!settingsMenu.activeSelf)
        {
            savePrefs();
        }
    }



    public void toggleContinue()
    {
        continueMenu.SetActive(!continueMenu.activeSelf);
        titleScreen.SetActive(!continueMenu.activeSelf);
    }



    /// <summary>
    /// Closes all other scenes and opens the title screen
    /// </summary>
    public void returnToTitle()
    {
        // Sets the only active scene to be main
        SceneManager.LoadScene("Main");

        // Closes the pause menu
        togglePausemenu();
    }


    /// <summary>
    /// Closes the game
    /// </summary>
    public void closeGame()
    {
        Application.Quit();
    }



    /// <summary>
    /// Used when a cutscene ends so the game knows what to do
    /// </summary>
    /// <param name="endedCutscene"></param>
    public void cutsceneEnded(string endedCutscene)
    {
        // Changes the music after the opening cutscene to the opening music
        if (endedCutscene == "Opening Cutscene")
        {
            startGame();
        }
    }


    



}


