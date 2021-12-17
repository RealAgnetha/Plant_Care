using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class createUserPlant : MonoBehaviour
{
    private string dbName = "URI=file:Plants.db";

    public InputField nicknameInputfield;
    public Transform plantStageDropdown;
    public Text latNameText;

    public void addUsersPlant(){
 
     //get the selected index
         int menuIndex = plantStageDropdown.GetComponent<Dropdown> ().value;
 
     //get all options available within this dropdown menu
         List<Dropdown.OptionData> menuOptions = plantStageDropdown.GetComponent<Dropdown> ().options;
 
     //get the string value of the selected index
         string dropdownValue = menuOptions [menuIndex].text;

        using (var connection = new SqliteConnection(dbName)){
            connection.Open();

            // set up an object (called "command") to allow db control
            using (var command = connection.CreateCommand()){
                Debug.Log(nicknameInputfield.text+ dropdownValue + latNameText.text);
                //sql command for insertion
                command.CommandText = "INSERT INTO userPlants (nickname, plantStage, latName) VALUES ('" + nicknameInputfield.text + "', '" + dropdownValue + "', '" +latNameText.text+ "');";
                command.ExecuteNonQuery(); //runs sql command
            }
            connection.Close();
        }
    }
}
