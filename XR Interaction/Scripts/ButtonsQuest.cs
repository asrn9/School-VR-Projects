using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonsQuest : MonoBehaviour
{
    public static ButtonsQuest bq;

    public TMP_Text questText;

    public Button swordButton;
    public Button shieldButton;
    public Button spearButton;

    public Button nextButton;

    private bool swordStart = false;
    private bool shieldStart = false;
    private bool spearStart = false;

    public bool swordComplete = false;
    public bool shieldComplete = false;
    public bool spearComplete = false;

    private int checkpoint = 0;

    public GameObject leftHand;
    public GameObject rightHand;

    public GameObject swordBox;
    public GameObject shieldBox;
    public GameObject spearBox;

    // Start is called before the first frame update
    void Start()
    {
        shieldBox.gameObject.SetActive(false);
        spearBox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSword()
    {
        Debug.Log("Starting Sword Quest");
        swordStart = true;
        questText.text = "Sword Quest:\nInfront of fire house";
        questText.fontSize = 4;

        nextButton.gameObject.SetActive(false);
        shieldButton.gameObject.SetActive(false);
        spearButton.gameObject.SetActive(false);
    }

    public void startShield()
    {
        Debug.Log("Starting Shield Quest");
        shieldStart = true;
        questText.text = "Shield Quest:\nDown the path";
        questText.fontSize = 4;

        swordButton.gameObject.SetActive(false);
        spearButton.gameObject.SetActive(false);
    }

    public void startSpear()
    {
        Debug.Log("Starting Spear Quest");
        spearStart = true;
        questText.text = "Spear Quest:\nNear the waters";
        questText.fontSize = 4;

        shieldButton.gameObject.SetActive(false);
        swordButton.gameObject.SetActive(false);
    }

    public void nextMission()
    {
        if (swordComplete == true && checkpoint == 0)
        {
            checkpoint = 1;
            shieldButton.gameObject.SetActive(true);
            shieldButton.interactable = false;
            shieldBox.gameObject.SetActive(true);
            startShield();
        }
        else if(shieldComplete == true && checkpoint == 1)
        {
            checkpoint = 2;
            spearButton.gameObject.SetActive(true);
            spearButton.interactable = false;
            spearBox.gameObject.SetActive(true);
            startSpear();
        }
        else if(spearComplete == true && checkpoint == 2)
        {
            checkpoint = 3;
            questText.text = "Quest Complete!";
            questText.fontSize = 4;
        }
    }

    public void swordDone()
    {
        Debug.Log("Finishing");
        swordComplete = true;
        nextButton.gameObject.SetActive(true);

        Debug.Log("Finished Sword Quest!");
    }
    public void shieldDone()
    {
        shieldComplete = true;
        nextButton.gameObject.SetActive(true);

        Debug.Log("Finished Shield Quest!");
    }
    public void spearDone()
    {
        spearComplete = true;
        nextButton.gameObject.SetActive(true);

        Debug.Log("Finished Spear Quest!");
    }
}
