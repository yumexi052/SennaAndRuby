using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]
public class StartGame : MonoBehaviour
{
    public AudioClip myClip;
    
   
   public void playGame()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = myClip;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        audio.Play();
    }

    public void QuitGame()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = myClip;
        Debug.Log("Quit");
        audio.Play();
        Application.Quit();
    }

  
    public void playSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = myClip;
        audio.Play();
    }
}
