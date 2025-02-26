using UnityEngine.SocialPlatforms.Impl;

public static class gameManager
{
    public static string VN_scriptName;
    public static string VN_exitCode;

    public static void setVN_Script(string wantedScript)
    {
        VN_scriptName = wantedScript;
    }

    public static string getVN_Script()
    {
        return VN_scriptName;
    }

    public static void setVN_exitCode(string exitCode)
    {
        VN_exitCode = exitCode;
    }

    public static string getVN_exitCode()
    {
        return VN_exitCode;
    }

}