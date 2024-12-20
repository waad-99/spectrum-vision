using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sound : MonoBehaviour
{
    public AudioSource backgroundMusic; // Reference to the AudioSource

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object is the player
        {
            if (backgroundMusic != null && !backgroundMusic.isPlaying)
            {
                backgroundMusic.Play(); // Start playing the music
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object is the player
        {
            if (backgroundMusic != null && backgroundMusic.isPlaying)
            {
                backgroundMusic.Stop(); // Stop playing the music if needed
            }
        }
    }
}