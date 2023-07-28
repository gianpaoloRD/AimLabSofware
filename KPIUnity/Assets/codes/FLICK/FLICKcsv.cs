using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class FLICKcsv : MonoBehaviour
{
    //string filename = "";
    int shots;
    public new Camera camera;
    int id;
    public FLICKPlayerController py;
    int TimeFrame = 0;
    //Plane plane = new Plane(Vector3.up, 400);
    string dateNow = System.DateTime.Now.ToString();
    public List<string> ID = new List<string>();
    public List<string> Timef = new List<string>();
    public List<string> Click = new List<string>();
    public List<string> Number_of_shots = new List<string>();
    public List<string> Coordenates = new List<string>();
    public List<string> Target = new List<string>();
    public List<string> Camera_rotation = new List<string>();
    // Start is called before the first frame update
    // Update is called once per frame
    public FLICKGameController gc;
    void Start()
    {
        //filename = "test.csv";
         /*
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Debug.Log(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
            
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
        float distance;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            Debug.Log(worldPosition);
        }
        */
        //Debug.Log( TimeFrame);
        Timef.Add(TimeFrame.ToString());
        TimeFrame += 1 ;
        
        float camy = GameObject.FindWithTag("Player").transform.position.y;
        float camx = GameObject.FindWithTag("CameraHolder").transform.position.x;
        float camz = GameObject.FindWithTag("MainCamera").transform.position.z;
        float camya = GameObject.FindWithTag("Player").transform.eulerAngles.y;
        float camxa = GameObject.FindWithTag("CameraHolder").transform.eulerAngles.x;
        float camza = GameObject.FindWithTag("MainCamera").transform.rotation.z;
        Vector3 cam_location = GameObject.FindWithTag("CameraHolder").transform.position;
        //Camera camara = GameObject.FindWithTag("MainCamera");
        Vector3 target_locaton = GameObject.FindWithTag("Target").transform.position;
        Vector3 cam = new Vector3(camx , camy, camz);
        Vector3 camA = new Vector3(camxa, camya, 0);
        Vector3 v1 = target_locaton - cam;
        if(camxa > 180) camxa -= 360;
        if(camya > 180) camya -= 360;
        Vector2 CoordenatesInAngle = new Vector2((camxa*-1)+9,(camya + 33)); // shootv
        //Debug.Log(shootv.ToString());
        //Debug.Log("aqui");
        //Vector3 shootv3 = new Vector3(camxa+20,camya+33,0);
        //cam_location.x = 10;
        //Vector2 perfec_vector = (new Vector2(v1.x,v1.y)).normalized; 
        //perfec.z =0 ; Vector2.SignedAngle(m_MyFirstVector, m_MySecondVector);
        //Vector3 targetDir = target_locaton - cam;
        //Vector3 perfec = targetDir.normalized;
        //float angle = Vector3.SignedAngle(v1,camA,Vector3.up);
        //Debug.Log(shootv);
        //float dot_product = Vector2.Dot(camA,perfec);
        //Debug.Log(dot_product.ToString());
        //double deg = Math.Acos(dot_product)* Mathf.Rad2Deg;
        
        Target.Add(target_locaton.ToString().Remove(0, 1));
        Camera_rotation.Add(camA.ToString().Remove(0, 1));
        ID.Add(id.ToString());
        //DegreeError.Add(deg.ToString());
        Coordenates.Add(CoordenatesInAngle.ToString().Remove(0, 1));
        if (gc.returnWasShot() == true)
        {
            id += 1;
            TimeFrame= 0;
            shots += 1;
            Click.Add("TRUE");
            Number_of_shots.Add(shots.ToString());
            gc.wasShot(false);
        }   
        else if(Input.GetMouseButtonDown(0))
        {
            shots += 1;
            Click.Add("TRUE");
            
        }else{
            Number_of_shots.Add(shots.ToString());
            Click.Add("FALSE");
        }
        
        WriteCsv();
    }

    public void WriteCsv()
    {   Debug.Log(Application.dataPath + "/GetData/test.csv");
        string saveFilePath = Application.dataPath;
        if (File.Exists(saveFilePath + "/GetData/test.csv"))
        {
            try
            {
                File.Delete(saveFilePath + "/GetData/test.csv");
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
        }

        // Debug.Log(saveFilePath);
        TextWriter tw = new StreamWriter(saveFilePath + "/GetData/test.csv", true);

        tw.WriteLine("DATE,TimeFrame,ID,Was Click, X(Target), Y(Target), Z(Target) , X(Camera Rotation), Y(Camera Rotation), Z(Camera Rotation),Pitch ,Yaw,Number of shots");
        for (int i = 0; i < Mathf.Max(Click.Count); ++i)
        {
            if (i < Click.Count) tw.Write(dateNow);
            tw.Write(",");
            if (i < Timef.Count) tw.Write(Timef[i]);
            tw.Write(",");
            if (i < ID.Count) tw.Write(ID[i]);
            tw.Write(",");
            if (i < Click.Count) tw.Write(Click[i]);
            tw.Write(",");
            if (i < Target.Count)
            {
                String tar = Target[i].Remove((Target[i].Length - 1), 1);
                tw.Write(tar);
            }
            tw.Write(",");
            if (i < Camera_rotation.Count)
            {
                String ca = Camera_rotation[i].Remove((Camera_rotation[i].Length - 1), 1);
                tw.Write(ca);
            }
            tw.Write(",");
            //if (i < Camera_rotation.Count) tw.Write(Camera_rotation[i].Remove((Camera_rotation.Count - 1), 1));
            //tw.Write(",");
            if (i < Coordenates.Count){
                String de = Coordenates[i].Remove((Coordenates[i].Length - 1), 1);
                tw.Write(de);
                } 
            tw.Write(",");
            if (i < Number_of_shots.Count) tw.Write(Number_of_shots[i]);
            tw.Write(System.Environment.NewLine);
        }

        tw.Flush();
        tw.Close();
    }
}