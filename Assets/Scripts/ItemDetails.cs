using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ItemDetails{

    //different database means 


    //What do we want to know about our item?
    //basically all we want its row from the database it's in, and the gamesystem it belongs to.
    
    //we're storing the same data a lot but it's because in the future we may not be using the same table for each gamesystem - eg custom gamesystems including items from an old pool. maybe.

    string gameSystem, sourceDB;
    List<string> columnNames;
    string[] tableRow;
    int fieldCount;

    

    public ItemDetails(string gameSystem, List<string> columnNames, string[] tableRow) {
        this.gameSystem = gameSystem;
        this.columnNames = columnNames;
        this.tableRow = tableRow;

        fieldCount = tableRow.Length;

    }


    public string GetValue(string valueName) {
        int index = columnNames.IndexOf(valueName);

        return tableRow[index];
    }

}
