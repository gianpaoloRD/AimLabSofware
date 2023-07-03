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
        music.onValueChanged.AddListener(SetMusicVolume);
        sfx.onValueChanged.AddListener(SetSfxVolume);
    }

    void SetMusicVolume(float value)
    {
        controller.SetFloat(MIXER_MUSIC, value);
    }

    void SetSfxVolume(float value)
    {
        controller.SetFloat(MIXER_SFX, value);
    }

    // Start is called before the first frame update
    void Start()
    {
       // MusicSlider();
       // SfxSlider();
    }

    void MusicSlider()
    {
        music.value = PlayerPrefs.GetFloat("VolumeAudio", 0.5f);
        AudioListener.volume = volumeValueM;
        
    }

    void SfxSlider()
        {
            sfx.value = PlayerPrefs.GetFloat("VolumeAudio", 0.5f);
            AudioListener.volume = volumeValueS;

        }

    public void ChangeMusicSlider(float valueM)
    {
        volumeValueM = valueM;
        PlayerPrefs.SetFloat("VolumeAudio", volumeValueM);
        AudioListener.volume = volumeValueM;
        

    }

    public void ChangeSfSlider(float valueS)
    {
        volumeValueS = valueS;
        PlayerPrefs.SetFloat("VolumeAudio", volumeValueS);
        AudioListener.volume = volumeValueS;


    }
}
