using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class MoveObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector3 uiInitPos;
    [SerializeField] GameObject uiGameObject;
    GameObject panelParent;
    Transform planeTransform;

    private void Start()
    {
        uiInitPos = transform.localPosition;
        planeTransform = GameObject.FindWithTag("Plane").transform;
        panelParent = GameObject.FindWithTag("Panel");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = null;
        transform.localScale = Vector3.one;
        transform.up = planeTransform.up;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        Physics.Raycast(ray, out RaycastHit hit);
        float height = planeTransform.position.y + (GetComponent<MeshFilter>().mesh.bounds.size.y / 2);
        Vector3 newPos = new Vector3(hit.point.x, height, hit.point.z);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 10);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject go = Instantiate(uiGameObject, panelParent.transform);
        go.transform.localPosition = uiInitPos;
        go.transform.localScale = Vector3.one * 100;
    }
}