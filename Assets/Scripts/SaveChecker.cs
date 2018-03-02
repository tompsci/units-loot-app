using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveChecker : MonoBehaviour {

    //check which saves are present and enable resume game for said present saves. If not, load a text element that tells the user they have no ongoing sessions.
    public GameObject lev;
    public GameObject sw;

	// Use this for initialization
	void Start () {
        DrawGameSystems(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DrawGameSystems() {
        //grab save data
        //check title of each system
        //enable each system that matches the present titles
        DataController data = FindObjectOfType<DataController>();
        SaveData save = data.save;
        List<PlayerInventory> sessions = save.gameSessions;
        for (int i = 0; i < sessions.Count; i++) {
            if (sessions[i].gameSystem == "Savage Worlds") {
                sw.SetActive(true);
            }
            else if (sessions[i].gameSystem == "Leviathan") {
                //GameObject.Find("GSLeviathan").SetActive(true);
                lev.SetActive(true);
            }
            else {
                Debug.Log("Unsupported Game System found in save file");
            }

        }
    }
}
