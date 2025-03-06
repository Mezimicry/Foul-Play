using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

// The gameManager is used to pass variables between scenes.
// You can call it by doing this
// gameManager.function();
// You can add stuff but please do not change stuff you didn't add as things might go wrong


public static class gameManager
{
    // Stores if the game is paused so other scenes can stop
    public static bool Main_paused = false;

    // Stores the current volume settings
    public static float Main_masterVolume = 50;
    public static float Main_musicVolume = 50;
    public static float Main_soundEffectVolume = 50;

    // Stores what music should be playing
    public static string Main_wantedMusic = "Title Screen";

    // Stores what script the VN should play
    public static string VN_scriptName = "NoScript";

    // Stores the last VN Exit code
    public static string VN_exitCode = "NoExitCode";

    // If true then the exit code has changed and the VN has ended
    // When gotten as true it will then be set as false
    public static bool VN_checkExitCode = false;


    /// <summary>
    /// Stores what script the VN will open
    /// </summary>
    /// <param name="wantedScript"></param>
    public static void setVN_Script(string wantedScript)
    {
        VN_scriptName = wantedScript;
    }
    /// <summary>
    /// Gets which script the VN should load
    /// </summary>
    public static string getVN_Script()
    {
        return VN_scriptName;
    }

    

    /// <summary>
    /// Sets the current exit code
    /// </summary>
    /// <param name="exitCode"></param>
    public static void setVN_exitCode(string exitCode)
    {
        VN_exitCode = exitCode;
    }
    /// <summary>
    /// Gets the current exit code so that other scenes can know what happened in the VN
    /// </summary>
    public static string getVN_exitCode()
    {
        return VN_exitCode;
    }

    public static void setVN_checkExitCode(bool checkExitCode)
    {
        VN_checkExitCode = checkExitCode;
    }
    /// <summary>
    /// Gets the current exit code so that other scenes can know what happened in the VN
    /// </summary>
    public static bool getVN_checkExitCode()
    {
        if (VN_checkExitCode == true)
        {
            VN_checkExitCode = false;
            return true;
        }
        return false;
    }



    /// <summary>
    /// Changes what music is going to be playing
    /// </summary>
    /// <param name="wantedMusic"></param>
    public static void setMain_wantedMusic(string wantedMusic)
    {
        Main_wantedMusic = wantedMusic;
    }
    /// <summary>
    /// Used to get the currently playing music
    /// </summary>
    public static string getMain_wantedMusic()
    {
        return Main_wantedMusic;
    }



    /// <summary>
    /// Tells the game if it is paused
    /// </summary>
    /// <param name="paused"></param>
    public static void setMain_Paused(bool paused)
    {
        Main_paused = paused;
    }
    /// <summary>
    /// Used to check if the game should be paused
    /// </summary>
    public static bool getMain_Paused()
    {
        return Main_paused;
    }



    /// <summary>
    /// Changes the current master volume
    /// </summary>
    /// <param name="volume"></param>
    public static void setMain_MasterVolume(float volume)
    {
        Main_masterVolume = volume;
    }
    /// <summary>
    /// Gets the current master volume
    /// </summary>
    public static float getMain_MasterVolume()
    {
        return Main_masterVolume;
    }

    /// <summary>
    /// Sets the current music volume
    /// </summary>
    /// <param name="volume"></param>
    public static void setMain_MusicVolume(float volume)
    {
        Main_musicVolume = volume;
    }
    /// <summary>
    /// Gets the current music volume
    /// </summary>
    /// <returns>Current music volume divided by master volume</returns>
    public static float getMain_MusicVolume()
    {
        return (Main_musicVolume / 100) * (Main_masterVolume / 100);
    }

    /// <summary>
    /// Sets the current sound effect volume
    /// </summary>
    /// <param name="volume"></param>
    public static void setMain_SoundEffectVolume(float volume)
    {
        Main_soundEffectVolume = volume;
    }
    /// <summary>
    /// Gets the current sound effect volume
    /// </summary>
    /// <returns>Current sound effect volume divided by master volume</returns>
    public static float getMain_SoundEffectVolume()
    {
        return (Main_soundEffectVolume / 100) * (Main_masterVolume / 100 );
    }
}