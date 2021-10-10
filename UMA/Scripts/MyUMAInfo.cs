using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

public class MyUMAInfo : MonoBehaviour
{
    public DynamicCharacterAvatar myAvatar;

    private Dictionary<string, DnaSetter> dna;
    public float size = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            myAvatar.SetSlot("Chest", "MaleHoodie_Recipe");
            myAvatar.BuildCharacter();

        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            myAvatar.ClearSlot("Chest");
            myAvatar.BuildCharacter();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        myAvatar.SetSlot("Chest", "MaleHoodie_Recipe");
        myAvatar.BuildCharacter();
    }

    public void PlusSize()
    {
        if(size >= 1.0f)
        {
            size = 1.0f;
        }
        else
        {
            size += 0.1f;
        }

        if(dna == null)
        {
            dna = myAvatar.GetDNA();

            dna["headSize"].Set(size);
            myAvatar.BuildCharacter();
        }
        else
        {
            dna["headSize"].Set(size);
            myAvatar.BuildCharacter();
        }
    }

    public void MinusSize()
    {
        if(size <= 0.0f)
        {
            size = 0.0f;
        }
        else
        {
            size -= 0.1f;
        }

        if (dna == null)
        {
            dna = myAvatar.GetDNA();

            dna["headSize"].Set(size);
            myAvatar.BuildCharacter();
        }
        else
        {
            dna["headSize"].Set(size);
            myAvatar.BuildCharacter();
        }
    }
}
