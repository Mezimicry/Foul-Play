using UnityEngine.SocialPlatforms.Impl;

// The gameManager is used to pass variables between scenes.
// You can call it by doing this
// gameManager.function();
// You can add stuff but please do not change stuff you didn't add as things might go wrong


public static class gameManager
{
    public static bool Main_paused = false;
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


    // To know if the game is meant to be paused
    public static void setMain_Paused(bool paused)
    {
        Main_paused = paused;
    }
    public static bool getMain_Paused()
    {
        return Main_paused;
    }



}