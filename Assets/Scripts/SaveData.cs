using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine;

[System.Serializable]

public class SaveData{
    //class controlling saving and loading all game data for a current session
    //probably also going to be used for settings in the future 
    public List<PlayerInventory> gameSessions;
    public SaveData()
    {
        
    }

    public void InitSave()
    {
        
        //ClearAllSaveData(); //tfw I have to do this so often it's staying here
        try {
            if (File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
                gameSessions = (List<PlayerInventory>)bf.Deserialize(file);
                file.Close();
                Debug.Log("Loading currently existing save data");
            }
            else {
                gameSessions = new List<PlayerInventory>();
            }
        }catch(Exception e) {
            //this has potential to be REALLY stupid 
            //but right now it just saves me from having to manually delete playerprefs 
            //every single time I change what I'm saving
            ClearAllSaveData();
            InitSave();
        }
       
    }

    public void SaveSession(PlayerInventory inv)
    {
        bool saved = false; 
        for (int i = 0; i < gameSessions.Count; i++)
        {
            if (gameSessions[i].gameSystem == inv.gameSystem)
            {
                //overrwrite current game system and continue
                gameSessions[i] = inv;
                saved = true;
            }
        }

        if (!saved)
        {
            //add game, as no saved game currently exists of this gamesystem
            gameSessions.Add(inv);
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, gameSessions);
        file.Close();
        //gameSessions.Add(data.inventory);
        //save now
    }

    public PlayerInventory LoadSession(string gameSystem)
    {
        Debug.Log("Searching for game session of current game system");
        for (int i = 0; i < gameSessions.Count; i++)
        {
            if (gameSessions[i].gameSystem == gameSystem)
            {
                //overrwrite current game system and continue
                Debug.Log("A saved game of the current game system has been found. Loading.");
                return gameSessions[i];
            }
        }
        Debug.Log("No saved game of the current game system has been found. Creating fresh save.");
        //this is a new saved game so we need to fetch column names over
        Debug.Log("GameSystem: " + gameSystem);
        DBInterface dbi = new DBInterface(); 
        return new PlayerInventory(gameSystem, dbi.getColumnNames(gameSystem));

    }

    public void ClearAllSaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        gameSessions = new List<PlayerInventory>();
        bf.Serialize(file, gameSessions);
        file.Close();
    }

}
