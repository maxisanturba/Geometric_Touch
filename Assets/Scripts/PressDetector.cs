using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PressDetector : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject formToInstantiate;
    Vector3 initPos;
    Vector3 endPos;

    private void Start()
    {
        initPos = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.GetTouch(0).position;

        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        endPos = new Vector3(ray.direction.x, ray.origin.y + 2 , ray.direction.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Instantiate(formToInstantiate, endPos, Quaternion.identity, null);
        transform.localPosition = initPos;
    }
}
