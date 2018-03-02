using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class InventoryItem : MonoBehaviour {
    public int cardSN;
    public int cardIndexInInventory;
    // Use this for initialization
    public Sprite inventoryIcon;

    bool mouseDowned;
    bool mouseUpped;

	void Start () {
        //load the card data and find the icon of this card on load
        
        DataController data = FindObjectOfType<DataController>();
        cardIndexInInventory = data.inventory.GetPos();

        cardSN = Int32.Parse(data.inventory.NextItem().GetValue("SN"));
        Debug.Log("Card Serial Number: " + cardSN + " Card Index in Inventory: " + cardIndexInInventory);
        CardData cardData = data.GetCardData();
        string[] cardDetails = cardData.GetCardFromDeck("Card", cardSN.ToString());
        //create filepath inside of resources for the sprite to load
        
        string endPath = "LootObjects/LootObjectImagesQR/" + cardDetails[3];

        Debug.Log(endPath);
        //load the sprite
        inventoryIcon = Resources.Load<Sprite>(endPath);
        //apply the sprite 
        GetComponent<Image>().sprite = inventoryIcon;

    }

    // Update is called once per frame
    void Update () {
		
	}

  

    public void ItemClicked()
    { 
        
        Debug.Log("Exit click" + cardSN);
        DataController data = FindObjectOfType<DataController>();
        data.soloDisplay = true;
        data.cardNumber = cardSN;
        data.previousScene = "InventoryScene";
        
        data.cardIndexInInventory = cardIndexInInventory;
        
        SceneManager.LoadScene("ShowCardScene", LoadSceneMode.Single);
    }
}
