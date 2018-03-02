using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;



public class CardBody : MonoBehaviour {

    public Text cardTitle, cardFlavourText, cardDescription, cardAdditionalInfo, cardEffects;
    public Text[][] cardStats; //2 dimensional array for now, the name of the stat paired to the item on the card
    public string cardDetailsPath;

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
        cardEffects.text = cardDetails[3];
        cardAdditionalInfo.text = cardDetails[4];

        Debug.Log("Hello");

        cardDetailsPath = Application.dataPath + "Assets\\Data\\dummy.csv";
        Debug.Log(Application.dataPath);
        Debug.Log(cardDetailsPath);

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    private string[] LoadCardDetails (string cardID, string gameID) {
        //dummy method for now, will read from file when we have a file to read from
        
        StreamReader reader = new StreamReader (File.OpenRead(cardDetailsPath));
        Debug.Log(reader.ReadToEnd());

        string[] cardDetails = { "Crowbar", "\"Need to jimmy that?\"", "A solid piece of equipment, well worth its weight. Once you start using it you can´t be without it.", "Reach 1", "" };
        
        return cardDetails;
    }

}
