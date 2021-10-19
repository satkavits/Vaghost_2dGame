using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class menu_script : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void PlayGame() 
    {
        SceneManager.LoadScene("intro2");
     
    }
    public void QuitGame() 
    {
        Application.Quit();
       
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }




}
