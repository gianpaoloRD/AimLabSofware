using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLICKPlayerController : MonoBehaviour
{

    [SerializeField] Transform cameraHolder;
    float verticalLookRotation;
    //hello
    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X"));
        verticalLookRotation -= Input.GetAxisRaw("Mouse Y");
        verticalLookRotation = Mathf.Clamp(0, -90, 90f);
        cameraHolder.localEulerAngles = new Vector3(0, 0, 0);
    }
}
