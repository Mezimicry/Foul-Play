using UnityEngine.SocialPlatforms.Impl;

// The gameManager is used to pass variables between scenes.
// You can call it by doing this
// gameManager.function();
// You can add stuff but please do not change stuff you didn't add as things might go wrong


public static class gameManager
{
    public static bool Main_paused = false;
    public static float Main_masterVolume = 50;
    public static float Main_musicVolume = 50;
    public static float Main_soundEffectVolume = 50;
    public static string Main_wantedMusic = "Title Screen";
    public static string VN_scriptName = "NoScript";
    public static string VN_exitCode = "NoExitCode";
    


    // For storing which script the VN should load
    public static void setVN_Script(string wantedScript)
    {
        VN_scriptName = wantedScript;
    }
    public static string getVN_Script()
    {
        return VN_scriptName;
    }

    

    // So other scenes can know the VN exit code
    public static void setVN_exitCode(string exitCode)
    {
        VN_exitCode = exitCode;
    }
    public static string getVN_exitCode()
    {
        return VN_exitCode;
    }



    // Used for changing the music
    public static void setMain_wantedMusic(string wantedMusic)
    {
        Main_wantedMusic = wantedMusic;
    }
    public static string getMain_wantedMusic()
    {
        return Main_wantedMusic;
    }


    // To know if the game is meant to be paused
    public static void setMain_Paused(bool paused)
    {
        Main_paused = paused;
    }
    public static bool getMain_Paused()
    {
        return Main_paused;
    }



    // Used to store the volume
    public static void setMain_MasterVolume(float volume)
    {
        Main_masterVolume = volume;
    }
    public static float getMain_MasterVolume()
    {
        return Main_masterVolume;
    }

    public static void setMain_MusicVolume(float volume)
    {
        Main_musicVolume = volume;
    }
    public static float getMain_MusicVolume()
    {
        return (Main_musicVolume / 100) * (Main_masterVolume / 100);
    }

    public static void setMain_SoundEffectVolume(float volume)
    {
        Main_soundEffectVolume = volume;
    }
    public static float getMain_SoundEffectVolume()
    {
        return (Main_soundEffectVolume / 100) * (Main_masterVolume / 100 );
    }

}