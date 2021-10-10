using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    float speed = 1;
    public GameObject door;
    public GameObject door2;
    float timer;

    float movement2;

    public bool opened = false;
    private bool opened2 = false;

    float movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDoorControlls(); //this call will be checking for the tools
    }

    public void OpenDoor(GameObject door)
    {
        Debug.Log(movement);
        if (movement >= -3)
        {

            timer = Time.deltaTime;

            movement =  movement - speed * timer;

            door.transform.position = new Vector3(door.transform.position.x, movement,  door.transform.position.z);

            //use your timer to assign Time.deltaTime to
            //use your movement float to lower your door by taking the speed and times(*) it by the timer and subtract(-) it from your movement
            //assign the postion to the door with a vector 3 but for the x postion and the z you want to keep the existing values byt re-assigning them like door.transform.postion.x into the vector3 float position for x. 
            //For the y position you want to use movement float
        }
    }

    public void CheckDoorControlls(){

        //use this function to check for the conditions of your bool so when they are true you want to call the OpenDoor() function and send the parameter of the door you want to open

        if (opened)
        {
            Debug.Log("Opening Door 1");
            OpenDoor(door);
        }
        if (opened2)
        {
            OpenDoor(door2);
        }
    }

    public void OpenBoolDoor()
    {
        if (movement <= -3)
        {
            movement = 0;
        }

        opened = true;

     

        //use this method to set your bool to true and reset the movement float for the first door button

    }

    public void OpenBoolDoor2()
{
        if(movement <= -3)
        {
            movement = 0;
        }

        opened2 = true;

        //use this method to set your bool to true and reset the movement float for the Second door button
    }
}
