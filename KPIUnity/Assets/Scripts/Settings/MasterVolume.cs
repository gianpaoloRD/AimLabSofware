using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour
{
    [SerializeField] AudioMixer audioController;

    const string MIXER_MASTER = "MasterVol";

    public Slider sliderV;
    public float volumeValue;
    public Image imageMute;

    void Awake()
    {
        sliderV.onValueChanged.AddListener(SetMasterVolume);
    }

    void SetMasterVolume(float value)
    {
        audioController.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
        volumeValue = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        sliderV.value = PlayerPrefs.GetFloat("VolumeAudio", 0.5f);
        AudioListener.volume = volumeValue;
        MuteCheck();


    }

    public void ChangeSlider(float valueV)
    {
        volumeValue = valueV;
        PlayerPrefs.SetFloat("VolumeAudio", volumeValue);
        AudioListener.volume = volumeValue;
        MuteCheck();

    }

    public void MuteCheck()
    { 
        if (volumeValue == 0) 
        {
            imageMute.enabled = true;

        }

        else 
        {
            imageMute.enabled = false;
        
        }
    
    }
}
