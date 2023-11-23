using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip[] musicTracks;
    private AudioSource audioSource;

    private int currentTrackIndex = -1;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomTrack();
    }

    private void Update()
    {
        // Check if the current track has finished playing
        if (!audioSource.isPlaying)
        {
            // Play a new random track
            PlayRandomTrack();
        }
    }

    private void PlayRandomTrack()
    {
        int randomIndex;

        // Make sure the next track is not the same as the current one
        do
        {
            randomIndex = Random.Range(0, musicTracks.Length);
        } while (randomIndex == currentTrackIndex);

        // Update the current track index
        currentTrackIndex = randomIndex;

        // Play the selected track
        audioSource.clip = musicTracks[currentTrackIndex];
        audioSource.Play();
    }
}