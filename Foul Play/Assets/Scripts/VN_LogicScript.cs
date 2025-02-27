using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.Windows;
using static UnityEngine.ParticleSystem;

public class VN_LogicScript : MonoBehaviour
{
    // Allows access to main logic script
    public GameObject mainlogicscript;



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



    // Variables used for Choice
    // Hold the canvas the choiceUI is in.
    public GameObject choiceUI;

    // Holds the text boxes used in the buttons
    public Text choice1Text;
    public Text choice2Text;
    
    // Holds the indexes that each of the buttons should send the player too
    int choice1Index;
    int choice2Index;

    // Stops the script from continuing while a choice is needed
    bool choiceTime = false;



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

        // Gets the audioSource to use later
        // Gets the audioSource to use later
        audioSource = GetComponent<AudioSource>();

        // Grants control over the characters
        for (int i = 0; i < CharacterObjects.Length; i++)
        {
            Characters[i] = CharacterObjects[i].GetComponent<VN_CharacterScript>();
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
        if (PreviousDialogue.activeSelf == false && !gameManager.getMain_Paused() && (UnityEngine.Input.GetKeyDown(KeyCode.Space) | UnityEngine.Input.GetKeyDown(KeyCode.Return) | UnityEngine.Input.GetMouseButtonDown(0)))
        {
            playerInput = true;
        }

        // If the player inputs and continue can happen then it will continue
        if (allowContinue && playerInput)
        {
            continueScript = true;
        }

        // Goes through the instructions in the script
        while (continueScript && !choiceTime && !gameManager.getMain_Paused())
        {
            // Converts text name to array
            if (script[scriptIndex , 1] == "BG") { wantedCharacter = 0;}
            else if (script[scriptIndex , 1] == "Ebony") { wantedCharacter = 1; }
            else if (script[scriptIndex , 1] == "King Kavi") { wantedCharacter = 2; }
            else if (script[scriptIndex , 1] == "Fake Foul") { wantedCharacter = 3; }
            else if (script[scriptIndex , 1] == "Foul") { wantedCharacter = 4; }
            else if (script[scriptIndex , 1] == "Chimera") { wantedCharacter = 5; }
            else if (script[scriptIndex , 1] == "Ushabti") { wantedCharacter = 6; }
            else if (script[scriptIndex , 1] == "Wendigo") { wantedCharacter = 7; }
            else if (script[scriptIndex , 1] == "Alerion") { wantedCharacter = 8; }
            else if (script[scriptIndex , 1] == "Basil") { wantedCharacter = 9; }
            else if (script[scriptIndex , 1] == "Hydra") { wantedCharacter = 10; }
            else if (script[scriptIndex , 1] == "Tsuchigumo") { wantedCharacter = 11; }
            else if (script[scriptIndex , 1] == "Vetala") { wantedCharacter = 12; }
            else { wantedCharacter = 0; }



            // Commands from the script
            if (script[scriptIndex , 0] == "Appear")
            {
                appear(Characters[wantedCharacter], float.Parse(script[scriptIndex , 2]));
            }

            else if (script[scriptIndex , 0] == "Branch")
            {
                branch(int.Parse(script[scriptIndex , 1]));
            }

            else if (script[scriptIndex , 0] == "Change")
            {
                change(Characters[wantedCharacter], int.Parse(script[scriptIndex , 2]));
            }

            else if (script[scriptIndex , 0] == "Choice")
            {
                choice(script[scriptIndex , 1], int.Parse(script[scriptIndex , 2]), script[scriptIndex , 3], int.Parse(script[scriptIndex , 4]));
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
        if (UnityEngine.Input.GetKeyDown(KeyCode.Tab) && !gameManager.getMain_Paused() && (allowContinue | PreviousDialogue.activeSelf))
        {
            togglePreDialogue();
        }


        // increases the timer
        timer += Time.deltaTime;
        // When its been enough time the text will be added to the box
        if (arrayTargetTextBox.Length > arrayTargetTextBoxIndex && timer >= talkSpeed && !gameManager.getMain_Paused())
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


    }



    // Adds the next part of text to the box
    // Also plays the talk sound
    void advanceDialogue()
    {
        textBox.text += (arrayTargetTextBox[arrayTargetTextBoxIndex] += " ");

        audioSource.clip = talkSound;
        audioSource.Play();
        arrayTargetTextBoxIndex += 1;
    }



    // Teleports Character
    // First one after code is the character
    // Second one is the location on the x axis
    // 7 in either direction starts to go out of bounds
    void appear(VN_CharacterScript Character, float xAxis)
    {
        Character.Appear(xAxis);
        scriptIndex += 1;
    }



    // Will be used to jump to different parts of the script
    void branch(int branchPoint)
    {
        scriptIndex = branchPoint;
    }



    // Changes the sprite of a given character
    void change(VN_CharacterScript character, int spriteNumber)
    {
        character.Change(spriteNumber);
        scriptIndex += 1;
    }



    // Give the user 2 choices
    // They can not continue unless they press one of them
    void choice(string option1, int option1Index, string option2, int option2Index)
    {
        choiceUI.SetActive(true);
        choice1Text.text = option1;
        choice1Index = option1Index;
        choice2Text.text = option2;
        choice2Index = option2Index;

        choiceTime = true;
        continueScript = false;
        allowContinue = false;
    }



    // Called by the choice buttons
    // Branches to the choice made
    public void choiceMade(int choiceNum)
    {
        choiceTime = false;
        continueScript = true;
        allowContinue = true;
        
        choiceUI.SetActive(false);

        if (choiceNum == 1)
        {
            branch(choice1Index);
        }

        else
        {
            branch(choice2Index);
        }
    }



    // Moves character to origin
    void disappear(VN_CharacterScript Character)
    {
        Character.Disappear();
        scriptIndex += 1;
    }



    // Prevents script from continuing
    // Passes endCode to the gameManager
    // Needs to end or hide scene 
    void end(string endCode)
    {

        gameManager.setVN_exitCode(endCode);
        gameManager.setVN_Script("NoScript");
        continueScript = false;
        allowContinue = false;
    }



    // When a command doesn't execute properly the user is told
    // If no command executes then it will advance 1 index at a time
    // If a command executed but didn't have a target then it won't advance
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



    // Moves Character
    // Give speed to change how fast it moves
    void move(VN_CharacterScript character, float xAxis, float speed)
    {
        character.Move(xAxis, speed);
        scriptIndex += 1;
    }



    // Opens and closes previous dialogue menu
    void togglePreDialogue()
    {
        PreviousDialogue.SetActive(!PreviousDialogue.activeSelf);
        allowContinue = !PreviousDialogue.activeSelf;
    }



    // Shows text + speaker
    // Waits for next input until continues to next command
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



    // Plays sound
    void sound(string soundName)
    {
        soundEffectManager.GetComponent<VN_SoundLibrary>().playSound(soundName);
        scriptIndex += 1;
    }



}
