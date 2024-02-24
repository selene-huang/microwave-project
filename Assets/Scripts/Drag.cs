using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    
    Vector3 mousePosition;
    public MicrowaveItems microwave;

    public void Start()
    {
        microwave = GameObject.FindAnyObjectByType<MicrowaveItems>();
    }

    private Vector3 MouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        microwave.HeldItem = gameObject;
        mousePosition = gameObject.transform.position - MouseWorldPos();
    }

    private void OnMouseDrag()
    {
        transform.position = MouseWorldPos() + mousePosition;
    }


}
