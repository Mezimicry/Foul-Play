using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VN_Scripts : MonoBehaviour
{
    // Templates with explainations

    // , "Appear", "Name" , "Location" 
    // Moves the character instantly

    // , "Branch", "NewScriptIndex"
    // Changes location in the script

    // , "Change", "Name" , "SpriteNum" 
    // Changes the diresired character's sprite

    // , "Choice", "ChoiceText1", "ChoiceIndex1", "ChoiceText2", "ChoiceIndex2"
    // Gives the player 2 options that will send them to different parts of the script

    // , "End"
    // Ends the VN segement

    // , "Move", "Name" , "Location" , "Speed"
    // Moves the character over time

    // , "Say", "Name", "Text"
    // Show dialogue
    /* Max size for say is assumed to be the same as
    Lorem ipsum odor amet, consectetuer adipiscing elit. Vulputate iaculis pellentesque efficitur et quam primis neque? Metus duis pellentesque congue sed blandit tempor aptent ac bibendum. Lobortis duis fames pretium mi fermentum. 
    If a line is longer than this then split it.
    */

    // , "Sound", "SoundName"
    // Play sound effects


    // Plain templates

    // , "Appear", "Name" , "Location" 
    // , "Branch", "NewScriptIndex"
    // , "Change", "Name" , "SpriteNum" 
    // , "Choice", "ChoiceText1", "ChoiceIndex1", "ChoiceText2", "ChoiceIndex2"
    // , "End"
    // , "Move", "Name" , "Location" , "Speed"
    // , "Say", "Name", "Text"
    // , "Sound", "SoundName"



    // This is called along with the name of a script
    // It will then return the wanted script or an error
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
            , "Sound", "Kianeay" //20
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
