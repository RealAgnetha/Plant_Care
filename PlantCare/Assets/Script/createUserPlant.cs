using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System;
using TMPro;

public class createUserPlant : MonoBehaviour
{
    private string dbName = "URI=file:Plants.db";
    //General Variables
    public GameObject erfNotif;
    public bool erfActive = false;
    public GameObject erfBild;
    public GameObject erfTitel;
    public GameObject erfBeschr;
    private bool erf1drin = false;

    //Erster Erfolg Spezifisch
    public static int erf1Count = 0;
    public int erf1Trigger = 2;
    public static int erf1Code = 0;

    public InputField nicknameInputfield;
    public Transform plantStageDropdown;
    public Text latNameText;

    void Update()
    {
        erf1Code = PlayerPrefs.GetInt("Erf1");
        Debug.Log("Erf1drin: "+erf1drin);
        if (erf1Count == erf1Trigger || erf1drin/*&& erf1Code != 12345*/ )
        {
            StartCoroutine(Trigger01Erf());
        }
    }

    public void addUsersPlant(){
 
        /*- Bedingung erfüllen, ob Pflanzenart vorhanden
         *- Bei Erfolg statt Lat. namen, Normalen namen hinzufügen*/

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
                //Get current date
                DateTime thisDay = DateTime.Today;
                int year = thisDay.Year;
                int month = thisDay.Month;
                int day = thisDay.Day;

                //sql command for insertion
                command.CommandText = "INSERT INTO userPlants (nickname, plantStage, latName, yearOfCreation, monthOfCreation, dayOfCreation) VALUES ('" + nicknameInputfield.text + "', '" + dropdownValue + "', '" +latNameText.text+ "', '" + year + "', '" + month + "', '" + day + "' );";
                command.ExecuteNonQuery(); //runs sql command

                Debug.Log("Pflanze hinzugefügt: "+ nicknameInputfield.text+ " " + dropdownValue + " " + latNameText.text+ " " +year+ " " +month+ " " +day);
            }
            connection.Close();
            erf1drin = true;
            Debug.Log("Test");
        }
    }

    //Erfolg
    IEnumerator Trigger01Erf()
    {
        erfActive = true;
        erfNotif.SetActive(true);
        erf1Code = 12345;
        PlayerPrefs.SetInt("Erf1", erf1Code);
        erfBild.SetActive(true);
        erfTitel.GetComponent<TextMeshProUGUI>().text = latNameText.text + " hinzugefügt!";
        erfBeschr.GetComponent<TextMeshProUGUI>().text = "This is a Test message";
        yield return new WaitForSeconds(5);

        //Resetting UI
        erfNotif.SetActive(false);
        erfBild.SetActive(false);
        erfTitel.GetComponent<TextMeshProUGUI>().text = "";
        erfBeschr.GetComponent<TextMeshProUGUI>().text = "";
        erfActive = false;
    }
}
