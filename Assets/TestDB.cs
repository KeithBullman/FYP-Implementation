using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
public class TestDB : MonoBehaviour
{
    public void ReadDB(){
        string conn = "URI=file:" + Application.dataPath + "/Dictionary.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT word, definition " + "FROM entries WHERE word = 'Fight'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            string value = reader.GetString(0);
            string name = reader.GetString(1);
            
            Debug.Log( "WORD="+value+"\tDEFINITION="+name);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
