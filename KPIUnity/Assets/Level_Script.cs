using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Script : MonoBehaviour
{
    public Animator transition;

    public float transitiontime = 1f;
    public void LoadLevel(string menu)
    {
        
        
        StartCoroutine(LoadNextLevel(menu));
    }

    IEnumerator LoadNextLevel(string menu)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(menu);


    }
}
