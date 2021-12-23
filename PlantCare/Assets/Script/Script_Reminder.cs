using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Reminder : MonoBehaviour
{
    public GameObject panel;
    public GameObject reminderPanel;

    private bool isActive1 = false;

    public void markReminder()
    {
        //Marks event on day (should only mark if there is text in reminderPanel)
        if (isActive1)
        {
            panel.active = false;
            isActive1 = !isActive1;
        }
        else
        {
            panel.active = true;
            isActive1 = !isActive1;
        }

        //opens reminder window
        if (reminderPanel != null)
        {
            Animator animator = reminderPanel.GetComponent<Animator>();
            if(animator != null)
            { 
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }      
        }
    }
}
