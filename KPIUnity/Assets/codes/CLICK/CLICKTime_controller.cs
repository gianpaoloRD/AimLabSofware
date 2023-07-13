using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CLICKTime_controller : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI TimeController ;
    // Start is called before the first frame update
    public void UpDateTimer(float currentTime)
    {
        
        TimeController.text = string.Format("{0}",(int)currentTime);
    }
    public void TurnOff()
    {
        TimeController.SetText("");
    }
}
