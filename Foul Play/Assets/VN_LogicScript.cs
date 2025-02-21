using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.Windows;
using static UnityEngine.ParticleSystem;

public class VN_LogicScript : MonoBehaviour
{
    public Text textBox;
    public Text nameBox;
    int scriptIndex = 0;
    bool continueScript = true;
    public GameObject UI;
    public GameObject Character1;
    public VN_CharacterScript Character1Logic;
    public GameObject Character2;
    public VN_CharacterScript Character2Logic;

    //Templates

    // "Say", "Name", "Text",
    // "Appear", "Name" , "Location" ,
    // "Move", "Name" , "Location" , "Speed",
    //
    //
    //

    string[] script = { "Appear", "Yoomtah" , "-5" , "Appear", "Kiane", "5" , "Say", "Yoomtah", "This is the first text box. After this we will both move", "Move", "Yoomtah", "5", "3", "Move", "Kiane", "-5", "5", "Say", "Kiane", "Wow how exciting!!!!! \n !!!!!!!!!!" };

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(true);
        Character1Logic = GameObject.FindGameObjectWithTag("Character1").GetComponent<VN_CharacterScript>();
        Character2Logic = GameObject.FindGameObjectWithTag("Character2").GetComponent<VN_CharacterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) | UnityEngine.Input.GetKeyDown(KeyCode.Return))
        {
            continueScript = true;

        }

        if (continueScript) 
        {
            bool somethingWrong = true;
            if (script[scriptIndex] == "Say")
            {
                //Shows text + speaker
                //Waits for next input until continues to next command
                
                nameBox.text = script[scriptIndex + 1];
                textBox.text = script[scriptIndex + 2];
                scriptIndex += 3;
                continueScript = false;
                somethingWrong = false;
            }
            else if (script[scriptIndex] == "Appear")
            {
                //Spawns Character
                //First one after code is the character
                //Second one is the location on the x axis
                // 7 in either direction starts to go out of bounds
                // 25 is considered to be the default "gone" spot

                if (script[scriptIndex + 1] == "Yoomtah")
                {
                    Character1Logic.Appear(script[scriptIndex + 2]);
                    somethingWrong = false;
                }
                else if (script[scriptIndex + 1] == "Kiane")
                {
                    Character2Logic.Appear(script[scriptIndex + 2]);
                    somethingWrong = false;
                }
                    scriptIndex += 3;
                

            }
            else if (script[scriptIndex] == "Move")
            {
                //Moves Character
                //Give speed to change how fast it moves
                if (script[scriptIndex + 1] == "Yoomtah")
                {
                    Character1Logic.Move(script[scriptIndex + 2], script[scriptIndex + 3]);
                    somethingWrong = false;
                }
                else if (script[scriptIndex + 1] == "Kiane")
                {
                    Character2Logic.Move(script[scriptIndex + 2], script[scriptIndex + 3]);
                    somethingWrong = false;
                }
                scriptIndex += 4;

            }
            if (somethingWrong)
            {
                //Something is wrong so will try to head to next command
                nameBox.text = "Phox";
                textBox.text =  "Something went wrong on line " + scriptIndex;
                continueScript = false;
                scriptIndex += 1;
            }
        }
    }
}
