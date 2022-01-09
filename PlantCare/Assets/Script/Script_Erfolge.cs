using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Erfolge : MonoBehaviour
{
    //General Variables
    public GameObject erfNotif;
    public bool erfActive = false;
    public GameObject erfBild;
    public GameObject erfTitel;
    public GameObject erfBeschr;

    //Erster Erfolg Spezifisch
    
    public static int erf1Count;
    public int erf1Trigger = 1;
    public int erf1Code;

    // Update is called once per frame
    void Update()
    {
        erf1Code = PlayerPrefs.GetInt("Erf1");
        if(erf1Count == erf1Trigger && erf1Code != 12345)
        {
            StartCoroutine(Trigger01Erf());
        }
    }

    IEnumerator Trigger01Erf()
    {
        erfActive = true;
        erf1Code = 12345;
        PlayerPrefs.SetInt("Erf1", erf1Code);
        erfBild.SetActive(true);
        erfTitel.GetComponent<TextMesh>().text = "TEST!";
        erfBeschr.GetComponent<TextMesh>().text = "This is a Test message";
        erfNotif.SetActive(true);
        yield return new WaitForSeconds(5);

        //Resetting UI
        erfNotif.SetActive(false);
        erfBild.SetActive(false);
        erfTitel.GetComponent<TextMesh>().text = "";
        erfBeschr.GetComponent<TextMesh>().text = "";
        erfActive = false;
    }
}
