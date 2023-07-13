using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
public class CLICKTargetRigth : MonoBehaviour
{
    public bool hit = false;
    float position = 0;

    public void wasHit(bool play)
    {
        this.hit = play;
    }
    public bool returnWasHit()
    {
        return this.hit;
    }
    public void Hit()
    {
        this.hit = true;
        this.position = transform.position.x;
        //transform.position = TargetBounceRigth.Instance.GetRandomPosition();

    }
    public Vector3 GetPostion()
    {   

        return transform.position;
    }
    public Vector3 GetPostionHit()
    {

        return new Vector3(this.position, 0, 0);
    }

}