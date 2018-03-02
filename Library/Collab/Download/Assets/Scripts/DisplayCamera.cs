using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ZXing;
using ZXing.QrCode;

public class DisplayCamera : MonoBehaviour {

	// Use this for initialization

	WebCamTexture cameraFeedTexture;
	IBarcodeReader qrReader;
	bool hasCamera = false;
	void Start () {
		Application.RequestUserAuthorization(UserAuthorization.WebCam); //gotta ask first


		string camname = GetBackCamera ();
		if (camname != "") {
			cameraFeedTexture = new WebCamTexture (camname);

			Renderer renderer = GetComponent<Renderer> ();
			renderer.material.mainTexture = cameraFeedTexture;
			cameraFeedTexture.Play (); 

			qrReader = new BarcodeReader ();
			hasCamera = true; 
		}
		//Plane plane = GetComponent<Plane> ();
		//transform.localScale = new Vector3 (1*(1/Screen.width), 1,  1*(1/Screen.height));
		//float height = 5;
		//height = height / 3;

		//transform.localScale = new Vector3 (height, (float)(1), (float)(1));



	}

	private string GetBackCamera(){
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
		if (hasCamera) {
			Result res = qrReader.Decode (cameraFeedTexture.GetPixels32 (), cameraFeedTexture.width, cameraFeedTexture.height); 
			if (res != null) {
				Debug.Log (res.Text); 
				//reminder to check that the qr code being decoded IS in fact one of the cards
				DataController cards = FindObjectOfType<DataController> ();
				//int cardNum = -1;

				CardData cardData = cards.GetCardData ();
				int cardNum = cardData.GetCardSNFromURL (res.Text);
				cards.cardNumber = cardNum;

				if (cardNum >= 0) {
					SceneManager.LoadScene ("ShowCardScene", LoadSceneMode.Single);
				} else {
					SceneManager.LoadScene ("MenuScene", LoadSceneMode.Single);

				}

				//SceneManager.LoadScene ("MenuScene", LoadSceneMode.Single);

			}
		}
	}
}
