using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLICKTarget : MonoBehaviour
{
    public void Hit()
    {
        //position
        transform.position = FLICKTargetBounds.Instance.GetRandomPosition();
    }
}