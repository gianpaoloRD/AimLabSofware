using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour
{
    public Slider sliderV;
    public float volumeValue;
    public Image imageMute;

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
