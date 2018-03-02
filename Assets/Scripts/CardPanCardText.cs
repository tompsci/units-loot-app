using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPanCardText : MonoBehaviour
{

    public float speed = 0.1F;
    public float mouseSensitivity = 1.0F;
    private Vector3 mouseLastPosition;
    public float maximumHeightUntilStartPanning = 200;

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
            RectTransform rect = this.GetComponent<RectTransform>();
            Text scrollableText = this.GetComponentInChildren<Text>();
            //Debug.Log(rect.rect.height);
           if(rect.rect.height > maximumHeightUntilStartPanning) {

            Vector3 delta = Input.mousePosition - mouseLastPosition;
            scrollableText.rectTransform.Translate(0, delta.y * mouseSensitivity * Time.deltaTime, 0);
            mouseLastPosition = Input.mousePosition;

            

            //Clamp the position, minimum y is height inverted. maximum is half height
            //rect.localPosition = new Vector3(rect.localPosition.x, Mathf.Clamp(rect.localPosition.y, rect.rect.height * -1, rect.rect.height / 2), rect.localPosition.z);
            }
        }
    }
}
