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
using Unity.VisualScripting;

public class CLICKBallControllerPractice : MonoBehaviour
{
    [SerializeField] CLICKTargetRigth tr;
    [SerializeField] CLICKTarget tg;
    [SerializeField] MenuControl menuControl;
    [SerializeField] CLICKTime_controller TimerControll;
    Vector3 targetEndPoint;
    Vector3 targetStartPoint;
    Vector3 targetEndPointRight;
    Vector3 targetStartPointRight;
    float speed = 100;
    float timeStore = 5;
    bool countOneTime = true;
    public bool rightOrLeft=false;
    public bool timerOn=true;
    Random random = new Random();
    public List<bool> Direction = new List<bool>();


    List<string> list = new List<string> {
              "true",  "true", "false", "false", "false", "true"
        };


    // Start is called before the first frame update
    void Start()
    {
        targetEndPoint = new Vector3(90f, 90f, -125f);
        targetStartPoint = new Vector3(-90f, 90f, -125f);
        speed = 200;
        targetStartPointRight = new Vector3(90f, 90f, -125f);
        targetEndPointRight = new Vector3(-90f, 90f, -125f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timeStore);
        if (timeStore > 0)
        {
            if (countOneTime == true) TimerControll.UpDateTimer(timeStore);
            timeStore -= Time.deltaTime;


        }
        else if (list.Count - 1 < 0)// 1
        {

            menuControl.activateMenu(true);
        }
        else
        {
            countOneTime = false;
            TimerControll.TurnOff();
            Debug.Log(list.Count-1);
            if (rightOrLeft)
            {
                
                if (tg.returnWasHit())
                    {
                        
                        timeStore = random.Next(2, 5);
                        rightOrLeft = Semaphore(list.Count - 1);
                        list.RemoveAt(list.Count - 1);
                        tg.WasHit(false);
                        tg.transform.position = targetStartPoint;

                }
                else if (Vector3.Distance(tg.transform.position, targetEndPoint) < 0.001f)
                {
                        
                        
                        timeStore = random.Next(2, 5);
                        tg.transform.position = targetStartPoint;
                        rightOrLeft =Semaphore(list.Count - 1);
                        list.RemoveAt(list.Count - 1);


                }
                else
                {
                        tg.transform.position = Vector3.MoveTowards(tg.transform.position, targetEndPoint, speed * Time.deltaTime);
                }
            }
            else
            {
               
                if (tr.returnWasHit() )
                {
                    tr.wasHit(false);
                    timeStore = random.Next(2, 5);
                    rightOrLeft = Semaphore(list.Count - 1);
                    list.RemoveAt(list.Count - 1);
                    tr.transform.position = targetStartPointRight;

                }
                else if (Vector3.Distance(tr.transform.position, targetEndPointRight) < 0.001f)
                {

                    
                    
                    timeStore = random.Next(2, 5);
                    tr.transform.position = targetStartPointRight;
                    rightOrLeft = Semaphore(list.Count - 1);
                    list.RemoveAt(list.Count - 1);



                }
                else
                {
                    tr.transform.position = Vector3.MoveTowards(tr.transform.position, targetEndPointRight, speed * Time.deltaTime);

                }
            }

        }


    }

    public bool Semaphore(int index)
    {

            string[] listString = list.ToArray();
            bool result = Convert.ToBoolean(listString[index]);
            
            
            return result;
       
    }

}
