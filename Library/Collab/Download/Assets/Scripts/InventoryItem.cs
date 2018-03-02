using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour {
    public int cardSN;
    // Use this for initialization
    public Sprite inventoryIcon;

    bool mouseDowned;
    bool mouseUpped;

	void Start () {
        //load the card data and find the icon of this card on load
        
        DataController data = FindObjectOfType<DataController>();
        cardSN = data.inventory.getNextCardSN();
        CardData cardData = data.GetCardData();
        string[] cardDetails = cardData.GetCardDetails(cardSN);
        //create filepath inside of resources for the sprite to load
        string endPath = "LootObjects/LootObjectImagesQR/" + cardDetails[2];

        Debug.Log(endPath);
        //load the sprite
        inventoryIcon = Resources.Load<Sprite>(endPath);
        //apply the sprite 
        GetComponent<SpriteRenderer>().sprite = inventoryIcon;

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnMouseEnter()
    {
           
    }

    private void OnMouseExit()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Bein click " + cardSN);

    }

    private void OnMouseUpAsButton()
    { 
        
        Debug.Log("Exit click" + cardSN);
        
    }
}
