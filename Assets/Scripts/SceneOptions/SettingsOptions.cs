using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingsOptions : MonoBehaviour {


    public void ClearAllGameData()
    {
        DataController data = FindObjectOfType<DataController>();
        data.save.ClearAllSaveData(); 
    }

    public void BackButtonPressed()
    {
        DataController data = FindObjectOfType<DataController>();
        data.currentScene = "MenuScene";
        data.previousScene = "SettingsScene";
        SceneManager.LoadSceneAsync("MenuScene", LoadSceneMode.Single);
    }
}
