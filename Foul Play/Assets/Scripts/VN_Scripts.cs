using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
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
    // {"New Script", "ScriptName" , "", "", "", "", "", "", ""},



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
            {"Say", "Foul", "I am the <color=red>villian</color> <color=red>of</color> <color=red>the</color> <color=red>game</color> and by passing you I have now kidnapped you." , ""  , "" , "", "", "", "" },
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


        // This script is for when the player first meets clayton
        if (scriptName == "Clayton Meeting")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Clayton" , "5", "", "", "", "", "", ""},
            {"Say", "Ebony" , "What's this clay guy doing in my room? Oi, Mr. Clay! What's your deal?", "", "", "", "", "", ""},
            {"Say", "Clay Doll" , "...", "", "", "", "", "", ""},
            {"Say", "Ebony" , "The engraving here says \"Clayton\". Is that your name? Clayton?", "", "", "", "", "", ""},
            {"Say", "Clayton" , "...", "", "", "", "", "", ""},
            {"Say", "Ebony" , "UGH! I'm getting nowhere like this. Let's try a different approach...", "", "", "", "", "", ""},
            {"Choice", "Promise he'll be alright" , "DifferentApproachSweet", "Sick of the silent treatment", "DifferentApproachSadistic", "Keep your secrets" , "DifferentApproachSassy", "WAKE UP", "DifferentApproachStrong"},
            {"Branch Point", "DifferentApproachSweet" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Come on, Clayton! I won't hurt you, promise. There's nothing to be afraid of. Let's just chat, kay?", "", "", "", "", "", ""},
            {"Say", "Clayton" , "*snore*", "", "", "", "", "", ""},
            {"Say", "Ebony" , "He's asleep?! Well I guess I'd better let him rest...", "", "", "", "", "", ""},
            {"End", "Sweet Dreams Clayton" , "", "", "", "", "", "", ""},
            {"Branch Point", "DifferentApproachSadistic" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "I'm getting real sick of the silent treatment, pal. Give me one good reason why I shouldn't shatter you on the ground right now?", "", "", "", "", "", ""},
            {"Say", "Clayton" , "*snore*", "", "", "", "", "", ""},
            {"Say", "Ebony" , "You've gotta be fuckin' kidding me! The bugger's asleep! The only reason I'm not gonna kick your ceramic head in is because there's hundreds of better things to kick. But when I run out, you're next!", "", "", "", "", "", ""},
            {"End", "Sadistic Dreams Clayton" , "", "", "", "", "", "", ""},
            {"Branch Point", "DifferentApproachSassy" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Fine! Keep your secrets! I bet some cheap clay doll like yourself probably hasn't seen or heard of anything worth my time!", "", "", "", "", "", ""},
            {"Say", "Clayton" , "*snore*", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Shit, seriously? He's asleep? No wonder my sass didn't work, the bugger can't hear me. I guess I'd better leave him alone, for now.", "", "", "", "", "", ""},
            {"End", "Sassy Dreams Clayton" , "", "", "", "", "", "", ""},
            {"Branch Point", "DifferentApproachStrong" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "USHABTI!!! WAKE UP!!! PLEASE???", "", "", "", "", "", ""},
            {"Say", "Clayton" , "*snore*", "", "", "", "", "", ""},
            {"Say", "Ebony" , "I must've woken up half the realm with that shout and he didn't move an inch... definitely asleep. I'll save myself from a sore throat and leave him be. I can't be asked to shout anymore.", "", "", "", "", "", ""},
            {"End", "Strong Dreams Clayton" , "", "", "", "", "", "", ""}
            };
            return script;
        }

        // When the player gives clayton an unwanted item
        if (scriptName == "Ungrateful Clayton")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Clayton" , "5", "", "", "", "", "", ""},
            {"Say", "Ebony" , "I, uh, thought you might want this. Maybe.", "", "", "", "", "", ""},
            {"Say", "Clayton" , "...", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Ungrateful little shit...", "", "", "", "", "", ""},
            {"End", "Ungrateful Clayton <--- Little Shit" , "", "", "", "", "", "", ""}
            };
            return script;
        }

        //When clayton gets the item that the greedy bastard wants
        if (scriptName == "Grateful Clayton")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Clayton" , "5", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Pretty sure you were dreaming about this? Not sure how that works, but here you are.", "", "", "", "", "", ""},
            {"Say", "Clayton" , "Mmmm. Emperor Foul is a gluttonous man. Spill his food from the fridge, and he is sure to be upset.", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Holy fuck! He talks! Got any more advice for me?", "", "", "", "", "", ""},
            {"Say", "Clayton" , "Bring me something tomorrow. Maybe then we can talk.", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Oh great... now I'm a clay figure's servant...", "", "", "", "", "", ""},
            {"End", "Grateful Clayton" , "", "", "", "", "", "", ""}
            };
            return script;
        }



        // When you first meet basil
        if (scriptName == "Basil Original Offer")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Basil" , "5", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Oh, hello.", "", "", "", "", "", ""},
            {"Say", "Basil" , "My oh my! You must be the emperor's bride-to-be! He's talked a lot about you these last few months, it's wonderful to finally meet you. The name's Basil, darling, and I'm the chef around these parts.", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Yeah, that makes sense. I doubt Foul would cook his own meals.", "", "", "", "", "", ""},
            {"Say", "Basil" , "Ha! Ain't that the truth? I cook three square meals for every single one of the slobs that live here, and I don't get so much as a thank you! If I didn't know any better, I'd think they didn't like my cooking!", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Ha, yeah... um... what're you cooking in that pot? It certainly looks like... food? I think?", "", "", "", "", "", ""},
            {"Say", "Basil" , "Ah you've got a keen eye, child! That right there is my famous Basil Stew, the recipe's a secret but since I'm so soft-hearted like that, I'll let you have a spoonful. This is gonna be the next big thing I tell you, so don't miss this opportunity!", "", "", "", "", "", ""},
            {"2Choice", "Try Some" , "Accept Offer", "Refuse", "Refuse Offer", "", "", "", ""},
            {"Branch Point", "Accept Offer" , "", "", "", "", "", "", ""},
            {"New Script", "Basil Offer Accepted" , "", "", "", "", "", "", ""},
            {"Branch Point", "Refuse Offer" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Yeah, I think I'll pass thanks.", "", "", "", "", "", ""},
            {"Say", "Basil" , "Suit yourself my dear, but I'm tellin' you that this is gonna be the next big thing in the culinary world. You'll regret this decision someday, I assure you. I'll save you a slice if you change your mind.", "", "", "", "", "", ""},
            {"Say", "Ebony" , "(I don't think stew is meant to have slices...)", "", "", "", "", "", ""},
            {"End", "Refused Offer" , "", "", "", "", "", "", ""}
            };
            return script;
        }

        // When you return to basil without accepting the offer
        if (scriptName == "Basil Repeated Offer")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Basil" , "5", "", "", "", "", "", ""},
            {"Say", "Basil" , "I see you could not resist the allure of my special Basil Stew! Ready to try some?", "", "", "", "", "", ""},
            {"2Choice", "Accept" , "Accept Offer", "Refuse", "Refuse Offer", "", "", "", ""},
            {"Branch Point", "Accept Offer" , "", "", "", "", "", "", ""},
            {"New Script", "Basil Offer Accepted" , "", "", "", "", "", "", ""},
            {"Branch Point", "Refuse Offer" , "", "", "", "", "", "", ""},
            {"Say", "Basil" , "Indecisive, aren't we? Well my previous offer remains, darling. And I assure you it's quite delicious.", "", "", "", "", "", ""},
            {"End", "Refused Offer" , "", "", "", "", "", "", ""}
            };
            return script;
        }

        // When you accept the offer
        if (scriptName == "Basil Offer Accepted")
        {
            string[,] script =
            {
            {"Say", "Narrator" , "You take a bite. It's sour, sweet yet spicy all at the same time. It has the consistency of wet cement, and you crunch down on something hard, yet soft all at the same time. You receive -10 TASTE BUDS. Basil's food is so bad, it added an extra stat to the game.", "Ok Monster Prom Narrator", "", "", "", "", ""},
            {"Say", "Basil" , "So, Ebony. What do you think? Like it?", "", "", "", "", "", ""},
            {"Choice", "Compliment the chef" , "Critic Sweet", "Be Brutally Honest", "Critic Sadistic", "Put him down gently" , "Critic Sassy", "Try to compliment the taste", "Critic Strong"},
            {"Branch Point", "Critic Sweet" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Well... I can tell you put a lot of heart and soul into this dish, Basil. Thank you for letting me try it.", "", "", "", "", "", ""},
            {"Affinity", "Basil" , "2", "", "", "", "", "", ""},
            {"Say", "Basil" , "Well aren't you the sweetest? The emperor's lucky to have a real brainiac by his side, since you even guessed the secret ingredient!", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Wait, I did?", "", "", "", "", "", ""},
            {"Say", "Basil" , "Oh come on, don't be getting shy! It's as you said, I put a lot of hearts and souls into my food! Didn't you ever wonder why the castle seems so empty all the time?", "", "", "", "", "", ""},
            {"Say", "Ebony" , "(I think I'm gonna be sick...)", "", "", "", "", "", ""},
            {"Say", "Basil" , "How good is that? Some blind basilisk that crawled out of the sewers becomes a chef worthy of our future empress. Talk about a diamond in the rough, huh?", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Wait a second, you're blind? How do you make food when you can't see?", "", "", "", "", "", ""},
            {"Say", "Basil" , "That's just the thing, darling! I have the heart of a chef, you see.  I don't need to see the ingredients, I just simply know exactly what a meal needs. Call it chef's intuition.", "", "", "", "", "", ""},
            {"Say", "Basil" , "Actually on the topic of that, I'm kinda tied up here with this stew, but at the same time I need to grab some ingredients to prepare Foul's favourite snack as a celebratory gift. Think you could get it for me?", "", "", "", "", "", ""},
            {"Branch", "Give Quest" , "", "", "", "", "", "", ""},
            {"Branch Point", "Critic Sassy" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Yeah, no. Basil I'm sorry but this is nasty. No one's gonna want to eat this.", "", "", "", "", "", ""},
            {"Affinity", "Basil" , "-2", "", "", "", "", "", ""},
            {"Say", "Basil" , "Sticks and stones, darling. But man do your words hurt! My cooking's going to be a sensation! I'm sorry you just don't have the culinary vision to see that.", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Maybe you could try following a recipe of some kind? Like something real simple, like uh, a sandwich? Surely you've got a recipe book around here somewhere...", "", "", "", "", "", ""},
            {"Say", "Basil" , "Well considering I'm blind, I don't imagine a book would be much help to me. Also the *emperor can't read*, so you'd be hard pressed to find a book anywhere around here. True cooking is done through the soul, and my soul always knows what ingredients are needed when and where.", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Right, of course...", "", "", "", "", "", ""},
            {"Say", "Basil" , "If you're interested in getting back in my good books, I do have a job for you. I'm kinda tied up here with this stew, but at the same time I need to grab some ingredients to prepare Foul's favourite snack as a celebratory gift. Think you could get it for me?", "", "", "", "", "", ""},
            {"Branch", "Give Quest" , "", "", "", "", "", "", ""},
            {"Branch Point", "Critic Sadistic" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "How is this even possible? Like this is genuinely impressive that anyone could make food this bad. If you threw yourself into the pot, it'd probably taste better.", "", "", "", "", "", ""},
            {"Affinity", "Basil" , "1", "", "", "", "", "", ""},
            {"Say", "Basil" , "Awww, thank you! That's exactly what everyone else says, and I know They're just too shy to be nice about my cooking. It's cool I get it, being stoic and all that. You'll fit right in here with the rest of us.", "", "", "", "", "", ""},
            {"Say", "Ebony" , "No, you idiot! I'm saying your stew was shit! Aren't you listening to me?", "", "", "", "", "", ""},
            {"Say", "Basil" , "Alright, alright, simmer down young lady! It's ok if you liked my stew there's no need to get all upset about it, I really do understand how you people work.", "", "", "", "", "", ""},
            {"Say", "Ebony" , "I don't think you get much of anything at all...", "", "", "", "", "", ""},
            {"Say", "Basil" , "You're just like the emperor, you know that? Foul always pretends to had the phoenix breast sandwich I make for him, but I know deep down it's just a bit of tough love. He goes all \"Basil! You are the worst cook in all the lands!\" but I know he's just being shy.", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Oh geez, that sounds awful. Why do you let him say that stuff about you? I have a feeling he maybe really does hate you cooking.", "", "", "", "", "", ""},
            {"Say", "Basil" , "... no that... that can't be right. Well, how about we find out once and for all? As a celebration of his engagement to you, let's make him the best phoenix breast sandwich he's ever had! Since I'm blind I can't exactly see the ingredients, but if you can get them for me, I'll whip up something yummy.", "", "", "", "", "", ""},
            {"Branch", "Give Quest" , "", "", "", "", "", "", ""},
            {"Branch Point", "Critic Strong" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "This is... wonderful! There's so many, uh, flavours and textures and stuff! It's like a mystery novel but as a stew, you never know what you might bite into!", "", "", "", "", "", ""},
            {"Affinity", "Basil" , "-1", "", "", "", "", "", ""},
            {"Say", "Basil" , "You're a really bad liar you know that? What kind of chef wants their food compared to a book? Especially a mystery novel! I hate mystery novels!", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Oh I'm sorry... I just didn't want you to be upset I suppose. Your food tastes so bad I wanted to vomit it back up. I don't even know how you managed to make it taste like that. It's almost impressive.", "", "", "", "", "", ""},
            {"Say", "Basil" , "They're so confusing and never make any sense at the end! How can anyone enjoy them?", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Excuse me?", "", "", "", "", "", ""},
            {"Say", "Basil" , "What? Oh sorry I thought we were still on mystery novels. Did you say something?", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Ehhhh... no. No I didn't. Don't worry about it.", "", "", "", "", "", ""},
            {"Say", "Basil" , "I need to do some cooking to get my mind off of mystery novels. Maybe you can redeem yourself by giving blind old me a hand?", "", "", "", "", "", ""},
            {"Branch", "Give Quest" , "", "", "", "", "", "", ""},
            {"Branch Point", "Give Quest" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Sure, what do you need?", "", "", "", "", "", ""},
            {"Say", "Basil" , "I'm gonna need <color=red>White</color> <color=red>Bread</color>, <color=red>Phoenix</color> <color=red>Breast</color>, <color=red>Devil's</color> <color=red>Lettuce</color>, <color=red>Crystal</color> <color=red>Apple</color> and <color=red>Carolina</color> <color=red>Reaper</color> <color=red>Sauce</color>. The Phoenix Breast Sandwich is his favourite, but those little rascals who eat my food hid the ingredients across the castle. If I didn't know any better, I'd almost think they were trying to stop me from cooking! Ha!", "This dialogue is so long due to all of the colour tags", "", "", "", "", ""},
            {"Say", "Ebony" , "Right...", "", "", "", "", "", ""},
            {"Say", "Basil" , "Ah now hold on! One last thing, my child! Make sure to get the ingredients I asked for, since I'm blind I can't exactly tell the difference. If you gave the emperor something like Moldy Bread, Bleach or an Angelic Apple he'd get real sick. So definitely follow my instructions, ok?", "", "", "", "", "", ""},
            {"Say", "Ebony" , "I'll follow them to the letter, Bas... to the letter...", "", "", "", "", "", ""},
            {"Say", "Basil" , "Anyone ever tell you you've got a conniving resting face? Always looks like you're hatching some kind of evil plot. No wonder the emperor loves you! You have a nice day now, hun!", "", "", "", "", "", ""},
            {"End", "Quest Accepted" , "", "", "", "", "", "", ""}
            };
            return script;
        }

        // When you give basil the correct ingredients
        if (scriptName == "Turn In Right")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Basil" , "5", "", "", "", "", "", ""},
            {"Say", "Basil" , "Is that you, Ebony? Did you get those ingredients?", "", "", "", "", "", ""},
            {"2Choice", "Yes" , "Hand In", "No", "Hand Out", "", "", "", ""},
            {"Branch Point", "Hand Out" , "", "", "", "", "", "", ""},
            {"Say", "Basil" , "Alright, but be quick! We'll need to get this meal done before the emperor comes back home.", "", "", "", "", "", ""},
            {"End", "Didn't Hand In" , "", "", "", "", "", "", ""},
            {"Branch Point", "Hand In" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Here they are, just as you asked.", "", "", "", "", "", ""},
            {"Say", "Basil" , "Oh darling you are a superstar! I'll get to work on it right away! It should be ready in time for dinner, thanks for all the help!", "", "", "", "", "", ""},
            {"End", "Right Ingredients" , "", "", "", "", "", "", ""}
            };
            return script;
        }

        // When you give basil the wrong ingredients
        if (scriptName == "Turn In Wrong")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Basil" , "5", "", "", "", "", "", ""},
            {"Say", "Basil" , "Is that you, Ebony? Did you get those ingredients?", "", "", "", "", "", ""},
            {"2Choice", "Yes" , "Hand In", "No", "Hand Out", "", "", "", ""},
            {"Branch Point", "Hand Out" , "", "", "", "", "", "", ""},
            {"Say", "Basil" , "Alright, but be quick! We'll need to get this meal done before the emperor comes back home.", "", "", "", "", "", ""},
            {"End", "Didn't Hand In" , "", "", "", "", "", "", ""},
            {"Branch Point", "Hand In" , "", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Here they are, just as you asked.", "", "", "", "", "", ""},
            {"Say", "Basil" , "These... don't feel like my usual ingredients... you sure you got the right stuff, hun?", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Sure as can be, Basil.", "", "", "", "", "", ""},
            {"Say", "Basil" , "Ok then... the sandwich should be ready in time for dinner. See you then!", "", "", "", "", "", ""},
            {"End", "Wrong Ingredients" , "", "", "", "", "", "", ""}
            };
            return script;
        }

        // Repeatedly talking to basil after the quest
        if (scriptName == "Basil Repeat 1")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Basil" , "5", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Is the sandwich done yet?", "", "", "", "", "", ""},
            {"Say", "Basil" , "Not yet, darling! You can't rush art!", "", "", "", "", "", ""},
            {"End", "Wasting Basil's Time" , "", "", "", "", "", "", ""}
            };
            return script;
        }
        if (scriptName == "Basil Repeat 2")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Basil" , "5", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Is the sandwich done yet?", "", "", "", "", "", ""},
            {"Say", "Basil" , "Uh, it's progress hasn't moved that much since the last time you asked... just give me a bit more time, ok?", "", "", "", "", "", ""},
            {"End", "Wasting Basil's Time" , "", "", "", "", "", "", ""}
            };
            return script;
        }
        if (scriptName == "Basil Repeat 3")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Basil" , "5", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Is the sandwich done yet?", "", "", "", "", "", ""},
            {"Say", "Basil" , "Ebony... please... if you keep asking, it's not going to go faster.", "", "", "", "", "", ""},
            {"End", "Wasting Basil's Time" , "", "", "", "", "", "", ""}
            };
            return script;
        }
        if (scriptName == "Basil Repeat 4")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Basil" , "5", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Is the sandwich done yet?", "", "", "", "", "", ""},
            {"Say", "Basil" , "Ebony I swear to Foul! If you do not leave this kitchen at once there will be... serious consequences!", "", "", "", "", "", ""},
            {"End", "Wasting Basil's Time" , "", "", "", "", "", "", ""}
            };
            return script;
        }
        if (scriptName == "Basil Repeat 5")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Basil" , "5", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Is the sandwich done yet?", "", "", "", "", "", ""},
            {"Say", "Basil" , "Please... leave me alone...", "", "", "", "", "", ""},
            {"End", "Wasting Basil's Time" , "", "", "", "", "", "", ""}
            };
            return script;
        }
        if (scriptName == "Basil Repeat 6")
        {
            string[,] script =
            {
            {"Appear", "Ebony" , "-5", "", "", "", "", "", ""},
            {"Appear", "Basil" , "5", "", "", "", "", "", ""},
            {"Say", "Ebony" , "Is the sandwich done yet?", "", "", "", "", "", ""},
            {"Say", "Basil" , "*sob*", "", "", "", "", "", ""},
            {"End", "Wasting Basil's Time" , "", "", "", "", "", "", ""}
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
