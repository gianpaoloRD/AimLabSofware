using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class MusicSfx : MonoBehaviour
{
    [SerializeField] AudioMixer controller;
    [SerializeField] Slider music;
    [SerializeField] Slider sfx;

    public float volumeValueM;
    public float volumeValueS;

    const string MIXER_MUSIC = "MusicVol";
    const string MIXER_SFX = "SFXVol";

    private void Awake()
    {
        music.value = PlayerPrefs.GetFloat("Music", 1f);
        sfx.value = PlayerPrefs.GetFloat("Sfx", 1f);

        music.onValueChanged.AddListener(SetMusicVolume);
        sfx.onValueChanged.AddListener(SetSfxVolume);

    }

    void SetMusicVolume(float value)
    {
        volumeValueM = value;
        controller.SetFloat(MIXER_MUSIC, Mathf.Log10(volumeValueM) * 20);
        PlayerPrefs.SetFloat("Music", volumeValueM);
        
    }

    void SetSfxVolume(float value)
    {
        volumeValueS = value;
        controller.SetFloat(MIXER_SFX, Mathf.Log10(volumeValueS) * 20);
        PlayerPrefs.SetFloat("Sfx", volumeValueS);
    }  
}
