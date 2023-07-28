using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FLICKGameController : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    public static int targetHit;
    [SerializeField]
    GameObject Panel;
    [SerializeField]
    GameObject PanelTimeStart;
    [SerializeField]
    public bool canPlay = false;
    // Update is called once per frame
    public bool shot = false;
    public FLICKPlayerController py;
    public float TimeLeft = -5;
    public bool TimerOn = false;
    public float TimeLeftStart;
    public bool TimeOnStart = false;
    [SerializeField]
    public TextMeshProUGUI Timer;
    [SerializeField]
    public TextMeshProUGUI TimerStart;
    void Start()
    {

        TimeLeft += PlayerPrefs.GetFloat("AdjustTimer");
        TimeOnStart = true;
        targetHit = 0;
        Panel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;

    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print();
            //print("space key was pressed");
        }
        Debug.Log(PlayerPrefs.GetInt("AdjustTimer"));
        if (Input.GetMouseButtonDown(0) && canPlay)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                FLICKTarget target = hit.collider.gameObject.GetComponent<FLICKTarget>();
                if (target != null)
                {
                    target.Hit();
                    wasShot(true);

                }
                else
                {
                    wasShot(false);
                }
            }
        }
        Debug.Log(TimeOnStart);
        if (TimeOnStart == true)
        {
            if (TimeLeftStart > 0)
            {
                py.CanPlay(false);
                canPlay = false;
                TimeLeftStart -= Time.deltaTime;
                updateTimerStart(TimeLeftStart);
            }
            else
            {
                //print();
                canPlay = true;
                PanelTimeStart.SetActive(false);
                py.CanPlay(true);
                Cursor.lockState = CursorLockMode.Locked;
                TimeLeftStart = 0;
                TimeOnStart = false;
                //TimeLeft = ;
                TimerOn = true;
            }
        }
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                print();
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    public void print()
    {
        py.CanPlay(false);
        canPlay = false;
        Panel.SetActive(true);
        //Result  = Panel.GetComponent<UnityEngine.UI.Text>();
        //Result.text = "Result = " + targetHit;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGetReadyCoroutine()
    {
        SceneManager.LoadScene("menu");
    }
    public void wasShot(bool play)
    {
        this.shot = play;
    }
    public bool returnWasShot()
    {
        return shot;
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void updateTimerStart(float currentTime)
    {
        currentTime += 1;
        Debug.Log(currentTime);
        //float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerStart.text = string.Format("{0}", seconds);

    }
}