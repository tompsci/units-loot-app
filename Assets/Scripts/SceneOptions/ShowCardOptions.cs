using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowCardOptions : MonoBehaviour {

    public void ExitButtonPressed()
    {
        DataController dc = FindObjectOfType<DataController>();
        if (dc.previousScene == "InventoryScene" || dc.previousScene == "ScanCardScene" || dc.previousScene == "InventorySceneRandRoll")
        {
            dc.currentScene = "InventoryScene";
            dc.previousScene = "ShowCardScene";
            SceneManager.LoadScene("InventoryScene", LoadSceneMode.Single);
        }
        else if (dc.previousScene == "MenuScene")
        {
            //return to inventory
            dc.currentScene = "MenuScene";
            dc.previousScene = "ShowCardScene";
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }
    }

    public void RollNewCard() {
        DataController data = FindObjectOfType<DataController>();
        data.soloDisplay = true;
        if (data.previousScene == "MenuScene") {
            data.previousScene = "MenuScene"; 
        }
        else {
            data.previousScene = "InventorySceneRandRoll";
        }

        data.cardNumber = Random.Range(1, 52); //remember to change this when all images are in
        
        SceneManager.LoadScene("ShowCardScene", LoadSceneMode.Single);
    }

    public void LoadScanCard() {
        DataController data = FindObjectOfType<DataController>();
        data.soloDisplay = true;
        data.previousScene = "ShowCardScene";
        Debug.Log("Load Scan Card QR");
        SceneManager.LoadScene("ScanCardScene", LoadSceneMode.Single);
    }
}

