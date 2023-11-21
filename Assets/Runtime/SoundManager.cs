using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] soundEffects;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomSound();
    }
    void Update()
    {

    }

    void PlayRandomSound()
    {
        if (soundEffects.Length > 0)
        {
            int randomIndex = Random.Range(0, soundEffects.Length);
            audioSource.PlayOneShot(soundEffects[randomIndex]);
        }
        else
        {
            Debug.LogError("No sound effects available!");
        }
    }


}