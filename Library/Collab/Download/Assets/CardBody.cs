using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CardBody : MonoBehaviour {

    public Text cardTitle, cardFlavourText, cardDescription, cardAdditionalInfo, cardEffects;
    public Text[][] cardStats, card;


	// Use this for initialization
	void Start () {
        //at start, get whatever value is used to denote the particular card in the database and the game you're playing the cards with (for their particular stats)
        //assign these values to their respective variables
        string cardID = "";
        string gameID = "";
        string[] cardDetails = LoadCardDetails(cardID, gameID);
        cardTitle.text = cardDetails[0];
        cardFlavourText.text = cardDetails[1];
        cardDescription.text = cardDetails[2];
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private string[] LoadCardDetails (string cardID, string gameID) {
        //dummy method for now, will read from file when we have a file to read from
        string[] cardDetails = { "Crowbar", "\"Need to jimmy that?\"", "A solid piece of equipment, well worth its weight. Once you start using it you can´t be without it.", "Reach 1", "" };
        
        return cardDetails;
    }

}
