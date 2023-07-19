
using UnityEngine;
using UnityEngine.UIElements;

public class CLICKTarget : MonoBehaviour
{
    
    public bool hit = false;
    float position = 0;

    public void WasHit(bool play)
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
        //transform.position = TargetBounds.Instance.GetRandomPosition();
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
 