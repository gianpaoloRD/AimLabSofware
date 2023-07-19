using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameViewPanelAnimationControl : MonoBehaviour
{
    public Animator transitionClick;
    public Animator transitionFlick;
    public float transitiontime = 1f;
    public void LoadGameViewAnimation(string animation)
    {

        StartCoroutine(LoadNextLevel(animation));
    }

    IEnumerator LoadNextLevel(string animation)
    {

        switch (animation)
        {
            case "GView":
                //transitionFlick.SetTrigger("GViewGoBack");
                transitionClick.SetTrigger(animation);



                break;

            case "GViewGoBack":
                //transitionFlick.SetTrigger("GViewGoBack");
                transitionClick.SetTrigger(animation);


                break;

            case "GViewFlick":
                // transitionClick.SetTrigger("GViewGoBack");

                transitionFlick.SetBool(animation, true);
                //transitionFlick.SetBool("GviewFlickGoBack", false);

                Debug.Log("GView");
                break;

            case "GviewFlickGoBack":
                transitionFlick.SetBool("GViewFlick", false);
                //transitionFlick.SetTrigger("GViewGoBack");
                transitionFlick.SetBool(animation, true);



                break;
        };

        yield return new WaitForSeconds(transitiontime);
        transitionFlick.SetBool(animation, false);
        transitionClick.ResetTrigger(animation);
        
    }

}
