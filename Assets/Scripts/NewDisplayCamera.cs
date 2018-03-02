using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using System;
using UnityEngine.SceneManagement;

public class NewDisplayCamera : MonoBehaviour {

    private WebCamTexture camTexture;
    private bool hasCamera;
    IBarcodeReader barcodeReader = new BarcodeReader();
    int counter;
    //public Quaternion baseRotation;
    //public Renderer scanArea;
    public Renderer cameraRenderer;
    
    void Start()
    {

        Application.RequestUserAuthorization(UserAuthorization.WebCam); //gotta ask first
        string camname = GetBackCamera();
        if (camname != "")
        {
            camTexture = new WebCamTexture(camname);//, Screen.width, Screen.height, 30);
            //baseRotation = transform.rotation;

            if (camTexture != null)
            {
                hasCamera = true;

                counter = 0;

                cameraRenderer.material.mainTexture = camTexture;
                camTexture.Play();
            }
            else
            {
                hasCamera = false;
            }
        }
    }

    void Update()
    {
        // drawing the camera on screen
        if (hasCamera)
        {
            // do the reading — you might want to attempt to read less often than you draw on the screen for performance sake
            //transform.rotation = baseRotation * Quaternion.AngleAxis(camTexture.videoRotationAngle, Vector3.up);

            try {
                // decode the current frame

                //counter++;
                
                //counter = 0;
                int width = camTexture.width;
                int height = camTexture.height;

                int cropWidth = 300;
                int cropHeight = 300;

               
                //we want to crop this down to something more easily scannable
                
                int centerX = camTexture.width / 2;
                int centerY = camTexture.height / 2;
                int offsetX = centerX - cropWidth/2;
                int offsetY = centerY - cropHeight/2;
                int endpointX = centerX + cropWidth/2;
                int endpointY = centerX + cropHeight/2;

                /*for(int i = offsetX; i < endpointX; i++) {
                    for(int j = offsetY; j < endpointY; j++) {
                        //newImage.Add(image[i+(j * width)]);
                        newImage.Add(new Color32(255, 255, 255, 255));
                    }
                }
                Color32[] newImageArray = newImage.ToArray();
                */
                //Texture2D scanAreaTexture = new Texture2D(cropWidth, cropHeight);
                Color[] pixels = camTexture.GetPixels(offsetX, offsetY, cropWidth, cropHeight);
                //scanAreaTexture.SetPixels(pixels);
                //scanAreaTexture.Apply();
                //scanArea.material.mainTexture = scanAreaTexture;
                Color32[] nPixels = new Color32[pixels.Length];
                for (int i = 0; i < pixels.Length; i++) {
                    nPixels[i] = pixels[i];
                }

                //texture.SetPixels32(newImageArray);

                //var res = barcodeReader.Decode(camTexture.GetPixels32(), camTexture.width, camTexture.height);


                var res = barcodeReader.Decode(nPixels, cropWidth, cropHeight);
                    
                    
                if (res != null) {
                    DataController data = FindObjectOfType<DataController>();
                    CardData cardData = data.GetCardData();
                    int cardNum = Int32.Parse(cardData.GetCardFromURL("Savage Worlds", res.Text)[0]);
                    data.cardNumber = cardNum;
                    Debug.Log("Card number: " + cardNum);

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


                }
                
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
        }
    }

    private string GetBackCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        int deviceTotal = devices.Length;

        if (deviceTotal > 0)
        {
            return devices[0].name;
        }
        else
        {
            for (int i = 0; i < deviceTotal; i++)
            {
                if (!devices[i].isFrontFacing)
                {
                    return devices[i].name;
                }
            }
        }

        Debug.Log("No device found");
        return "";
    }

}
