using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystemSprite : MonoBehaviour {

	public string gameSystemTitle;


    public void LoadGame(string gameSystem)
    {
        DataController dc = FindObjectOfType<DataController>();
        dc.currentGameSystem = gameSystem;

        if (dc.continuingSession)
        {
            Debug.Log("Trying to load a game of "+ gameSystem);
            dc.LoadGame(gameSystem);
            dc.currentGameSystem = gameSystem;
        }
        else
        {
            Debug.Log("Trying to start a game of " + gameSystem);
            dc.LoadGame(gameSystem);
            dc.currentGameSystem = gameSystem;
            //dc.inventory.cardSNs = new List<int>();
            dc.inventory.ClearInventory();
            dc.SaveGame();
        }

        dc.previousScene = "GameSystemsScene";
        dc.currentScene = "InventoryScene";
        SceneManager.LoadScene("InventoryScene");
    }


    public void LoadSavageWorlds()
    {
        LoadGame("Savage Worlds");
    }

    public void LoadLeviathan()
    {
        LoadGame("Leviathan");
    }

    public void OnMouseUpAsButton()
    {
        if (gameSystemTitle == "SavageWorlds")
        {
            LoadSavageWorlds();
        }
        else if (gameSystemTitle == "Leviathan")
        {
            LoadLeviathan();
        }
    }

}
