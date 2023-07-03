using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicAudio, sfxAudio;
    public AudioSource musicSource, sfxSource;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Lobby");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicAudio, x => x.clipName == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");


        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }

    }

    public void PlaySfx(string name) 
    {
        Sound s = Array.Find(sfxAudio, x => x.clipName == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");


        }

        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();

        }

    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
