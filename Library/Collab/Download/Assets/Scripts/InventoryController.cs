using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//load the x cards into place
		List<GameObject> instances = new List<GameObject>();

		DataController data = FindObjectOfType<DataController>();
		List<int> cardsInInventory = data.inventory.cardSNs;
		int row = 0;
		int column = 0;
		int baseX = 0;
		int baseY = 0;
		for (int i = 0; i < cardsInInventory.Count; i++) {
			GameObject instance = Instantiate(Resources.Load("prefabs/InventoryItem", typeof(GameObject))) as GameObject;
			instance.transform.parent = GameObject.Find ("InventoryCanvas").transform;
			instance.transform.Translate (new Vector3 ((7*column), (7* -row), 0)); 
			column++;

			if ((i + 1) % 3 == 0) {
				column =0;
				row++;
			}

		}
		data.inventory.resetPosition (); //always call this >:(




	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
