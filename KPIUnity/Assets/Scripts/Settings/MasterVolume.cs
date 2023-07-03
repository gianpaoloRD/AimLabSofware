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
    public float volumeValue = 1f;
    public Image imageMute;


    void Awake()
    {
        sliderV.value = PlayerPrefs.GetFloat("Master", 1f);
        sliderV.onValueChanged.AddListener(SetMasterVolume);
        
    }

    void SetMasterVolume(float value)
    {     
        volumeValue = value;
        audioController.SetFloat(MIXER_MASTER, Mathf.Log10(volumeValue) * 20);
        PlayerPrefs.SetFloat(MIXER_MASTER, volumeValue);
        PlayerPrefs.SetFloat("Master", volumeValue);
        //MuteCheck();

    }

    /*public void MuteCheck()
    {
        
        if (sliderV.value == 0.001) 
        {
            imageMute.enabled = true;

        }

        else 
        {
            imageMute.enabled = false;
        
        }
    
    }*/
}
