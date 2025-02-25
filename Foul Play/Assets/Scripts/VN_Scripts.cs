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
    // , "Branch", "NewScriptIndex"
    // , "Choice", "ChoiceText1", "ChoiceIndex1", "ChoiceText2", "ChoiceIndex2"
    // , "End"



    /* Max size for say is assumed to be
    Lorem ipsum odor amet, consectetuer adipiscing elit. Vulputate iaculis pellentesque efficitur et quam primis neque? Metus duis pellentesque congue sed blandit tempor aptent ac bibendum. Lobortis duis fames pretium mi fermentum. 
    If a line is longer than this then split it.

    */

    public string[] returnScript(string scriptName)
    {
        if (scriptName == "Test")
        {
            string[] testScript =
            {
            "Appear", "Yoomtah", "-5" //0
            , "Appear", "Kiane", "5" //3
            , "Say", "Yoomtah", "This is the first text box. After this we will both move." //6
            , "Move", "Yoomtah", "5", "3" //9
            , "Move", "Kiane", "-5", "5"  //13
            , "Say", "Kiane", "Wow how exciting!!!!! \n!!!!!!!!!!" //17
            , "Sound", "KianeYay" //20
            , "Say", "Yoomtah", "I will now change spites to be purple" //22
            , "Change", "Yoomtah", "1" //25
            , "Say", "Kiane", "Why don't I get a second sprite :'(" //28
            , "Choice", "Continue the loop", "36", "Kill them all", "41" //31
            , "Say", "Kiane", "Oh I've done this before" //36
            , "Branch", "0" //39
            , "Say", "Kiane", "Goodbye cruel world." //41
            , "End" //44
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
