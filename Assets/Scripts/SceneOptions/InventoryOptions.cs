using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InventoryOptions : MonoBehaviour {


	public void ExitButtonPressed()
    {
        DataController dc = FindObjectOfType<DataController>();
        dc.previousScene = "InventoryScene";
        dc.currentScene = "MenuScene";
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadScanCard()
    {
        DataController data = FindObjectOfType<DataController>();
        data.soloDisplay = true;
        data.previousScene = "InventoryScene";
        Debug.Log("Load Scan Card QR");
        SceneManager.LoadScene("ScanCardScene", LoadSceneMode.Single);
    }

    public void LoadRandomCard()
    {
        DataController data = FindObjectOfType<DataController>();
        data.soloDisplay = true;
        data.previousScene = "InventorySceneRandRoll"; //because we just generated a random card
        data.cardNumber = Random.Range(1, 52); //remember to change this when rest of images are implemented
        SceneManager.LoadScene("ShowCardScene", LoadSceneMode.Single);
    }
}
