using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VN_Scripts : MonoBehaviour
{
    // Plain templates

    // {"Affinity", "Character" , "Direction", "Amount", "", "", "", "", ""},
    // {"Appear", "Name", "Location" , "", "", "", "", "", ""},
    // {"Branch", "NewScriptIndex" , "", "", "", "", "", "", ""},
    // {"Branch Point", "PointName" , "", "", "", "", "", "", ""},
    // {"Change", "Name" , "SpriteNum" , "", "", "", "", "", ""},
    // {"Choice", "SweetText", "SweetIndex", "SadisticText", "SadisticIndex", "SassyText", "SassyIndex", "StrongText", "StrongIndex"},
    // {"2Choice", "FirstText", "FirstIndex", "SecondText", "SecondIndex", "", "", "", ""},
    // {"Disappear", "Name" , "", "", "", "", "", "", ""},
    // {"End", "End Code" , "", "", "", "", "", "", ""},
    // {"Move", "Name" , "Location" , "Speed" , "", "", "", "", ""},
    // {"Say", "Name", "Text" , "", "", "", "", "", ""},
    // {"Sound", "SoundName" , "", "", "", "", "", "", ""},




    // This is called along with the name of a script
    // It will then return the wanted script or an error
    /// <summary>
    /// Call to obtain the script that is passed into it
    /// </summary>
    /// <param name="scriptName"></param>
    /// <returns>Either the wanted script or an error script</returns>
    public string[,] returnScript(string scriptName)
    {
        if (scriptName == "Test")
        {
            string[,] script =
            {
            {"Branch Point", "Start" , "", "", "", "", "", "", ""}, 
            {"Appear", "Ebony", "-5" , "", "", "", "", "", ""},
            {"Appear", "Fake Foul", "5" , "", "", "", "", "", ""},
            {"Say", "Ebony", "Hello Foul This is a Text Box" , ""  , "", "", "", "", ""  },
            {"Move", "Ebony", "5", "3"  , "", "", "", "", "" },
            {"Move", "Fake Foul", "-5", "5"  , "", "", "", "", "" },
            {"Say", "Foul", "I am the villian of the game and by passing you I have now kidnapped you." , ""  , "" , "", "", "", "" },
            {"Sound", "KianeYay"  , ""  , "" , "", "", "", "", "" },
            {"Say", "Ebony", "Oh no. Please don't take me and dye my hair." , ""  , "", "", "", "", "" },
            {"Change", "Ebony", "1"  , ""  , "", "", "", "", "" },
            {"Say", "Foul", "wtf i didn't do that \nhow did you do that"  , ""  , "" , "", "", "", ""},
            {"Affinity", "Foul" , "3", "", "", "", "", "", ""},
            {"Choice", "Foul is the king", "FoulKing", "Foul just looks awful", "FoulBad", "Foul is the king", "FoulKing", "Foul just looks awful", "FoulBad" },
            {"Branch Point", "FoulKing" , "", "", "", "", "", "", ""},
            {"Disappear", "Fake Foul" , ""  , ""  , "" , "", "", "", "" },
            {"Appear", "King Kavi" , "-5"  , ""  , "", "", "", "", "" },
            {"Say", "Ebony", "Wait no thats not right pls go back"  , ""  , "", "", "", "", "" },
            {"Change", "Ebony", "0" , "" , "", "", "", "", ""  },
            {"Disappear", "King Kavi" , "" , ""  , "", "", "", "", ""  },
            {"Branch", "Start" , "", "", "", "", "", "", "" },
            {"Branch Point", "FoulBad" , "", "", "", "", "", "", ""},
            {"Disappear", "Fake Foul"  , ""  , ""  , "", "", "", "", "" },
            {"Appear", "Foul" , "-5"  , ""  , "", "", "", "", "" },
            {"Say", "Ebony", "No this is much worse." , ""  , "", "", "", "", ""  },
            {"End", "Normal End"  , ""  , ""  , "", "", "", "", "" },
            };
            return script;
        }

        



        string[,] errorScript =
        {
            { "Say", "Phox", "The Script hasn't loaded. Oops"  , ""  , "" , "", "", "", ""},
            { "End", "NoScript"  , ""  , ""  , "", "", "", "", "" }
        };
        return errorScript;
    }



}
