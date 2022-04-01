using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
public class TestDB : MonoBehaviour
{
    public bool ReadDB(string userInput){
        string conn = "URI=file:" + Application.dataPath + "/Dictionary.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT word, definition " + "FROM entries WHERE word = '" + userInput + "'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        
        
        if(reader.Read() == false){
            return false;
        }
        else{
            return true;
        }
        
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
