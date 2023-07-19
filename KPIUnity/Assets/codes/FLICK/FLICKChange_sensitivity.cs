using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLICKChange_sensitivity : MonoBehaviour
{
    [SerializeField] float mouseSensitivity;

    public void AdjustSensitivity(float newSensitivity)
    {
        mouseSensitivity = newSensitivity;
    }
}