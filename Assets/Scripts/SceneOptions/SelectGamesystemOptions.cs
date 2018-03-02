using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectGamesystemOptions : MonoBehaviour {

  

    public void ExitButtonPressed()
    {
        DataController dc = FindObjectOfType<DataController>();
        dc.previousScene = "GameSystemsScene";
        dc.currentScene = "MenuScene";
        SceneManager.LoadScene("MenuScene");
    }
}
