using System.Collections;
using System.Collections.Generic;
using System.IO;


using UnityEngine;

public class CardData {

    public string[] cardStatNames;
    public List<string[]> allCardDetails;
    private int size;
 
    public CardData(){
        //later this can be modified with the specific deck we are using
        LoadTSVCards();
    }
	
	

    private void LoadTSVCards()
    {
        //dummy method for now, will read from file when we have a file to read from

        //Debug.Log(Application.dataPath);
        //Debug.Log(cardDetailsPath);
        //string datapath = Application.dataPath + "/Data/dummyTSV2.tsv";
        TextAsset cardDetailsTextAsset = Resources.Load("Data/dummy3") as TextAsset;
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

    public string[] getCardStatNames()
    {
        return cardStatNames;
    }

    public List<string[]> getAllCardDetails()
    {
        return allCardDetails;
    }

    public string[] getCardDetails(int cardSN)
    {
        
		for (int i = 0; i < size; i++) {
			if (int.Parse(allCardDetails [i] [0]) == cardSN) {
				return allCardDetails[i]; 
			}	
		}

		return allCardDetails[cardSN];
    }

    public int totalCards()
    {
        return size;
    }

	public int getCardSNFromURL(string url){

		for (int i = 0; i < size; i++) {
			if (allCardDetails [i] [1] == url) {
				return int.Parse(allCardDetails [i] [0]); 
			}	
		}
		return -1;
	}

}
