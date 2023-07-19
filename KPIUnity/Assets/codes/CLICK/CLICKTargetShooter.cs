 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLICKTargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                CLICKTarget target = hit.collider.gameObject.GetComponent<CLICKTarget>();
                if (target != null)
                {
                    target.Hit();
                }
                CLICKTargetRigth targetRigth = hit.collider.gameObject.GetComponent<CLICKTargetRigth>();
                if (targetRigth != null)
                {
                    targetRigth.Hit();
                }

            }
        }
    }
}
