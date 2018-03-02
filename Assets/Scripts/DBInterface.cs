using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Collections;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class DBInterface{
    
    public DBInterface(){

        /*Debug.Log(conn);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT sn FROM Card";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int value = reader.GetInt32(0);

            Debug.Log("value= " + value );
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        */

        LoadDatabase("SavageWorlds");

    }


    //loads a gamesystem in to 
    public List<string[]> LoadDatabase(string gameSystem){
        Debug.Log(Application.persistentDataPath);

        String gameSystemTable = getTableName(gameSystem);

        //Debug.Log(conn);
        //we just load all the data in from a table in the db for this.
        string sqlQuery = "SELECT * FROM " + gameSystemTable; //create query. eventually replace this with statement builder?

        return ExecuteQuery(sqlQuery);
        
    }

    public List<string> getColumnNames(string gameSystem) {
        String gameSystemTable = getTableName(gameSystem);

        string sqlQuery = "PRAGMA table_info(" + gameSystemTable + ")";

        List<string[]> results = ExecuteQuery(sqlQuery);

        List<string> columnNames = new List<string>();

        for (int i = 0; i < results.Count; i++) {
            columnNames.Add(results[i][1]); //add the column name from the query to the table. Pragma works a bit funny but this still seems the tidiest way to do it
        }

        return columnNames;

    }

    private List<string[]> ExecuteQuery(string sqlQuery){
        string conn = "URI=file:" + Application.persistentDataPath + "/unitslocaldb.db"; //Path to database.
       

        if (Application.platform == RuntimePlatform.Android) {

            string frompath = Application.streamingAssetsPath + "/unitslocaldb.db";

            string topath = Application.persistentDataPath + "/unitslocaldb.db";
            if (File.Exists(topath)) {
                File.Delete(topath);
                Debug.LogWarning("Deleting unitslocaldb");
                if(!File.Exists(topath)) {
                    Debug.LogWarning("Deleted unitslocaldb successfully");
                }
            }

            if (!File.Exists(topath)) {
                Debug.LogWarning("File " + topath + " does not exist. Attempting to create from " +
                                 frompath);
                // if it doesn't ->
                // open StreamingAssets directory and load the db -> 
                WWW loadDB = new WWW(frompath);
                while (!loadDB.isDone) { }

                //while (!loadDB.isDone) { }
                // then save to Application.persistentDataPath
                File.WriteAllBytes(topath, loadDB.bytes);


                loadDB.Dispose();
                loadDB = null;

                if (File.Exists(topath)) {
                    Debug.LogWarning(topath + " exists");
                }
                else {
                    Debug.LogWarning(topath + " doesn't exist");
                }
                if (File.Exists(frompath)) {
                    Debug.LogWarning(frompath + " Also exists. What's the problem?");
                }
                else {
                    Debug.LogWarning(frompath + " Still doesn't exist either. What's the problem?");
                }

            }

        }
        else {
            Debug.Log(Application.dataPath + "/StreamingAssets/unitslocaldb.db");
            conn = "URI=file:" + Application.dataPath + "/StreamingAssets/unitslocaldb.db";
        }

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        dbcmd.CommandText = sqlQuery; //set query to command text
        IDataReader reader = dbcmd.ExecuteReader(); //Execute statement, take result set

        List<string[]> results = new List<string[]>();
        
        while (reader.Read())
        {
            int fc = reader.FieldCount;

            //int value = reader.GetInt32(0);
            System.Object[] values = new System.Object[fc]; //create array the size of each item in the row
            reader.GetValues(values); //store items from db into array 
            //results.Add(values); //add array to list
            string[] strValues = new string[fc]; //cast whole array to string
            for (int i  = 0; i < values.Length; i++) {
                strValues[i] = values[i].ToString(); 
            }
            results.Add(strValues);
            /*Debug.Log("Next Item:");
            Debug.Log(values[0]);
            Debug.Log(values[1]);
            Debug.Log(values[2]);
            Debug.Log(values[3]);
            Debug.Log(values[4]);
            */

        }
        reader.Close(); //we leaving
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        
        return results;
        //return res;

    }
    

    //method for gamesystem + aliases to retrieve table name
    private string getTableName(string gameSystem) {
        string gameSystemTable = "";

        switch (gameSystem) //determine the name of table in database for that gamesystem
        {
            case "SavageWorlds":
                gameSystemTable = "SavageWorlds";
                break;
            case "Savage Worlds":
                gameSystemTable = "SavageWorlds";
                break;
            case "LootGenerator":
                gameSystemTable = "LootGeneratorData";
                break;
            case "Loot Generator":
                gameSystemTable = "LootGeneratorData";
                break;
            case "RotSystem":
                break;

            case "Leviathan":
                gameSystemTable = "SavageWorlds"; //just for now
                break;
            case "ApocalypseWorld":
                break;
            case "Noir":
                break;
            case "Card":
                gameSystemTable = "Card";
                break;
            default:
                break;
        }

        return gameSystemTable; 

    }
}
