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
        currentCutscene = wantedCutscene;
        cutsceneScreen.SetActive(true);
        gameManager.setMain_Paused(true);
        if (wantedCutscene == "Opening Cutscene") { videoPlayer.clip = openingScene; }
        videoPlayer.Play();
    }

    /// <summary>
    /// At the end of a cutscene this is called to tell the logic script to do something based on the cutscene
    /// </summary>
    /// <param name="vp"></param>
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        GetComponent<Main_LogicScript>().cutsceneEnded(currentCutscene);
        cutsceneScreen.SetActive(false);
        gameManager.setMain_Paused(false);


    }

}
