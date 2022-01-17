using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manageSmileyPopup : MonoBehaviour
{
    public GameObject Popup;

    public void openHilfedialog(){
        Popup.SetActive(false);
        SceneManager.LoadScene("Hilfedialog");
    }

    public void closeSmileyPopup(){
        Popup.SetActive(false);
    }

    public void openSmileyPopup(){
        Popup.SetActive(true);
    }
}
