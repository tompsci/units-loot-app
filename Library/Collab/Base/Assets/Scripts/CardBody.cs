using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;



public class CardBody : MonoBehaviour {

    public Text cardTitle, cardFlavourText, cardDescription, cardAdditionalInfo, cardEffects, cardStats;
    public Image cardPicture;
    private int cardID; 
    // Use this for initialization
    void Start () {
        //at start, get whatever value is used to denote the particular card in the database and the game you're playing the cards with (for their particular stats)
        //assign these values to their respective variables
        //Debug.Log("WE ACTUALLY REACH HERE (start)");


        DataController data = FindObjectOfType<DataController>();
        cardID = data.cardNumber; 
        //Debug.Log("DataController found successfully");

        CardData cardData = data.getCardData();

        //Debug.Log("CardData accessed successfully");
        //assume card serial number is arbitrary number for now
        string[] cardDetails = cardData.getCardDetails(cardID);
        string[] cardStatNames = cardData.getCardStatNames();

        /*
        Debug.Log(cardDetails[2]);
        Debug.Log(cardDetails[4]);
        Debug.Log(cardDetails[5]);
        Debug.Log(cardDetails[7]);
        Debug.Log(cardDetails[8]);
        */

        cardTitle.text = cardDetails[3];
        cardFlavourText.text = cardDetails[5];
        cardDescription.text = cardDetails[6];
        cardAdditionalInfo.text = cardDetails[8];
        cardEffects.text = cardDetails[9];

        string cardStatString = "";

        for (int i = 10; i < cardDetails.Length; i++)
        {
            if (cardDetails[i] != "") {
                cardStatString += (cardStatNames[i] + ": " + cardDetails[i] + '\n');
            }
        }

        //for each card stat that is present, grab name of stat and combine them such that the text looks like "statName: stat\n"

        cardStats.text = cardStatString;

        /*
        string trimmedCardName = "";
        trimmedCardName = cardDetails[3].Replace(" ", string.Empty);
        
        */
        string endPath = "LootObjects/LootObjectImagesQR/" + cardDetails[2];

        Debug.Log(endPath);
        cardPicture.sprite = Resources.Load<Sprite>(endPath);
        //Debug.Log(cardDetails[2]);

    }

   

    // Update is called once per frame
    void Update () {
        //Debug.Log("WE ACTUALLY REACH HERE (update)");
    }

}
