using System.Collections;
using System.Collections.Generic;
using System.IO;


using UnityEngine;

public class CardData {

    public string[] cardStatNames;
    public List<string[]> allCardDetails;
    private int size;



    public List<KeyValuePair<string, List<string[]>>> allCards; //list of key value pairs - key being deck name, value being collection of all that table's data
    public List<KeyValuePair<string, List<string>>> allRowDetails; 


    public CardData(){
        //later this can be modified with the specific deck we are using
        //LoadTSVCards(filename);
        LoadAllCards(); 
    }

    private void LoadAllCards(){
        //load every set of card data that we're using for now

        DBInterface db = new DBInterface();
        List<string[]> sw = db.LoadDatabase("Savage Worlds");
        List<string[]> lg = db.LoadDatabase("Loot Generator");
        List<string[]> ico = db.LoadDatabase("Card");

        allCards = new List<KeyValuePair<string, List<string[]>>>();
        allCards.Add(new KeyValuePair<string, List<string[]>>("Savage Worlds", sw));
        allCards.Add(new KeyValuePair<string, List<string[]>>("Loot Generator", lg));
        allCards.Add(new KeyValuePair<string, List<string[]>>("Card", ico));

        allRowDetails = new List<KeyValuePair<string, List<string>>>();
        allRowDetails.Add(new KeyValuePair<string, List<string>>("Savage Worlds", db.getColumnNames("Savage Worlds")));
        allRowDetails.Add(new KeyValuePair<string, List<string>>("Loot Generator", db.getColumnNames("Loot Generator"))); //i hope you like spaghetti code
        allRowDetails.Add(new KeyValuePair<string, List<string>>("Card", db.getColumnNames("Card"))); //table for icon lookup
    }

    private void LoadTSVCards(string filename){

        //Debug.Log(Application.dataPath);
        //Debug.Log(cardDetailsPath);
        //string datapath = Application.dataPath + "/Data/dummyTSV2.tsv";
        TextAsset cardDetailsTextAsset = Resources.Load(filename) as TextAsset;
        string cardDetailsFull = cardDetailsTextAsset.ToString();
        //StreamReader reader = new StreamReader(File.OpenRead(datapath));
        string[] cardDetailRows = cardDetailsFull.Split('\n');
       
        allCardDetails = new List<string[]>();
       
        for (int i = 0; i < cardDetailRows.Length; i++)
        {
            allCardDetails.Add(cardDetailRows[i].Split('\t'));
        }
        
        //place each line into an entry in the list and then split the list by the delimiter
        /*while (!reader.EndOfStream)
        {
            allCardDetails.Add(reader.ReadLine().Split('\t'));

        }*/
        cardStatNames = allCardDetails[0];
        allCardDetails.RemoveAt(0);
		Debug.Log (allCardDetails [0] [1]); 

        //Debug.Log(cardStatNames[0]);
        //Debug.Log(cardDetails[0][0]);
        size = cardDetailRows.Length-1; //removing the row for column names
    }

    /* Data Retrieval */
    /*
    public string[] GetCardStatNames(){
        return cardStatNames;
    }

    public List<string[]> GetAllCardDetails(){
        return allCardDetails;
    }

    public string[] GetCardDetails(int cardSN){
        //returns all information on a card going by its serial number
		for (int i = 0; i < size; i++) {
			if (int.Parse(allCardDetails [i] [0]) == cardSN) {
				return allCardDetails[i]; 
			}	
		}

		return allCardDetails[cardSN];
    }

    public int TotalCards(){
        return size;
    }

	public int GetCardSNFromURL(string url){
        //returns the serial number of a card going by its url (result from the barcode scanner)
		for (int i = 0; i < size; i++) {
			if (allCardDetails [i] [1] == url) {
				return int.Parse(allCardDetails [i] [0]); 
			}	
		}
		return -1;
	}
    */
    /* new code w/ db support */ 

    public List<string> GetDeckStatNames(string gameSystem) {
        for(int i = 0; i < allRowDetails.Count; i++) {
            if(allRowDetails[i].Key == gameSystem) {
                return allRowDetails[i].Value; 
            }
        }
        return null; 
    }

    public List<string[]> GetAllDeckCards(string gameSystem) {
        for (int i = 0; i < allCards.Count; i++) {
            if (allCards[i].Key == gameSystem) {
                List<string[]> var = (List < string[] >) allCards[i].Value; //dangerous casting but we know it should always be a list of objects
                
                return var;
            }
        }
        return null;
    }

    public string[] GetCardFromDeck(string gameSystem, string cardID) {
        //returns particular card going by it's unique id
        int deckCount = allCards.Count; 
        for (int i = 0; i < deckCount; i++) {
            if (allCards[i].Key == gameSystem) {
                List<string[]> gSystem = allCards[i].Value; 
                for (int j = 0; j < gSystem.Count; j++) {
                    string[] row = gSystem[j];
                    if(row[0] == cardID) {
                        return row;
                    }
                }
            }
        }
        return null;
    }

    public string[] GetCardFromURL(string gameSystem, string url) {
        //returns the card details from the url scanned via QR

        //grab basic item's row for the sn
        string[] urlRow = null;
        for (int i = 0; i < allCards.Count; i++) {
            if (allCards[i].Key == "Loot Generator") {
                List<string[]> catalogue = allCards[i].Value;
                for (int j = 0; j < catalogue.Count; j++) {
                    string[] row = catalogue[j];
                    if (row[2] == url) {
                        urlRow = row;
                    }
                }
            }
        }

        if (gameSystem == "Loot Generator") {
            return urlRow;
        }
        else {
            //we have the sn now - so we search for all of the items in the given deck with that sn and return it. 
            //Later will add randomisation but for now it just needs to pick the first one
            string sn = urlRow[0];
            for (int i = 0; i < allCards.Count; i++) {
                if (allCards[i].Key == gameSystem) {
                    List<string[]> system = allCards[i].Value;
                    for (int j = 0; j < system.Count; j++) {
                        string[] row = system[j];
                        if (row[1] == urlRow[0]) {
                            return row;
                        }
                    }
                }
            }

        }

      
        return null;
    }

    /* new code ends */


}
