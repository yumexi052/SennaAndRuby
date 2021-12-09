using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class btnSound : MonoBehaviour
{
    public AudioClip myClip;
    public void playSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = myClip;
        audio.Play();
    }
}
