using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class audio_Manager : MonoBehaviour   
{
    public audio[] sounds;
    
    void Start()
    {
        Play("theme");
        
    }

    
    public void Play(string name)
    {
        
        audio s = Array.Find(sounds, audio => audio.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found");

            return;

        }
            
        s.source.Play();
    }


    void Awake() 
    {
        foreach (audio s in sounds) 
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        
        
        }
    
    
    }
}
