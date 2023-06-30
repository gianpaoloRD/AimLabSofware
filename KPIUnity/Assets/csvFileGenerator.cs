using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class csvFileGenerator : MonoBehaviour
{
    [SerializeField] TargetRigth tr;
    [SerializeField] Target tg;
    [SerializeField] MenuControl menuControl;
    [SerializeField] BallController BallC;
    public List<int> tID = new List<int>( ) ;
    public List<bool> Direction = new List<bool>();
    public List<float> Speed = new List<float>();
    public List<bool> Hit = new List<bool>();
    public List<float> Miss = new List<float>();
    float firstmiss = 90;
    string dateNow = System.DateTime.Now.ToString();
    Vector3 VectorCrossHair = new Vector3(0, 90f, -125f);
    int size = 0;
    bool open = true;

    // Start is called before the first frame update
    void Start()
    {
        tID.Add(1);
        Speed.Add(100);
        Hit.Add(false);
        Direction.Add(true);
        BallC.hits = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (BallC.hits && open)
        {
            open = false;
            
        }
        else if (Input.GetMouseButtonDown(0) && open)
        {

            if(BallC.RightOrLeft())
            {
                firstmiss = tg.GetPostion().x;
                Debug.Log(tg.GetPostion().x);  
                if (tg.GetPostion().x <= 1 && tg.GetPostion().x > 0) Miss[size] = tg.GetPostion().x + 4.80f;
                else if (tg.GetPostion().x <= 2 && tg.GetPostion().x >1) Miss[size] = tg.GetPostion().x + 4.80f;
                else if (tg.GetPostion().x <= 3 && tg.GetPostion().x >2) Miss[size] = tg.GetPostion().x + 3.80f;
                else if (tg.GetPostion().x <= 4 && tg.GetPostion().x > 3) Miss[size] = tg.GetPostion().x + 2.80f;
                else if (tg.GetPostion().x >= -2 && tg.GetPostion().x < -1) Miss[size] = tg.GetPostion().x - 1.80f;
                else if (tg.GetPostion().x >= -3 && tg.GetPostion().x < -2) Miss[size] = tg.GetPostion().x - 4.80f;
                else if (tg.GetPostion().x >= -4 && tg.GetPostion().x < -3) Miss[size] = tg.GetPostion().x - 3.80f;
                else if (tg.GetPostion().x >= -5 && tg.GetPostion().x < -4) Miss[size] = tg.GetPostion().x - 2.80f;
                else Miss[size] = tg.GetPostion().x;

            }
            else
            {
                firstmiss = tg.GetPostion().x;
                Debug.Log(tr.GetPostion().x);
                if (tr.GetPostion().x <= 1 && tr.GetPostion().x > 0) Miss[size] = tr.GetPostion().x + 4.80f;
                else if (tr.GetPostion().x <= 2 && tr.GetPostion().x > 1) Miss[size] = tr.GetPostion().x + 4.80f;
                else if (tr.GetPostion().x <= 3 && tr.GetPostion().x > 2) Miss[size] = tr.GetPostion().x + 3.80f;
                else if (tr.GetPostion().x <= 4 && tr.GetPostion().x > 3) Miss[size] = tr.GetPostion().x + 2.80f;
                else if (tr.GetPostion().x >= -2 && tr.GetPostion().x < -1) Miss[size] = tr.GetPostion().x - 1.80f;
                else if (tr.GetPostion().x >= -3 && tr.GetPostion().x < -2) Miss[size] = tr.GetPostion().x - 4.80f;
                else if (tr.GetPostion().x >= -4 && tr.GetPostion().x < -3) Miss[size] = tr.GetPostion().x - 3.80f;
                else if (tr.GetPostion().x >= -5 && tr.GetPostion().x < -4) Miss[size] = tr.GetPostion().x - 2.80f;
                else Miss[size] = tr.GetPostion().x;
            }

            open = false;


        }


    }

    void LateUpdate()
    {
        if (size < BallC.ListOfDirectionOfTheTargets().Count - 1)
        {
            Hit[size] = BallC.ListOfWasShotTargets()[size];
            if(size == 0 && BallC.hits == false)BallC.Miss[size] = firstmiss;
            Miss = BallC.ListOfMissOfTheTargets();
            tID[size]= BallC.ReturnIndexValue()[size];
            Speed[size] = BallC.ReturnSpeedValue();
            Direction = BallC.Direction;
            tg.WasHit(false);
            tr.wasHit(false);
            WriteCsv();
            //Debug.Log(size);
            Hit.Add(false);
            //Miss.Add(90);
            size = BallC.ListOfDirectionOfTheTargets().Count - 1;
            tID.Add(0);
            Speed.Add(BallC.ReturnSpeedValue());
            open = true;
            BallC.hits = false;

        }
        else if (BallC.ListOfDirectionOfTheTargets().Count - 1 >= 59)
        {
            menuControl.activateMenu(true);
        }
        
    }
    public void WriteCsv()

    {

        //Debug.Log(Application.dataPath + "/GetData/"+ PlayerPrefs.GetString("name") + "_SummaryClickResult.csv");
        string saveFilePath = Application.dataPath + "/../ParticipantData/";
        String dateCurrent = DateTime.Now.ToLongDateString().ToString().Replace("/", "_");
        //Debug.Log(saveHere);
        String saveHere = saveFilePath + PlayerPrefs.GetString("name") + "_" + dateCurrent.Replace(" ", "_") + "_SummaryClickResult.csv";

        try
        {
            if (!Directory.Exists(saveFilePath ))
            {
                Directory.CreateDirectory(saveFilePath);
                
            }

        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }


        TextWriter tw = new StreamWriter(saveHere, false);
        tw.WriteLine("Date,Target ID,Direction,Speed,Hit,Miss");

        for (int i = 0; i < tID.Count; ++i)
        {
            if (i < tID.Count) tw.Write(dateNow);
            tw.Write(",");
            if (i < tID.Count) tw.Write(tID[i]);
            tw.Write(",");
            if (i < Direction.Count)
            {
                if(Direction[i]) tw.Write("Left");
                else tw.Write("Right");

            }
            tw.Write(",");
            if (i < Speed.Count) tw.Write(Speed[i]);
            tw.Write(",");
            if (i < Hit.Count) tw.Write(Hit[i]);
            tw.Write(",");
            if (i < Miss.Count) tw.Write(Miss[i]);
            tw.Write(System.Environment.NewLine);
        }

        tw.Flush();
        tw.Close();

    }

}
