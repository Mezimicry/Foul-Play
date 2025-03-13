using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Main_MusicLibrary : MonoBehaviour
{
    // This is the audio source attached to the object
    AudioSource audioSource;

    // Each of these hold a different music track that should be played.
    public AudioClip titleScreenMusic;
    public AudioClip song6InsideTheCastle;

    string currentlyPlayingMusic;
    string wantedMusic;

    void Start()
    {
        // Sets the audio source
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = gameManager.getMain_MusicVolume();
    }


    void Update()
    {
        // When the game is paused it will update the volume incase it changes
        if (gameManager.Main_paused)
        {
            audioSource.volume = (gameManager.getMain_MusicVolume());
        }

        // Stores the currently wanted music and checks if it is different to what if playing
        wantedMusic = gameManager.getMain_wantedMusic();
        if (currentlyPlayingMusic != wantedMusic)
        {
            // If it is different it then

            // Finds the wanted music
            if (wantedMusic == "Title Screen") { audioSource.clip = titleScreenMusic; }
            else if (wantedMusic == "Inside The Castle") { audioSource.clip = song6InsideTheCastle; }

            // Then plays changes what one is playing
            audioSource.Play();

            // Updates what music is playing
            currentlyPlayingMusic = wantedMusic;
        }


    }

    /// <summary>
    /// If true music will contine. If false music will pause.
    /// </summary>
    /// <param name="play"></param>
    public void playMusic(bool play)
    {
        if (play)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }


}
