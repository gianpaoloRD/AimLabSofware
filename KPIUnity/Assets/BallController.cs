using System;
using Random = System.Random;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System.Text;
using Debug = UnityEngine.Debug;
using System.Timers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Rendering;
using System.Reflection;
using System.Drawing;

public class BallController : MonoBehaviour
{
    [SerializeField] TargetRigth tr;
    [SerializeField] Target tg;
    [SerializeField] MenuControl menuControl;
    [SerializeField] Time_controller TimerControll;
    Vector3 targetEndPoint;
    Vector3 targetStartPoint;
    Vector3 targetEndPointRight;
    Vector3 targetStartPointRight;
    float speed = 100;
    float timeStore = 5;
    bool countOneTime = true;
    public bool rightOrLeft;
    private bool open = true ;
    int randomNumber = 0;
    public bool hits = false ;
    Random random = new Random();
    public float hitposition = 0;
    public List<bool> Direction = new List<bool>();
    public List<bool> BallHit = new List<bool>();
    public List<float> Miss = new List<float>();
    public List<int> ID = new List<int>();
    List<float> listSpeed = new List<float> {
              100, 100, 200, 200, 300, 100, 100, 200, 200, 300
            , 100, 100, 200, 200, 300, 100, 100, 200, 200, 300
            , 100, 100, 200, 300, 300, 100, 100, 200, 200, 300
            , 100, 100, 200, 300, 300, 100, 100, 200, 200, 300
            , 100, 200, 200, 300, 300, 100, 100, 200, 200, 300
            , 100, 200, 200, 300, 300, 100, 100, 200, 200, 300
    };


    List<string> list = new List<string> {
              "true", "false", "true", "false", "true", "false", "true", "false", "true", "false"
            , "true", "false", "true", "false", "true", "false", "true", "false", "true", "false"
            , "true", "false", "true", "false", "true", "false", "true", "false", "true", "false"
            , "true", "false", "true", "false", "true", "false", "true", "false", "true", "false"
            , "true", "false", "true", "false", "true", "false", "true", "false", "true", "false"
            , "true", "false", "true", "false", "true", "false", "true", "false", "true", "false"
    };

    List<int> TID = new List<int> {
              1,  2,  3,  4,  5,  6,  7,  8,  9,  10
            , 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
            , 21, 22, 23, 24, 25, 26, 27, 28, 29, 30
            , 31, 32, 33, 34, 35, 36, 37, 38, 39, 40
            , 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
            , 51, 52, 53, 54, 55, 56, 57, 58, 59, 60
    };


    // Start is called before the first frame update
    void Start()
    {
        targetEndPoint = new Vector3(90f, 90f, -125f);
        targetStartPoint = new Vector3(-90f, 90f, -125f);
        rightOrLeft = Convert.ToBoolean(list[randomNumber]);
        targetStartPointRight = new Vector3(90f, 90f, -125f);
        targetEndPointRight = new Vector3(-90f, 90f, -125f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(TID.Count);
        if (timeStore > 0)
        {
            if (countOneTime == true) TimerControll.UpDateTimer(timeStore);
            timeStore -= Time.deltaTime;
            

        }
        else if (TID.Count <= 0)// 1
        {
            menuControl.activateMenu(true);
        }
        else 
        {
            countOneTime = false;
            TimerControll.TurnOff();
            //Debug.Log(list.Count-1);
            
            if (rightOrLeft)
            {
                
                if (tg.returnWasHit())
                {
                        open = true;
                        BallHit[BallHit.Count - 1] = true;
                        Miss[Miss.Count - 1] = tg.GetPostion().x;
                        hits = true;
                        Debug.Log(tg.GetPostion().x);
                        timeStore = random.Next(2, 5);
                        rightOrLeft = Convert.ToBoolean(list[randomNumber]);
                        tg.transform.position = targetStartPoint;
                        tg.WasHit(false);

                }
                else if (Vector3.Distance(tg.transform.position, targetEndPoint) < 0.001f)
                {
                        open = true;


                        tg.transform.position = targetStartPoint;
                        timeStore = random.Next(2, 5);


                        
                        
                        
                        rightOrLeft = Convert.ToBoolean(list[randomNumber]);


                }
                else
                {
                    if (open)
                    {
                        open = false;
                        Direction.Add(true);
                        BallHit.Add(false);
                        ID.Add(TID[randomNumber]);
                        Miss.Add(90);
                        speed = listSpeed[randomNumber];
                        //Debug.Log("Left: " + Direction[Direction.Count - 1]);
                        listSpeed.RemoveAt(randomNumber);
                        TID.RemoveAt(randomNumber);
                        list.RemoveAt(randomNumber);
                        randomNumber = random.Next(TID.Count);


                    }
                    tg.transform.position = Vector3.MoveTowards(tg.transform.position, targetEndPoint, speed * Time.deltaTime);
                }
            }
            else
            {

                if (tr.returnWasHit())
                {

                    open = true;
                    BallHit[BallHit.Count-1] = true;
                    Miss[Miss.Count - 1] = tr.GetPostionHit().x;
                    hits = true;
                    Debug.Log(tr.GetPostion().x);
                    timeStore = random.Next(2, 5);
                    rightOrLeft = Convert.ToBoolean(list[randomNumber]);
                    tr.transform.position = targetStartPointRight;
                    tr.wasHit(false);

                }
                else if (Vector3.Distance(tr.transform.position, targetEndPointRight) < 0.001f)
                {
                    open = true;

                    tr.transform.position = targetStartPointRight;
                    timeStore = random.Next(2, 5);


                    
                    
                    
                    rightOrLeft = Convert.ToBoolean(list[randomNumber]);

                }
                else
                {
                    if (open)
                    {
                        open = false;
                        Direction.Add(false);
                        BallHit.Add(false);
                        ID.Add(TID[randomNumber]);
                        Miss.Add(90);
                        speed = listSpeed[randomNumber]; 
                        //Debug.Log("Right: " + Direction[Direction.Count-1]);
                        listSpeed.RemoveAt(randomNumber);
                        TID.RemoveAt(randomNumber);
                        list.RemoveAt(randomNumber);
                        randomNumber = random.Next(TID.Count);
                        
                    }
                    tr.transform.position = Vector3.MoveTowards(tr.transform.position, targetEndPointRight, speed * Time.deltaTime);

                }
            }

        }

    }


    public bool RetunrTF()
    {
        return Convert.ToBoolean(list[randomNumber]); ;
    }
    public List<int> ReturnIndexValue()
    {
        return this.ID;
    }
    public float ReturnSpeedValue()
    {
        return this.speed;
    }
    public List<bool> ListOfDirectionOfTheTargets()
    {
        return Direction;
    }
    public List<float> ListOfMissOfTheTargets()
    {
        return Miss;
    }
    public List<bool> ListOfWasShotTargets()
    {
        return BallHit;
    }

    public bool RightOrLeft()
    {
        return this.rightOrLeft;
    }
}
