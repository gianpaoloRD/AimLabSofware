using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class senstivity_change : MonoBehaviour
{
    [SerializeField] float mouseSensitivity;
    // Start is called before the first frame update
    void Start()
    {
        
        mouseSensitivity = PlayerPrefs.GetInt("Sensitivity");
        //Debug.Log(mouseSensitivity);
    }
    
}
    


