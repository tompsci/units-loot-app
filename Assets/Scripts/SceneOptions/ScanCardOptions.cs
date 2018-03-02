using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScanCardOptions : MonoBehaviour {

    public void ExitButtonPressed()
    {
        DataController dc = FindObjectOfType<DataController>();
        if(dc.previousScene == "MenuScene")
        {
            dc.currentScene = "MenuScene";
            dc.previousScene = "ScanCardScene";
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }else if (dc.previousScene == "ShowCardScene" || dc.previousScene == "InventoryScene")
        {
            //return to inventory
            dc.currentScene = "InventoryScene";
            dc.previousScene = "ScanCardScene";
            SceneManager.LoadScene("InventoryScene", LoadSceneMode.Single);
        }
    }

}
