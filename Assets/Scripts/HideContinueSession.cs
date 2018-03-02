using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideContinueSession : MonoBehaviour {
    public Button cont;
    
    //hides continue game button if the user is unable to continue game

    void Start () {
        DataController data = FindObjectOfType<DataController>();
        if(data.save.gameSessions.Count > 0) {
            cont.gameObject.SetActive(true);
        }
        else {
            cont.gameObject.SetActive(false);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
