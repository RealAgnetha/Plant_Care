using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System;

public class findPlants : MonoBehaviour {

    private string dbName = "URI=file:Plants.db";
    public Transform locationDropdown;
    public Transform sunDropdown;
    public Transform difficultyDropdown;
 
    public void findPlant() {
 
        //checken was ausgewählt ist
        int indexLocation = locationDropdown.GetComponent<Dropdown>().value; //menuIndex
        int indexSun = sunDropdown.GetComponent<Dropdown>().value;
        int indexDifficulty = difficultyDropdown.GetComponent<Dropdown>().value;

        List<Dropdown.OptionData> optionsLocation = locationDropdown.GetComponent<Dropdown>().options;
        List<Dropdown.OptionData> optionsSun = sunDropdown.GetComponent<Dropdown>().options; 
        List<Dropdown.OptionData> optionsDifficulty = difficultyDropdown.GetComponent<Dropdown>().options;
 
        //value ist die jeweils ausgewählte option
        string locationValue = optionsLocation[indexLocation].text;
        string sunValue = optionsSun[indexSun].text;
        string difficultyValue = optionsDifficulty[indexDifficulty].text;

        using (var connection = new SqliteConnection(dbName)) {
            connection.Open();

            using (var command = connection.CreateCommand()) {                
                command.CommandText = "SELECT name, amountOfSunNeeded, difficultyLevel FROM publicPlants WHERE plantsOptimalLocation = '" + locationValue + "'AND amountOfSunNeeded = '" + sunValue + "' AND difficultyLevel = '" + difficultyValue + "';";

                using (IDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Debug.Log("\nName: " + reader["name"]);
                        Debug.Log("\nBraucht " + reader["amountOfSunNeeded"] + " Sonne");
                        Debug.Log("\nSchwierigkeit: " + reader["difficultyLevel"]);
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }


}