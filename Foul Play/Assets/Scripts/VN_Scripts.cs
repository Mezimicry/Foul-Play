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

    // , "Disappear", "Name"
    // Sends character back to origin

    // , "End", "End Code"
    // Ends the VN segement
    // Will also pass the end code so the game knows how you did in the VN

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
    // , "Disappear", "Name"
    // , "End", "EndCode"
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
            "Appear", "Ebony", "-5" 
            , "Appear", "Fake Foul", "5"
            , "Change", "Ebony", "0"
            , "Disappear", "King Kavi"
            , "Say", "Ebony", "Hello Foul This is a Text Box"
            , "Move", "Ebony", "5", "3" 
            , "Move", "Fake Foul", "-5", "5" 
            , "Say", "Foul", "I am the villian of the game and by passing you I have now kidnapped you."
            , "Sound", "KianeYay" 
            , "Say", "Ebony", "Oh no. Please don't take me and dye my hair." 
            , "Change", "Ebony", "1" 
            , "Say", "Foul", "wtf i didn't do that \nhow did you do that" 
            , "Choice", "Foul is the king", "41", "Foul just looks awful", "51" 
            , "Disappear", "Fake Foul"
            , "Appear", "King Kavi" , "-5"
            , "Say", "Ebony", "Wait no thats not right pls go back"
            , "Branch", "0"
            , "Disappear", "Fake Foul" 
            , "Appear", "Foul" , "-5"
            , "Say", "Ebony", "No this is much worse."
            , "End", "Normal End" 
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
