using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Script : MonoBehaviour
{

    public Animator transition;
    public Animator Logintransition = null;
    public float transitiontime = 1f;
    void Start()
    {
        Logintransition.SetBool("Login", true);
    }
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
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadLogin(bool boolean)
    {
        Debug.Log(boolean);
        StartCoroutine(LoadLoginco(boolean));
    }
    IEnumerator LoadNextLevel(string menu)
    {
        string scene = "KPISettings";
        Logintransition.SetBool("Login", false);
        if (scene.Equals(menu))
        {
            scene = "KPISettings";
            Debug.Log(scene);
            transition.SetTrigger("Settings");

        }else {
            scene = "KPILevelSelector";
            Debug.Log(scene);
            transition.SetTrigger("LevelSelect");
        }
        
        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(scene);


    }
    IEnumerator LoadNextSettings(string menu)
    {

        Logintransition.SetBool("Login", false);
        transition.SetTrigger("GoBackfromSettings");

        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(menu);


    }
    IEnumerator LoadNextSelecLevel(string menu)
    {
        transition.SetTrigger("GoBackfromLevel");
        Logintransition.SetBool("Login", false);
        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(menu);


    }
    IEnumerator LoadLoginco(bool menu)
    {
        Logintransition.SetBool("Login", false);
        yield return new WaitForSeconds(transitiontime);


    }
}
