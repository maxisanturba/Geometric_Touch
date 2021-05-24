using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTouch : MonoBehaviour
{
    //Rehacer Camara. 

    private void Update()
    {
        CamMove();
        CamZoom();
    }
    void CamMove()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            Vector3 newPosition = new Vector3(ray.origin.x, transform.position.y, ray.origin.z);

            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5);
        }
    }

    void CamZoom()
    {
        if (Input.touchCount > 0 && Input.GetTouch(1).phase == TouchPhase.Moved)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(1).position);

            Vector3 newPosition = new Vector3(transform.position.x, ray.origin.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5);
        }
    }
}
