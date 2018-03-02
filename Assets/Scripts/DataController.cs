using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.SceneManagement;

using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;

public class DataController : MonoBehaviour {

    public CardData cd;

    public PlayerInventory inventory;
    public SaveData save; 
    public int cardNumber;
    public int cardIndexInInventory;

	public bool soloDisplay;
    public string currentGameSystem = "Savage Worlds";
    public string previousScene, currentScene;

    public bool continuingSession;

	// Use this for initialization
	void Start () {

       
        DBInterface db = new DBInterface();

        cd = new CardData();
      
        previousScene = "Persistent";
        currentScene = "MenuScene";
		soloDisplay = true;
		//inventory.loadInventory (); //does nothing for now
		/*for(int i =1; i <= 54; i++){
			inventory.cardSNs.Add (i);
		}*/

        save.InitSave();

        //cd.getCardSNFromURL ("http://units.systems/deck/fire-axe/");
        DontDestroyOnLoad(gameObject); //loads this data into a different scene which is never unloaded
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);

    }

    // Update is called once per frame
    void Update () {
		
	}

    public CardData GetCardData()
    {
        return cd;
    }

    
    public void SaveGame()
    {
        save.SaveSession(inventory);
    }

    public void LoadGame(string currentGameSystem)
    {
        
        inventory = save.LoadSession(currentGameSystem);
    }

    
}
