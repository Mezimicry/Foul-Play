using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Main_MusicLibrary : MonoBehaviour
{
    // This is the audio source attached to the object
    AudioSource audioSource;

    // Each of these hold a different sound effect that should be played.
    public AudioClip titleScreenMusic;
    public AudioClip VNTest;

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
        if (gameManager.Main_paused)
        {
            audioSource.volume = (gameManager.getMain_MusicVolume());
        }

        wantedMusic = gameManager.getMain_wantedMusic();
        if (currentlyPlayingMusic != wantedMusic)
        {


            // Finds the sound
            if (wantedMusic == "Title Screen") { audioSource.clip = titleScreenMusic; }
            else if (wantedMusic == "VNTest") { audioSource.clip = VNTest; }

            // Then plays the sound
            audioSource.Play();

            currentlyPlayingMusic = wantedMusic;
        }




    }


}
