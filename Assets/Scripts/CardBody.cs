using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;



public class CardBody : MonoBehaviour {

    public Text cardTitle, cardFlavourText, cardStats;
    public Image cardPicture;
    private int cardID;
    private int cardDetailsStartIndex;

    // Use this for initialization
    void Start () {
        //at start, get whatever value is used to denote the particular card in the database and the game you're playing the cards with (for their particular stats)
        //assign these values to their respective variables
        //Debug.Log("WE ACTUALLY REACH HERE (start)");

		DataController data = FindObjectOfType<DataController>();
		cardID = data.cardNumber;
        string gameSystem = data.currentGameSystem;
        gameSystem = "Savage Worlds"; //change once we have tracking this working
		LoadDataToCard (cardID, gameSystem, data);

    }
		
    public void PopulateCard(int cardID, DataController data) {
        //get the game system
        //get the card from the game system
        //load data into appropriate places
        //find image + load it
    }

	public void LoadDataToCard(int cardID, string gameSystem, DataController data){


		CardData cardData = data.GetCardData();

		string[] cardDetails = cardData.GetCardFromDeck(gameSystem, cardID.ToString());
		List<string> cardStatNames = cardData.GetDeckStatNames(gameSystem);

        cardTitle.text = cardDetails[4]; 
       if(cardDetails[3] != "") {
            cardTitle.text = cardDetails[3] + " " + cardTitle.text;
        }
       if(cardDetails[5] != "") {
            cardTitle.text = cardTitle.text + " " + cardDetails[5];
        }

		cardFlavourText.text = cardDetails[7]; 

		for (int i = 0; i<cardStatNames.Count; i++)
		{ 
			if (cardStatNames[i] == "Description") //Get the index of where cardDetails start in Database
			{
				cardDetailsStartIndex = i; 

				break;
			}
		} 

		string cardStatString = "";

		for (int i = cardDetailsStartIndex; i < cardDetails.Length; i++)
		{
			if (!string.IsNullOrEmpty(cardDetails[i].ToString()) && cardDetails[i].Length != 0 && cardDetails[i] != " " && cardDetails[i].Trim() != "") {
                if( cardStatNames[i] == "Description")
                {
                    cardStatString += ("\n" + cardDetails[i].ToString() + '\n');
                }
                else if(cardStatNames[i] != "FlavourText") {

                    cardStatString += (cardStatNames[i] + ": " + cardDetails[i].ToString() + '\n');

                }
            }
        }

        //for each card stat that is present, grab name of stat and combine them such that the text looks like "statName: stat\n"
        cardStats.text = cardStatString;



        string[] imgDetails = cardData.GetCardFromDeck("Card", cardID.ToString());
        string endPath = "LootObjects/LootObjectImagesQR/" + imgDetails[3];

		Debug.Log(endPath);
		cardPicture.sprite = Resources.Load<Sprite>(endPath);
        //Debug.Log(cardDetails[2]);


        //Load Text Fitter to fit stats text
        cardStats.gameObject.GetComponent<TextFitter>().FitText();
    }


    // Update is called once per frame
    void Update () {
        //Debug.Log("WE ACTUALLY REACH HERE (update)");
    }

}
