using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class CardSceneController : MonoBehaviour {

    public Button scan;
    public Button roll;
    public Button view;
    public Button discard;

    private bool removed;

    private void Start()
    {
        DataController data = FindObjectOfType<DataController>();
        if (data.previousScene == "ScanCardScene" || data.previousScene == "InventorySceneRandRoll")
        {
            scan.gameObject.SetActive(true);
            SaveCardToInventory();
            removed = false;

        }
        if (data.previousScene == "MenuScene")
        {
            roll.gameObject.SetActive(true);
            discard.gameObject.SetActive(false);
            view.gameObject.SetActive(false);

        }
    }

    public void LoadMenuScene()
    {
        DataController data = FindObjectOfType<DataController>();
        data.previousScene = "ShowCardScene";
        data.currentScene = "MenuScene";
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

	public void SaveCardToInventory(){
       
        DataController data = FindObjectOfType<DataController>();
        //save card to inventory
        PlayerInventory pi = data.inventory;
        //pi.cardSNs.Add(data.cardNumber);

        //display card saved notification?

        //given the card ID and the gamesystem - find the row in the database
        //save that row into the player inventory
        string gs = data.currentGameSystem;

        //REPLACE THIS ONCE WE HAVE DB FULLY WORKING!!!
        gs = "Savage Worlds";
        //REPLACE 

        int cn = data.cardNumber;
        //Debug.Log("Card number = " + cn);
        //Debug.Log("CN = " + data.cardNumber);
        //Debug.Log(gs);

        //Debug.Log(data.GetCardData().GetCardFromDeck(gs, cn.ToString()));
        CardData cd = data.GetCardData();
        //Debug.Log("Getting the card: " + cd.GetCardFromDeck(gs, cn.ToString())[0]);
        string[] obj = cd.GetCardFromDeck("Savage Worlds", "1");

        //Debug.Log("GETTING CARD FROM DECK: " + cd.GetCardFromDeck("Savage Worlds", "1")[0]);

        System.Object[] cardInfo = cd.GetCardFromDeck(gs, cn.ToString());
        //pi.AddItem(cardInfo);
        //Debug.Log(cardInfo[0]);
        //getcarddata is broken :/
        pi.AddItem(data.GetCardData().GetCardFromDeck(gs, cn.ToString())); //using this
        //pi.AddItem(itemRow);

        Debug.Log("Card saved to inventory");
        EditorUtility.DisplayDialog("Yay!", "Card saved to inventory successfully", "OK");
        data.SaveGame();

    }

    public void RemoveCardFromInventory()
    {
        if (removed == false) //double removal bug hacky fix
        {
            removed = true;

            DataController data = FindObjectOfType<DataController>();
            //save card to inventory
            PlayerInventory pi = data.inventory;
            //pi.cardSNs.RemoveAt(data.cardIndexInInventory);

            if(data.previousScene == "InventorySceneRandRoll" || data.previousScene == "ScanCardScene") {
                data.cardIndexInInventory = data.inventory.GetInventory().Count - 1;
            }
            pi.DeleteItem(data.cardIndexInInventory);
            //display card saved notification
            //Debug.Log(data.cardIndexInInventory); 
            //we can keep this the same as long as we maintain it in the same way
            Debug.Log("Card removed from inventory");

            data.SaveGame();
        }
    }

    public void LoadScanCard(){
        DataController data = FindObjectOfType<DataController>();
        data.previousScene = "ShowCardScene";
        data.currentScene = "ScanCardScene";
		SceneManager.LoadScene ("ScanCardScene", LoadSceneMode.Single); 
	}

	public void LoadInventory(){
        DataController data = FindObjectOfType<DataController>();
        data.soloDisplay = false;
        data.currentScene = "InventoryScene";
        data.previousScene = "ShowCardScene";
        SceneManager.LoadScene ("InventoryScene", LoadSceneMode.Single);
	}

}
