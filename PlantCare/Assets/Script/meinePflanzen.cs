using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class meinePflanzen : MonoBehaviour
{
    public GameObject meinePflanzenButtonPrefab;
    public GameObject mainPanel;
    private string dbName = "URI=file:Plants.db";

    void Start()
    {
        //create the db connection
        using (var connection = new SqliteConnection(dbName)) {
            connection.Open();

            // set up an object (called "command") to allow db control
            using (var command = connection.CreateCommand()) {
                
                //get generalInfo
                command.CommandText = "SELECT plantID, name, nickname FROM userPlants, publicPlants where userPlants.latName=publicPlants.latName;";
                
                //initial button position y
                float myY=205;

                using (IDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Debug.Log("plantID: " + reader["plantID"]);
                        Debug.Log("name: " + reader["name"]);
                        Debug.Log("nickname: " + reader["nickname"]);

                        //create buttons for user plants with custom position
                        //Button meinePflanzeButton = Instantiate(meinePflanzenButtonPrefab) as Button;
                        GameObject meinePflanzeButton = Instantiate(meinePflanzenButtonPrefab);
                        meinePflanzeButton.transform.parent = mainPanel.transform;
                        RectTransform rectTransform = meinePflanzeButton.GetComponent<RectTransform>();
                        Vector2 position = rectTransform.anchoredPosition;
                        rectTransform.anchoredPosition = new Vector2(-85, myY);
                        myY=myY-(rectTransform.rect.height/3);

                        TMPro.TextMeshProUGUI buttonText = meinePflanzeButton.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                        buttonText.text=reader["name"]+"\n"+reader["nickname"];

                        //set onlick
                        //var button = GetComponent<UnityEngine.UI.Button>();
                        //button.onClick.AddListener(() => FooOnClick());
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }

    void FooOnClick()
    {
        Debug.Log("Ta-Da!");
    }
}
