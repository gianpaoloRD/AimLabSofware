using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using System.Diagnostics;
public class newScene : MonoBehaviour
{
    
    //[MenuItem("Python/Ensure Naming")]

    public void ButtonMoveScene(string level)
    {
       
        SceneManager.LoadScene(level);
    }
    public void quit(){
        
        //Debug.Log(Application.Quit().ToString());
        Application.Quit();
    }
}