using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.RequestUserAuthorization(UserAuthorization.WebCam); //gotta ask first


		string camname = getBackCamera ();
		//Plane plane = GetComponent<Plane> ();
		//transform.localScale = new Vector3 (1*(1/Screen.width), 1,  1*(1/Screen.height));
		float height = 5;
		height = height / 3;

		transform.localScale = new Vector3 (height, (float)(1), (float)(1));


		WebCamTexture cameraFeedTexture = new WebCamTexture (camname);



		Renderer renderer = GetComponent<Renderer> ();
		renderer.material.mainTexture = cameraFeedTexture;
		cameraFeedTexture.Play (); 
	}

	private string getBackCamera(){
		WebCamDevice[] devices = WebCamTexture.devices;

		int deviceTotal = devices.Length; 

		if (deviceTotal > 0) {
			return devices [0].name;
		} else {
			for (int i = 0; i < deviceTotal; i++) {
				if (!devices [i].isFrontFacing) {
					return devices [i].name;
				}
			}
		} 
			
		Debug.Log("No device found");
		return ""; 
	}


	// Update is called once per frame
	void Update () {
		
	}
}
