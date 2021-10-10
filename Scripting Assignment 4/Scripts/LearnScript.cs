using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LearnScript : MonoBehaviour
{
    //0 1 2 3 4 5 6
    int[] myArray = {7, 4, 7, 3, 5, 96, 4};
    bool myBool = true;
    int myWhileInt = 0;
    char[] myCharArray;
    private List<GameObject> Cubes = new List<GameObject>();
    public GameObject prefab;
    Vector3 rnd;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new Vector3(  Random.Range(-20, 20),
                            Random.Range(-20, 20),
                            Random.Range(-20, 20));
    }

    // Update is called once per frame
    void Update()
    {
        //while (mybool)
        //{
        //    myarray[mywhileint] = 1;

        //    debug.log("current index of myarray[i]: " + mywhileint +
        //            "\ncurrent value of myarray: " + myarray[mywhileint]);

        //    ++mywhileint;

        //    debug.log("current bool value: " + mybool);

        //    if (mywhileint == 7)
        //    {
        //        mybool = false;
        //    }
        //}

        myWhileInt = 0;

        do
        {

            myArray[myWhileInt] = 1;
            ++myWhileInt;
            Debug.Log("I am here");
            if (myWhileInt >= 6)
            {
                myBool = false;
            }

        } while (myBool);


        for(int i = 0; i < 7; i++)
        {
            Debug.Log("i = " + i);
            myArray[i] = 1;

            Cubes.Remove(Cubes[i].gameObject);

            //Destroy() destroies it in the scene, once
            //  it's gone, it's gone
            Destroy(prefab);

            //SetActive() can make it look like it was destroied in the scene, but 
            //  it's still there.
            prefab.SetActive(false);
        }

        foreach(char x in myCharArray)
        {
            //Debug.Log("Current value of myCharArray[" + x + "]: " + myCharArray[x]);
            //myCharArray[x] = 'a';
            //Debug.Log("New value of myCharArray[" + x + "]: " + myCharArray[x]);
        }


    }

    private void myFunction()
    {
        Cubes.Add((GameObject)Instantiate(prefab, rnd, Quaternion.identity));
    }
}
