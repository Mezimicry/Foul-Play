using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class VN_LogicScript : MonoBehaviour
{
    public Text textBox;
    public Text nameBox;
    int scriptIndex = 0;
    bool continueScript = true;
    public GameObject UI;
    public GameObject Character1;
    public GameObject Character2;

    string[] script = { "Move", "Say", "Yoomtah", "This is the first text box", "Say", "Kiane", "This is the second text box" };


    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(true);
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
            if (script[scriptIndex] == "Say")
            {
                //Shows text + speaker
                //Waits for next input until continues to next command
                
                nameBox.text = script[scriptIndex + 1];
                textBox.text = script[scriptIndex + 2];
                scriptIndex += 3;
                continueScript = false;
            }
            else if (script[scriptIndex] == "Appear")
            {
                //Spawns Character
                scriptIndex += 1;

            }
            else if (script[scriptIndex] == "Move")
            {
                //Moves Character
                //Should Slide
                scriptIndex += 1;

            }
            else 
            {
                //Something is wrong so will try to head to next command
                scriptIndex += 1;
            }



        }



    }

    
}
