using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserName : MonoBehaviour
{
    public GameObject inputField;
    
    

    private void Update()
    {
    }

    public void SetString()
    {
        string text = inputField.GetComponent<TMP_InputField>().text;
        PlayerPrefs.SetString("name", text);
        SceneManager.LoadScene("ClickTest");
    }



}
