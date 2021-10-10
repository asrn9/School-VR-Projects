using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFinders : MonoBehaviour 
{
    void Start()
    {
        Debug.Log("Starting QuestFinder script");
    }

    public void onCollisonEnter(Collision other)
    {
        Debug.Log("On trigger activated");

        if(other.gameObject.tag == "Sword")
        {
            
            ButtonsQuest.bq.swordDone();
            System.Console.WriteLine("Worked");
        }
        else if(other.gameObject.tag == "Shield")
        {
            ButtonsQuest.bq.shieldDone();
        }
        else if(other.gameObject.tag == "Spear")
        {
            ButtonsQuest.bq.spearDone();
            
        }
    }
}
