using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Script : MonoBehaviour
{
    public Animator transition;

    public float transitiontime = 1f;
    public void LoadLevelMenu(string menu)
    {

        StartCoroutine(LoadNextLevel(menu));
    }
    public void LoadLevelSettings(string menu)
    {


        StartCoroutine(LoadNextSettings(menu));
    }
    public void LoadLevelSelecLevel(string menu)
    {


        StartCoroutine(LoadNextSelecLevel(menu));
    }
    IEnumerator LoadNextLevel(string menu)
    {
        string scene = "Settings";
        if(scene.Equals(menu))
        {
            scene = "Settings";
            Debug.Log(scene);
            transition.SetTrigger("Settings");

        }else {
            scene = "LevelSelector";
            Debug.Log(scene);
            transition.SetTrigger("LevelSelect");
        }
        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(scene);


    }
    IEnumerator LoadNextSettings(string menu)
    {
        
        transition.SetTrigger("GoBackfromSettings");

        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(menu);


    }
    IEnumerator LoadNextSelecLevel(string menu)
    {
        transition.SetTrigger("GoBackfromLevel");

        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(menu);


    }
}
