using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VN_Scripts : MonoBehaviour
{
    //Templates

    // , "Say", "Name", "Text"
    // , "Appear", "Name" , "Location" 
    // , "Move", "Name" , "Location" , "Speed"
    // , "Change", "Name" , "SpriteNum" 
    // , "Sound", "SoundName"
    //



    public string[] returnScript(string scriptName)
    {
        if (scriptName == "Test")
        {
            string[] testScript =
            {
            "Appear", "Yoomtah", "-5",
            "Appear", "Kiane", "5",
            "Say", "Yoomtah", "This is the first text box. After this we will both move.",
            "Move", "Yoomtah", "5", "3",
            "Move", "Kiane", "-5", "5",
            "Say", "Kiane", "Wow how exciting!!!!! \n !!!!!!!!!!",
            "Sound", "KianeYay",
            "Say", "Yoomtah", "I will now change spites to be purple",
            "Change", "Yoomtah", "1",
            "Say", "Kiane", "Why don't I get a second sprite :'("
            };
            return testScript;
            
        }


        string[] errorScript =
        {
            "Say", "Phox", "The Script hasn't loaded. Oops"
        };
        return errorScript;
    }



}
