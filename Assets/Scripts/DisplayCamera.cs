using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using ZXing;
using ZXing.QrCode;
using System;

public class DisplayCamera : MonoBehaviour {

	// Use this for initialization

	WebCamTexture cameraFeedTexture;
    DataController data;
    IBarcodeReader qrReader;
	bool hasCamera = false;
    public RawImage rawimage; 
	void Start () {

        Application.RequestUserAuthorization(UserAuthorization.WebCam); //gotta ask first
        data = FindObjectOfType<DataController>();


     
        //set up camera

        string camname = GetBackCamera ();
		if (camname != "") {

            cameraFeedTexture = new WebCamTexture (camname, Screen.width, Screen.height, 30);
       
            /*
            Renderer renderer = GetComponent<Renderer> ();
            
			renderer.material.mainTexture = cameraFeedTexture;
            */
            
            rawimage.texture = cameraFeedTexture;
            rawimage.material.mainTexture = cameraFeedTexture;


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
    int counter = 0;

	void Update () {
        if (hasCamera) {
            counter++;
            if (counter >= 5) {
                counter = 0;
                Result res = qrReader.Decode(cameraFeedTexture.GetPixels32(), cameraFeedTexture.width, cameraFeedTexture.height);
                if (res != null) {
                    Debug.Log(res.Text);
                    //reminder to check that the qr code being decoded IS in fact one of the cards
                    DataController cards = FindObjectOfType<DataController>();
                    //int cardNum = -1;

                    CardData cardData = cards.GetCardData();
                    int cardNum = Int32.Parse(cardData.GetCardFromURL("Savage Worlds", res.Text)[0]);
                    cards.cardNumber = cardNum;

                    if (cardNum >= 0) {
                        data.previousScene = "ScanCardScene";
                        data.currentScene = "ShowCardScene";
                        SceneManager.LoadScene("ShowCardScene", LoadSceneMode.Single);
                    }
                    else {
                        //come back to this to give some kind of  notif that the qr code scanned isn't right
                        data.previousScene = "ScanCardScene";
                        data.currentScene = "MenuScene";
                        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);

                    }

                    //SceneManager.LoadScene ("MenuScene", LoadSceneMode.Single);

                }
            }
        }
	}
}
