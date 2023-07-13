using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using System.Diagnostics;
public class FLICKnewScene : MonoBehaviour
{
    
    //[MenuItem("Python/Ensure Naming")]
    static void RunEnsureNaming(){
        Process p = new Process();
        p.StartInfo.UseShellExecute = true;
        p.StartInfo.FileName = Application.dataPath + "/GetData/GetDat.exe";
        p.Start();
        //string scriptPath = Path.Combine(Application.dataPath + "/GetData/","GetData.py");
        //PythonRunner.RunFile(scriptPath);
    }
    public void ButtonMoveScene(string level)
    {
       
        SceneManager.LoadScene(level);
    }
    public void quit(){
        RunEnsureNaming();
        //Debug.Log(Application.Quit().ToString());
        Application.Quit();
    }
}