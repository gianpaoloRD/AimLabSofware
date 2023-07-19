using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FLICKChange_timer_from_another_Scene : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI timerSetting;
    bool l = false;
    bool e = false;
    bool r = false;
    bool o = false;
    public void AdjustTimer(float time)
    {     
        PlayerPrefs.SetFloat("AdjustTimer",time);
        
    }

    public void GetFloatData()
    {
        timerSetting.text = PlayerPrefs.GetFloat("AdjustTimer").ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            l = true;
        }
        if (Input.GetKeyDown("e"))
        {
            e = true;
        }
        if (Input.GetKeyDown("r"))
        {
            r = true;
        }
        if (Input.GetKeyDown("o"))
        {
            o = true;
        }
        if(l == true & e == true & r == true & o == true)
        {
           GetFloatData(); 
        }
        
    }
}
