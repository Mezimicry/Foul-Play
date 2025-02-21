using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class VN_SoundLibrary : MonoBehaviour
{
    public AudioClip kianeYay;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    public void playSound(string soundName)
    {
        if (soundName == "KianeYay") {
            audioSource.clip = kianeYay;
        }



        audioSource.Play();
    }



}
