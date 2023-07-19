using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FLICKchange_sensitivity_from_another_scene : MonoBehaviour
{
    
    [SerializeField]
    public TextMeshProUGUI sensitivity;

    public void AdjustSensitivity(float Sensitivity)
    {     
        PlayerPrefs.SetFloat("Sensitivity",Sensitivity);
        
    }

    public void GetFloatData()
    {
        sensitivity.text = PlayerPrefs.GetFloat("Sensitivity").ToString();
    }

    void Update()
    {
        GetFloatData();
    }

}
