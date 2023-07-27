
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System;

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
        if (level.Equals("KPIMain menu00")) {
            RunEnsureNaming();
            SceneManager.LoadScene("KPILevelSelector"); }
        else SceneManager.LoadScene(level);
    }
    public void quit(){
        RunEnsureNaming();
        //Debug.Log(Application.Quit().ToString());
        Application.Quit();
    }





}