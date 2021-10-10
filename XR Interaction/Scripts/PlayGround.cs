using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGround : MonoBehaviour
{
    private float hVal;
    private float vVal;

    // Start is called before the first frame update
    void Start()
    {
        hVal = Input.GetAxis("Horizontal");
        vVal = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        print("Horizontal movement");
        if(vVal != 0)
        {
            print("Vertical movement");
        }
    }
}
