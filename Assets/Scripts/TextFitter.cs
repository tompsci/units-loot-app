using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFitter : MonoBehaviour { // This script is used to resize text height on card prefab depending on amount of text

    RectTransform rt;
    Text txt;

    public Vector2 rectAnchorMin;
    public Vector2 rectAnchorMax;
    public Vector2 rectPivot;

    void Start()
    {
       
        FitText();
    }

    public void FitText()
    {
        rt = gameObject.GetComponent<RectTransform>(); // Acessing the RectTransform 
        txt = gameObject.GetComponent<Text>(); // Accessing the text component

        if (txt.preferredHeight >200f) rt.sizeDelta = new Vector2(rt.rect.width, txt.preferredHeight - 200f); // Setting the height to equal the height of text minus 

        float rtHeight = rt.rect.height;
        rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, (rtHeight * -0.5f));
    }
}
