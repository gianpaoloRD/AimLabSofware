using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLICKTargetNot : MonoBehaviour
{
    [SerializeField] Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                FLICKTarget target = hit.collider.gameObject.GetComponent<FLICKTarget>();
                if (target != null)
                {
                    Destroy(target.gameObject);
                }

            }
        }
    }
}
