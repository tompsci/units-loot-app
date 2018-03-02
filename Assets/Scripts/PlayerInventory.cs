using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class PlayerInventory{

    //public List<int> cardSNs; //an array of the serial numbers of each card in a players inventory
    //public List<string> cardDeckName; //suppose we have a different name for each deck a card is in, and that serial number

    //private int currentPos; //old
    private int pos;

    public string gameSystem;
    private List<ItemDetails> inventoryDetails; //new
    private List<string> columnNames; //new
    /* OLD CODE */
	public PlayerInventory(string gameSystem, List<string> columnNames){
        this.columnNames = columnNames; 
        //cardSNs = new List<int>();
        inventoryDetails = new List<ItemDetails>();
        
        this.gameSystem = gameSystem;
		//currentPos = 0;
	}
    /*
	public int GetNextCardSN(){
        int cardSN = cardSNs [currentPos];
        currentPos++;

        return cardSN;

	}

    public int GetCurrentPos(){
        return currentPos;
    }


	public void ResetPosition(){
		currentPos = 0;
	}
    */

    /* OLD CODE ENDS*/

    /*NEW CODE*/

    public void AddItem(string[] tableRow) {

        ItemDetails id = new ItemDetails(gameSystem, columnNames, tableRow);
        inventoryDetails.Add(id);

    }

    public void DeleteItem(int index) {
        inventoryDetails.RemoveAt(index);
    }

    public ItemDetails GetItemByIndex(int index) {
        return inventoryDetails[index];
    }

    public List<ItemDetails> GetInventory() {
        return inventoryDetails;
    }

    public ItemDetails NextItem() {
        ItemDetails item = inventoryDetails[pos];
        pos++;
        return item; 
    }

    public int GetPos() {
        return pos;
    }

    public void ResetPos() {
        pos = 0;
    }

    public void ClearInventory() {
        inventoryDetails = new List<ItemDetails>();

    }
    /*NEW CODE ENDS*/

}
