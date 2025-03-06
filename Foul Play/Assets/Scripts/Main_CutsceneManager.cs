using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Main_CutsceneManager : MonoBehaviour
{
    public VideoClip openingScene;

    VideoPlayer videoPlayer;
    public GameObject cutsceneScreen;

    string currentCutscene;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the camera's video player
        GameObject camera = GameObject.Find("Main Camera");
        videoPlayer = camera.GetComponent<VideoPlayer>();

        // Makes it so at the end of the loop EndReached will be called
        videoPlayer.loopPointReached += EndReached;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Used to tell the cutscene manager to play a cutscene
    /// </summary>
    /// <param name="wantedCutscene"></param>
    public void playCutscene(string wantedCutscene)
    {
        // Stores what cutscene is playing
        currentCutscene = wantedCutscene;

        // Turns on the object that is used to show the cutscene
        cutsceneScreen.SetActive(true);

        // Tells the other scenes that the game is paused
        gameManager.setMain_Paused(true);

        // Tells the music to stop
        GetComponent<Main_MusicLibrary>().playMusic(false);

        // Chooses the cutscene and then plays it
        if (wantedCutscene == "Opening Cutscene") { videoPlayer.clip = openingScene; }
        videoPlayer.Play();
    }

    /// <summary>
    /// At the end of a cutscene this is called to tell the logic script to do something based on the cutscene
    /// </summary>
    /// <param name="vp"></param>
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Tells music to continue
        GetComponent<Main_MusicLibrary>().playMusic(true);

        // Tells the main script to do things based on which cutscene ends
        GetComponent<Main_LogicScript>().cutsceneEnded(currentCutscene);

        // Hides the object that shows the cutscene
        cutsceneScreen.SetActive(false);

        // Unpauses the game
        gameManager.setMain_Paused(false);


    }

}
