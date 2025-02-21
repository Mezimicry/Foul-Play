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


    public GameObject scriptFinder;

    string[] script;


    int scriptIndex = 0;
    bool continueScript = true;

    public float talkSpeed = 0.001f;
    float timer;

    // Current way of giving control over the characters
    public GameObject Character1Object;
    VN_CharacterScript Character1;
    public GameObject Character2Object;
    VN_CharacterScript Character2;

   // string[] script = { "Appear", "Yoomtah" , "-5" , "Appear", "Kiane", "5" , "Say", "Yoomtah", "This is the first text box. After this we will both move.", "Move", "Yoomtah", "5", "3", "Move", "Kiane", "-5", "5", "Say", "Kiane", "Wow how exciting!!!!! \n !!!!!!!!!!", "Say", "Yoomtah", "I will now change spites to be purple", "Change", "Yoomtah", "1", "Say", "Kiane", "Why don't I get a second sprite :'(", };

    void Start()
    {
        script = scriptFinder.GetComponent<VN_Scripts>().returnScript("Test");

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
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) | UnityEngine.Input.GetKeyDown(KeyCode.Return) | UnityEngine.Input.GetMouseButtonDown(0))
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

            else if (script[scriptIndex] == "Choose")
            {
                choose();
            }

            else
            {
                error(true);
            }
        }

        timer += Time.deltaTime;
        if (arrayTargetTextBox.Length > arrayTargetTextBoxIndex && timer >= talkSpeed)
        {
            advanceDialogue();
            timer = 0;
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
        scriptIndex += 3;
        continueScript = false;
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

    void choose()
    {
        // Will be used to make descisions

        scriptIndex += 1;
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
    }

    void advanceDialogue()
    {
        textBox.text += (arrayTargetTextBox[arrayTargetTextBoxIndex] += " ");
        arrayTargetTextBoxIndex += 1;
    }



}
