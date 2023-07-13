using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Panel.SetActive(true);
            //Debug.Log("spacec presed");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
    }

    public void activateMenu(bool menu)
    {
        Panel.SetActive(menu);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
