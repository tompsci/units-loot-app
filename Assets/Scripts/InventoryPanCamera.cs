using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanCamera : MonoBehaviour {

    public float speed = 0.1F;
    public float mouseSensitivity = 1.0F;
     private Vector3 mouseLastPosition;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(0, -touchDeltaPosition.y * speed * Time.deltaTime, 0);
        }


        if (Input.GetMouseButtonDown(0))
        {
            mouseLastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - mouseLastPosition;
            transform.Translate(0, -delta.y * mouseSensitivity * Time.deltaTime, 0);
            mouseLastPosition = Input.mousePosition;
        }

    }

 
}
