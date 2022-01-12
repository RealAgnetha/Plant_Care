using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadPlantInfo : MonoBehaviour
{
    public void loadInfo(){
        Debug.Log(PlayerPrefs.GetInt("plantID"));
    }
}
