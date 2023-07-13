using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameViewPanelAnimationControl : MonoBehaviour
{
    public Animator transition;
    public float transitiontime = 1f;
    public void LoadGameViewAnimation(string animation)
    {

        StartCoroutine(LoadNextLevel(animation));
    }

    IEnumerator LoadNextLevel(string animation)
    {
        
        transition.SetTrigger(animation);
        yield return new WaitForSeconds(transitiontime);
    }

}
