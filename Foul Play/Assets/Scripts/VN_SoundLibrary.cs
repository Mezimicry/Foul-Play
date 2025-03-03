using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class VN_SoundLibrary : MonoBehaviour
{
    // This is the audio source attached to the object
    AudioSource audioSource;

    // Each of these hold a different sound effect that should be played.
    public AudioClip kianeYay;

    void Start()
    {
        // Sets the audio source
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = (gameManager.getMain_SoundEffectVolume());
    }


    void Update()
    {
        // While the game is paused it will update the volume
        if (gameManager.Main_paused)
        {
            audioSource.volume = (gameManager.getMain_SoundEffectVolume());
        }
    }



    // Plays the desired sound
    public void playSound(string soundName)
    {
        // Finds the sound
        if (soundName == "KianeYay") { audioSource.clip = kianeYay; }
        else if (soundName == "OtherSound") { audioSource.clip = kianeYay; }

        // Then plays the sound
        audioSource.Play();
    }

}
