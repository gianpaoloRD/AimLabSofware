using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLICKPlayerController : MonoBehaviour
{
    [SerializeField] Transform CameraHolder;
    [SerializeField] float mouseSensitivity;
    float verticalLookRotation;
    private bool canPlay = true;
    
    void Start()
    {
    }

    void Update()

    {
        if (canPlay == true)
        {
            transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * PlayerPrefs.GetFloat("Sensitivity"));

            verticalLookRotation -= Input.GetAxisRaw("Mouse Y") * PlayerPrefs.GetFloat("Sensitivity");
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90, 90f);
            CameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
        }
    }

    public void CanPlay(bool play)
    {
        this.canPlay = play;
    }
    public bool returnCnaPlay()
    {
        return canPlay;
    }

    public void AdjustSensitivity(float newSensitivity)
    {
        mouseSensitivity = newSensitivity;
    }
}