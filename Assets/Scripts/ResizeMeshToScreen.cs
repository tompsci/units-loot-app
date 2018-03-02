using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeMeshToScreen : MonoBehaviour {
    public Camera MainCamera;

	// Use this for initialization
	void Start () {
       /* Vector3 heading = gameObject.transform.position - MainCamera.transform.position;
        float distance = Vector3.Dot(heading, MainCamera.transform.forward);

        var height = 2.0 * Mathf.Tan((float)(0.5 * MainCamera.fieldOfView * Mathf.Deg2Rad)) * (float) distance;
        var width = height * MainCamera.aspect;

        gameObject.transform.localScale = new Vector3((float)width,(float)height,1);*/
    }
	

}
