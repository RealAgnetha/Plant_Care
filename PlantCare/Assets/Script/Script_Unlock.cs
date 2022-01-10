using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Unlock : MonoBehaviour
{
    public GameObject LockScreen01;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Script_Erfolge.erf1Code);
        if(Script_Erfolge.erf1Code != 0)
        {
            LockScreen01.SetActive(false);
        }
    }
}
