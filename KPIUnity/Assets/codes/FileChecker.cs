using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {

            string currentTime = DateTime.Now.TimeOfDay.ToString().Replace(":", "_");
            string dateCurrent = DateTime.Now.ToLongDateString().ToString().Replace("/", "_");
            string currentFilePath = Application.dataPath + "/../" + "/ProcessedDataGame.csv";
            string newFilePath = Application.dataPath + "/../" + "ParticipantData/"+PlayerPrefs.GetString("name") +"_" + dateCurrent+ "_"+ currentTime +"FLICK_.csv";

            Directory.CreateDirectory(Application.dataPath + "/../" + "ParticipantData");

            File.Move(currentFilePath, newFilePath);
        }
        catch (FileNotFoundException ex)
        {
            UnityEngine.Debug.Log("The file does not exist.");
        }
        catch (IOException ex)
        {
            UnityEngine.Debug.Log("The file could not be renamed.");
        }
    }
}
