using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.Windows;
using static UnityEngine.ParticleSystem;
using static UnityEngine.Rendering.DebugUI;

public class VN_LogicScript : MonoBehaviour
{
    // Variables used for Say
    // Used to write to the text box
    public Text textBox;
    public Text nameBox;

    // Used to fill the text box
    string targetTextBox;
    string[] arrayTargetTextBox;
    int arrayTargetTextBoxIndex;

    // Used to time how ofter text is added
    public float talkSpeed;
    float timer;

    // Used for the past dialogue screen
    public GameObject PreviousDialogue;
    public Text[] pastDialogue;
    public Text[] pastName;

    // Used to the blips when talking
    public AudioClip talkSound;
    AudioSource audioSource;

    // Array used for branch points
    string[] branchPoints;



    // Variables used for Choice
    // Hold the canvas the choiceUI is in.
    public GameObject choiceUI;

    // Holds the text boxes used in the buttons
    public Text sweetChoiceText;
    public Text sadisticChoiceText;
    public Text sassyChoiceText;
    public Text strongChoiceText;

    // Holds the point that each of the buttons should send the player too
    string sweetChoicePoint;
    string sadisticChoicePoint;
    string sassyChoicePoint;
    string strongChoicePoint;
    



    // Used for script
    // The objects the scripts are stored in
    public GameObject soundEffectManager;

    // Array the script is stored in
    string[,] script;

    // Stored current location in script
    int scriptIndex = 0;

    // Did the player do an input this frame
    bool playerInput = false;

    // Should the player's input continue the script
    bool allowContinue = true;

    // Should the next action should be done
    bool continueScript = true;



    // Characters
    // This array holds all of the characters
    public GameObject[] CharacterObjects;

    // This array will then have the character's scripts stored in it
    // Make sure the number in it is larger than the number of characters
    VN_CharacterScript[] Characters = new VN_CharacterScript[20];

    // This holds the character that the current request may be asking for.
    int wantedCharacter;


    
    void Start()
    {
        // Calls calls return script from VN_Script
        // Calls the gameManager to get which script is wanted
        script = GetComponent<VN_Scripts>().returnScript(gameManager.getVN_Script());
        branchPoints = new string[script.GetLength(0)];


        // Gets the audioSource to use later
        // Gets the audioSource to use later
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = gameManager.getMain_SoundEffectVolume();

        // Grants control over the characters
        for (int i = 0; i < CharacterObjects.Length; i++)
        {
            Characters[i] = CharacterObjects[i].GetComponent<VN_CharacterScript>();
        }

        // Checks the script for any branch points and then stores them
        for (int i = 0; i < (script.GetLength(0) - 1); i++)
        {
            if (script[i,0] == "Branch Point")
            {
                branchPoints[i] = script[i, 1];
            }

        }

        // Makes it so dialogue will instantly start
        timer = talkSpeed;

    }

    void Update()
    {
        // Checks if player wants to progress in the script.
        // If they wish to then the loop will begin
        // Detects Space, Keyboard Enter, and Left Mouse
        // Will not work if other menus are open
        playerInput = false;
        if (!PreviousDialogue.activeSelf && !choiceUI.activeSelf && !gameManager.getMain_Paused() && (UnityEngine.Input.GetKeyDown(KeyCode.Space) || UnityEngine.Input.GetKeyDown(KeyCode.Return) || UnityEngine.Input.GetMouseButtonDown(0)))
        {
            playerInput = true;
        }

        // If the player inputs and continue can happen then it will continue
        if (allowContinue && playerInput)
        {
            continueScript = true;
        }

        // Goes through the instructions in the script
        while (continueScript && !choiceUI.activeSelf && !gameManager.getMain_Paused())
        {
            // Converts text name to array
            if (script[scriptIndex , 1] == "BG") { wantedCharacter = 0;}
            else if (script[scriptIndex , 1] == "Ebony") { wantedCharacter = 1; }
            else if (script[scriptIndex , 1] == "King Kavi") { wantedCharacter = 2; }
            else if (script[scriptIndex , 1] == "Fake Foul") { wantedCharacter = 3; }
            else if (script[scriptIndex , 1] == "Foul") { wantedCharacter = 4; }
            else if (script[scriptIndex , 1] == "Clayton") { wantedCharacter = 5; }
            else if (script[scriptIndex , 1] == "Basil") { wantedCharacter = 6; }
            else if (script[scriptIndex , 1] == "Hydra") { wantedCharacter = 7; }
            else if (script[scriptIndex , 1] == "Ögumo") { wantedCharacter = 8; }
            else if (script[scriptIndex, 1] == "Fake Foul's Guard") { wantedCharacter = 9; }
            else { wantedCharacter = 0; }



            // Commands from the script
            if (script[scriptIndex , 0] == "Appear")
            {
                appear(Characters[wantedCharacter], float.Parse(script[scriptIndex , 2]));
            }

            else if (script[scriptIndex , 0] == "Branch")
            {
                branch(script[scriptIndex , 1]);
            }

            else if (script[scriptIndex, 0] == "Branch Point")
            {
                branchPoint();
            }

            else if (script[scriptIndex , 0] == "Change")
            {
                change(Characters[wantedCharacter], int.Parse(script[scriptIndex , 2]));
            }

            else if (script[scriptIndex , 0] == "Choice")
            {
                choice(script[scriptIndex , 1], script[scriptIndex , 2], script[scriptIndex , 3], script[scriptIndex , 4], script[scriptIndex, 5], script[scriptIndex, 6], script[scriptIndex, 7], script[scriptIndex, 8]);
            }

            else if (script[scriptIndex , 0] == "Disappear")
            {
                disappear(Characters[wantedCharacter]);
            }

            else if (script[scriptIndex , 0] == "End")
            {
                end(script[scriptIndex , 1]);
            }

            else if (script[scriptIndex , 0] == "Move")
            {
                move(Characters[wantedCharacter], float.Parse(script[scriptIndex , 2]), float.Parse(script[scriptIndex , 3]));
            }

            else if (script[scriptIndex , 0] == "Say")
            {
                say(script[scriptIndex , 1], script[scriptIndex , 2]);
            }

            else if (script[scriptIndex , 0] == "Sound")
            {
                sound(script[scriptIndex , 1]);
            }

            else
            {
                error(true);
            }

        }

        // Shows the previous dialogue menu when the user presses tab and they can continue
        // Hides the menu when it is open
        if (UnityEngine.Input.GetKeyDown(KeyCode.Tab) && !gameManager.getMain_Paused() && (allowContinue || PreviousDialogue.activeSelf))
        {
            togglePreDialogue();
        }


        // increases the timer
        timer += Time.deltaTime;
        // When its been enough time the text will be added to the box
        if (arrayTargetTextBox.Length > arrayTargetTextBoxIndex && timer >= talkSpeed && (!gameManager.getMain_Paused()))
        {
            advanceDialogue();
            timer = 0;
        }
        // Allows continuing again once the end of the text is reached
        else if (arrayTargetTextBox.Length == arrayTargetTextBoxIndex)
        {
            allowContinue = true;
        }
        // Skips to the end of the text if player inputs
        else if (!allowContinue && playerInput)
        {
            textBox.text = targetTextBox;
            arrayTargetTextBoxIndex = arrayTargetTextBox.Length;
            allowContinue = true;
            audioSource.clip = talkSound;
            audioSource.Play();
        }

        // Updates volume while game is paused
        if (gameManager.Main_paused)
        {
            audioSource.volume = gameManager.getMain_SoundEffectVolume();
        }

    }




    /// <summary>
    /// Adds the next part of text to the box. 
    /// Also plays the talk sound
    /// </summary>
    void advanceDialogue()
    {
        textBox.text += (arrayTargetTextBox[arrayTargetTextBoxIndex] += " ");

        audioSource.clip = talkSound;
        audioSource.Play();
        arrayTargetTextBoxIndex += 1;
    }



    /// <summary>
    /// Teleports Character
    /// </summary>
    /// <param name="Character"></param>
    /// <param name="xAxis"></param>
    void appear(VN_CharacterScript Character, float xAxis)
    {
        Character.Appear(xAxis);
        scriptIndex += 1;
    }



    /// <summary>
    /// Sets scriptIndex to the possition of the branch point
    /// </summary>
    /// <param name="branchPoint"></param>
    void branch(string branchPoint)
    {
        if (Array.IndexOf(branchPoints, branchPoint) != -1)
        {
            scriptIndex = Array.IndexOf(branchPoints, branchPoint);
        }
        else
        {
            error(false);
            scriptIndex =  0;
        }
        
    }



    /// <summary>
    /// Skips past the branch point when the VN reaches it
    /// </summary>
    void branchPoint()
    {
        scriptIndex += 1;
    }



    /// <summary>
    /// Changes the sprite of a given character
    /// </summary>
    /// <param name="character"></param>
    /// <param name="spriteNumber"></param>
    void change(VN_CharacterScript character, int spriteNumber)
    {
        character.Change(spriteNumber);
        scriptIndex += 1;
    }



    /// <summary>
    /// Gives the user 4 choices. 
    /// They can not continue unless they press one of them
    /// </summary>
    /// <param name="option1"></param>
    /// <param name="option1Point"></param>
    /// <param name="option2"></param>
    /// <param name="option2Point"></param>
    /// <param name="option3"></param>
    /// <param name="option3Point"></param>
    /// <param name="option4"></param>
    /// <param name="option4Point"></param>
    void choice(string option1, string option1Point, string option2, string option2Point, string option3, string option3Point, string option4, string option4Point)
    {
        choiceUI.SetActive(true);
        sweetChoiceText.text = option1;
        sadisticChoiceText.text = option2;
        sassyChoiceText.text = option3;
        strongChoiceText.text = option4;

        sweetChoicePoint = option1Point;
        sadisticChoicePoint = option2Point;
        sassyChoicePoint = option3Point;
        strongChoicePoint = option4Point;

        continueScript = false;
    }



    /// <summary>
    /// Called by the choice buttons. 
    /// Branches to the choice made
    /// </summary>
    /// <param name="choiceNum"></param>
    public void choiceMade(int choiceNum)
    {
        continueScript = true;
        
        choiceUI.SetActive(false);

        if (choiceNum == 1)
        {
            branch(sweetChoicePoint);
        }

        else if (choiceNum == 2)
        {
            branch(sadisticChoicePoint);
        }

        else if (choiceNum == 3)
        {
            branch(sassyChoicePoint);
        }

        else
        {
            branch(strongChoicePoint);
        }
    }



    /// <summary>
    /// Moves character to origin
    /// </summary>
    /// <param name="Character"></param>
    void disappear(VN_CharacterScript Character)
    {
        Character.Disappear();
        scriptIndex += 1;
    }




    /// <summary>
    /// Prevents script from continuing. 
    /// Passes endCode to the gameManager. 
    /// Closes VN scene and removes the script
    /// </summary>
    /// <param name="endCode"></param>
    void end(string endCode)
    {
        gameManager.setVN_exitCode(endCode);
        gameManager.setVN_Script("NoScript");
        gameManager.setVN_checkExitCode(true);
        continueScript = false;
        allowContinue = false;
        SceneManager.UnloadSceneAsync("Visual Novel");
    }



    // When a command doesn't execute properly the user is told
    // If no command executes then it will advance 1 index at a time
    // If a command executed but didn't have a target then it won't advance
    /// <summary>
    /// Called when an error happens. 
    /// True / False decides if the index should advance after it
    /// </summary>
    /// <param name="advance"></param>
    void error(bool advance)
    {
        nameBox.text = "Phox";
        targetTextBox = "There was a problem on line " + scriptIndex;
        arrayTargetTextBox = targetTextBox.Split(" ");
        textBox.text = "";
        arrayTargetTextBoxIndex = 0;

        if (advance)
        {
            scriptIndex += 1;
        }

        continueScript = false;
        allowContinue = true;
    }




    /// <summary>
    /// Moves Character at the given speed
    /// </summary>
    /// <param name="character"></param>
    /// <param name="xAxis"></param>
    /// <param name="speed"></param>
    void move(VN_CharacterScript character, float xAxis, float speed)
    {
        character.Move(xAxis, speed);
        scriptIndex += 1;
    }



    /// <summary>
    /// Opens and closes previous dialogue menu
    /// </summary>
    void togglePreDialogue()
    {
        PreviousDialogue.SetActive(!PreviousDialogue.activeSelf);
        allowContinue = !PreviousDialogue.activeSelf;
    }




    /// <summary>
    /// Shows text and speaker. 
    /// Waits for next input until continues to next command
    /// </summary>
    /// <param name="name"></param>
    /// <param name="dialogue"></param>
    void say(string name, string dialogue)
    {
        nameBox.text = name;
        targetTextBox = dialogue;
        arrayTargetTextBox = targetTextBox.Split(" ");
        textBox.text = "";
        arrayTargetTextBoxIndex = 0;

        pastDialogue[2].text = pastDialogue[1].text;
        pastDialogue[1].text = pastDialogue[0].text;
        pastDialogue[0].text = script[scriptIndex , 2];
        pastName[2].text = pastName[1].text;
        pastName[1].text = pastName[0].text;
        pastName[0].text = script[scriptIndex , 1];

        scriptIndex += 1;
        continueScript = false;
        allowContinue = false;
    }



    /// <summary>
    /// Plays given sound effect
    /// </summary>
    /// <param name="soundName"></param>
    void sound(string soundName)
    {
        soundEffectManager.GetComponent<VN_SoundLibrary>().playSound(soundName);
        scriptIndex += 1;
    }



}
