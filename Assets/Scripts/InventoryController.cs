using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//load the x cards into place
		List<GameObject> instances = new List<GameObject>();

		DataController data = FindObjectOfType<DataController>();
		//List<int> cardsInInventory = data.inventory.getInventory;
        List < ItemDetails > cardsInInventory = data.inventory.GetInventory(); 
		int row = 0;
		int column = 0;
        Debug.Log(cardsInInventory.Count); 
		for (int i = 0; i < cardsInInventory.Count; i++) {
			GameObject instance = Instantiate(Resources.Load("prefabs/InventoryItem2D", typeof(GameObject))) as GameObject;
			instance.transform.parent = GameObject.Find ("InventoryContent").transform;
			instance.transform.Translate (new Vector3 ((7*column), (7* -row)-2, 0)); 
			column++;

			if ((i + 1) % 3 == 0) {
				column =0;
				row++;
			}

		}
		data.inventory.ResetPos (); //always call this >:(

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
