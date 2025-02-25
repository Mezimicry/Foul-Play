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
    public Text textBox;
    public Text nameBox;
    string targetTextBox;
    string[] arrayTargetTextBox;
    int arrayTargetTextBoxIndex;

    public GameObject PreviousDialogue;
    public Text[] pastDialogue;
    public Text[] pastName;

    public GameObject choiceUI;
    public Text choice1Text;
    public Text choice2Text;
    int choice1Index;
    int choice2Index;


    public GameObject scriptFinder;


    public string desiredScript;
    string[] script;


    int scriptIndex = 0;
    bool continueScript = true;
    bool allowContinue = true;
    bool playerInput = false;

    public float talkSpeed = 0.001f;
    float timer;

    AudioSource audioSource;
    public AudioClip talkSound;

    // Current way of giving control over the characters
    public GameObject Character1Object;
    VN_CharacterScript Character1;
    public GameObject Character2Object;
    VN_CharacterScript Character2;

    void Start()
    {
        script = scriptFinder.GetComponent<VN_Scripts>().returnScript(desiredScript);

        audioSource = GetComponent<AudioSource>();

        // Grants control over the characters
        Character1 = Character1Object.GetComponent<VN_CharacterScript>();
        Character2 = Character2Object.GetComponent<VN_CharacterScript>();

        // Makes it so dialogue will instantly start
        timer = talkSpeed;
    }

    void Update()
    {
        // Checks if player wants to progress in the script.
        // If they wish to then the loop will begin
        // Detects Space, Keyboard Enter, and Left Mouse

        playerInput = false;
        if (PreviousDialogue.activeSelf == false && (UnityEngine.Input.GetKeyDown(KeyCode.Space) | UnityEngine.Input.GetKeyDown(KeyCode.Return) | UnityEngine.Input.GetMouseButtonDown(0)))
        {
            playerInput = true;
        }


        if (allowContinue && playerInput)
        {
            continueScript = true;
        }

        while (continueScript)
        {
            if (script[scriptIndex] == "Say")
            {
                say();
            }

            else if (script[scriptIndex] == "Appear")
            {
                appear();
            }

            else if (script[scriptIndex] == "Move")
            {
                move();
            }

            else if (script[scriptIndex] == "Change")
            {
                change();
            }

            else if (script[scriptIndex] == "Sound")
            {
                sound();
            }

            else if (script[scriptIndex] == "Branch")
            {
                branch(int.Parse(script[scriptIndex + 1]));
            }

            else if (script[scriptIndex] == "Choice")
            {
                choice();
            }

            else if (script[scriptIndex] == "End")
            {
                end();
            }

            else
            {
                error(true);
            }
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Tab) && (allowContinue | PreviousDialogue.activeSelf))
        {
            togglePreDialogue();
        }


        timer += Time.deltaTime;
        if (arrayTargetTextBox.Length > arrayTargetTextBoxIndex && timer >= talkSpeed)
        {
            advanceDialogue();
            timer = 0;
        }
        else if (arrayTargetTextBox.Length == arrayTargetTextBoxIndex)
        {
            allowContinue = true;
        }
        else if (!allowContinue && playerInput)
        {
            textBox.text = targetTextBox;
            arrayTargetTextBoxIndex = arrayTargetTextBox.Length;
            allowContinue = true;
            audioSource.clip = talkSound;
            audioSource.Play();
        }


    }

    void say()
    {
        //Shows text + speaker
        //Waits for next input until continues to next command

        nameBox.text = script[scriptIndex + 1];
        targetTextBox = script[scriptIndex + 2];
        arrayTargetTextBox = targetTextBox.Split(" ");
        textBox.text = "";
        arrayTargetTextBoxIndex = 0;
        

        pastDialogue[2].text = pastDialogue[1].text;
        pastDialogue[1].text = pastDialogue[0].text;
        pastDialogue[0].text = script[scriptIndex + 2];
        pastName[2].text = pastName[1].text;
        pastName[1].text = pastName[0].text;
        pastName[0].text = script[scriptIndex + 1];

        scriptIndex += 3;
        continueScript = false;
        allowContinue = false;
    }

    void appear()
    {
        // Teleports Character
        // First one after code is the character
        // Second one is the location on the x axis
        // 7 in either direction starts to go out of bounds
        // 25 is considered to be the default "gone" spot

        if (script[scriptIndex + 1] == "Yoomtah")
        {
            Character1.Appear(script[scriptIndex + 2]);
        }

        else if (script[scriptIndex + 1] == "Kiane")
        {
            Character2.Appear(script[scriptIndex + 2]);
        }

        else
        {
            error(false);
        }

        scriptIndex += 3;
    }

    void move()
    {
        // Moves Character
        // Give speed to change how fast it moves
        // Want to find a way to just input the character's variable into a function
        // So that this whole segemnt can just be a function

        if (script[scriptIndex + 1] == "Yoomtah")
        {
            Character1.Move(script[scriptIndex + 2], script[scriptIndex + 3]);
        }

        else if (script[scriptIndex + 1] == "Kiane")
        {
            Character2.Move(script[scriptIndex + 2], script[scriptIndex + 3]);
        }

        else
        {
            error(false);
        }

        scriptIndex += 4;
    }

    void change()
    {
        if (script[scriptIndex + 1] == "Yoomtah")
        {
            Character1.Change(script[scriptIndex + 2]);
        }

        else if (script[scriptIndex + 1] == "Kiane")
        {
            Character2.Change(script[scriptIndex + 2]);
        }

        scriptIndex += 3;
    }

    void sound()
    {
        // Will be used to make sounds play
        scriptFinder.GetComponent<VN_SoundLibrary>().playSound(script[scriptIndex + 1]);
        scriptIndex += 2;
    }

    void branch(int branchPoint)
    {
        // Will be used to jump to different parts of the script

        scriptIndex = branchPoint;
    }

    void choice()
    {
        // Will be used to make descisions
        choiceUI.SetActive(true);
        choice1Text.text = script[scriptIndex + 1];
        choice1Index = int.Parse(script[scriptIndex + 2]);
        choice2Text.text = script[scriptIndex + 3];
        choice2Index = int.Parse(script[scriptIndex + 4]);

        continueScript = false;
        allowContinue = false;
    }

    public void choiceMade(int choiceNum)
    {
        // Will be used to make descisions

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


    void end()
    {
        // Will be used to end the script
        continueScript = false;
        allowContinue = false;
    }


    void togglePreDialogue()
    {
        PreviousDialogue.SetActive(!PreviousDialogue.activeSelf);
        allowContinue = !PreviousDialogue.activeSelf;
    }


    void error(bool advance)
    {
        // When a command doesn't execute properly the user is told
        // If no command executes then it will advance 1 index at a time
        // If a command executed but didn't have a target then it won't advance


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

    void advanceDialogue()
    {
        textBox.text += (arrayTargetTextBox[arrayTargetTextBoxIndex] += " ");

        audioSource.clip = talkSound;
        audioSource.Play();
        arrayTargetTextBoxIndex += 1;
    }



}
