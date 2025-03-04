using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VN_Scripts : MonoBehaviour
{
    // Templates with explainations

    // {"Appear", "Name", "Location" , "", "", "", "", "", ""},
    // Moves the character instantly

    // {"Branch", "PointName" , "", "", "", "", "", "", ""},
    // Changes location in the script

    // {"Branch Point", "PointName" , "", "", "", "", "", "", ""},
    // Saves a name for a location to branch to

    // {"Change", "Name" , "SpriteNum" , "", "", "", "", "", ""},
    // Changes the diresired character's sprite

    // {"Choice", "SweetText", "SweetIndex", "SadisticText", "SadisticIndex", "SassyText", "SassyIndex", "StrongText", "StrongIndex"},
    // Gives the player 2 options that will send them to different parts of the script

    // {"Disappear", "Name" , "", "", "", "", "", "", ""},
    // Sends character back to origin

    // {"End", "End Code" , "", "", "", "", "", "", ""},
    // Ends the VN segement
    // Will also pass the end code so the game knows how you did in the VN

    // {"Move", "Name" , "Location" , "Speed" , "", "", "", "", ""},
    // Moves the character over time

    // {"Say", "Name", "Text" , "", "", "", "", "", ""},
    // Show dialogue
    /* Max size for say is assumed to be the same as
    Lorem ipsum odor amet, consectetuer adipiscing elit. Vulputate iaculis pellentesque efficitur et quam primis neque? Metus duis pellentesque congue sed blandit tempor aptent ac bibendum. Lobortis duis fames pretium mi fermentum. 
    If a line is longer than this then split it.
    */

    // {"Sound", "SoundName" , "", "", "", "", "", "", ""},
    // Play sound effects


    // Plain templates

    // {"Appear", "Name", "Location" , "", "", "", "", "", ""},
    // {"Branch", "NewScriptIndex" , "", "", "", "", "", "", ""},
    // {"Branch Point", "PointName" , "", "", "", "", "", "", ""},
    // {"Change", "Name" , "SpriteNum" , "", "", "", "", "", ""},
    // {"Choice", "SweetText", "SweetIndex", "SadisticText", "SadisticIndex", "SassyText", "SassyIndex", "StrongText", "StrongIndex"},
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

        // The start of the game when foul's true form is revealed and tells the princess about how they'll get married
        if (scriptName == "Foul Revealed")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Foul" , "5", "", "", "", "", "", ""},
            {"Say", "Ebony" , "So... this form... this is the real you, huh?", "", "", "", "", "", ""},
            {"Say", "Foul" , "Yes! Dashing, aren't I?", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Yeah dashing right... you've been pretty hush-hush about our world domination plans, maybe we should talk about that?", "", "", "", "", "", ""},
            {"Say", "Foul" , "Oh, that? Pssht come on! Look at this delicious feast I've prepared for you! Doesn't it make you want to just forget about your troubles (and world domination) and just go with the flow?", "", "", "", "", "", ""},
            {"Choice", "Enjoy The Food" , "DistractSweet", "Spill the Beans", "DistractSadistic", "Cut the Bullshit" , "DistractSassy", "Tell Me", "DistractStrong"},
            {"Branch Point", "DistractStrong" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Um, no? I think I want to hear about this right now actually!", "", "", "", "", "", ""},
            {"Say", "Foul" , "Ok listen... I was maybe thinking we... don't dominate the earth? Maybe? I've got something even better in mind...", "", "", "", "", "", ""},
            {"Say", "Ebony" , "We... we're not dominating the earth? Seriously? That's like, the whole reason I'm here. Your other idea had better be conquering the universe or something...", "", "", "", "", "", ""},
            {"Branch", "Marriage Reveal" , "", "", "", "", "", "", ""},
            {"Branch Point", "DistractSweet" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Well, this feast is pretty intricate... I guess I could afford to enjoy it for a bit.", "", "", "", "", "", ""},
            {"Say", "Foul" , "See! Everything's good and fine and stuff! My world domination plan is like, totally there, and we're gonna get started soon...", "", "", "", "", "", ""},
            {"Say", "Ebony" , "You'd better not be lying Foul... but I think I'll take you at your word for now.", "", "", "", "", "", ""},
            {"End", "Doesn't know about marriage" , "", "", "", "", "", "", ""},
            {"Branch Point", "DistractSassy" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Alright cut the bullshit, Foul. You don't actually have anything prepared do you? You lying cheat!", "", "", "", "", "", ""},
            {"Say", "Foul" , "Hey, hey! I never promised you that we'd take over the world! You just made that up! I may be a liar and a cheat, but this time I'm innocent!", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Oh yeah... I guess that's... true... but still we should like, totally conquer the world. We can whip your army into shape, give you a bath it'll be fun!", "", "", "", "", "", ""},
            {"End", "Doesn't know about marriage" , "", "", "", "", "", "", ""},
            {"Branch Point", "DistractSadistic" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "You'd better spill the beans on this plan of yours Foul. If I suspect that you're lying to me again...", "", "", "", "", "", ""},
            {"Say", "Foul" , "Hey easy on the threats, toots. I never lied about taking over the world, you just assumed that. So how's about we cool it with the attitude, yeah?", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Urgh... dominating the earth is like, the whole reason I'm even here! Alright then Foul, what did you have in mind?", "", "", "", "", "", ""},
            {"Branch", "Marriage Reveal" , "", "", "", "", "", "", ""},
            {"Branch Point", "Marriage Reveal" , "", "", "", "", "", "", ""},
            {"Say", "Foul" , "Something even better! I've arranged for us to be married in seven days time, and we'll live together forever and ever and ever in the Demon Realm! Isn't that lovely?", "", "", "", "", "", ""},
            {"End", "Does knows about marriage" , "", "", "", "", "", "", ""}
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
