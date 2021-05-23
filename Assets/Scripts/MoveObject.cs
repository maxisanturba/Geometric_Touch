using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MoveObject : MonoBehaviour
{
    bool isDragged;

    private void Update()
    {
        StartDrag();
        Dragged();
        EndDrag();
    }

    private void StartDrag()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Physics.Raycast(ray, out RaycastHit hit);
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);

            if (hit.collider == this.GetComponent<Collider>())
            {
                isDragged = true;
                this.GetComponent<Rigidbody>().useGravity = false;
            }
        }
    }

    private void Dragged()
    {
        float fixedHeight = 2;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (isDragged)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                Physics.Raycast(ray, out RaycastHit hit);
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                Vector3 newPosition = new Vector3(ray.direction.x + (ray.origin.x / 2), fixedHeight, ray.direction.z + (ray.origin.z / 2));
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 10);
            }
        }
            
    }

    private void EndDrag()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            isDragged = false;
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}