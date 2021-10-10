using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonExecute : MonoBehaviour {

    //public Button startButton, stopButton;
    Button hitButton, currentButton;

    private bool on = false;
    private float timer = 5.0f;

    // Use this for initialization
    void Start()
    {
       // startButton = GameObject.Find("StartButton").GetComponent<Button>();
        //stopButton = GameObject.Find("StopButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update () {

        Transform camera = Camera.main.transform;
        Ray ray= new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        //GameObject hitObject;

        

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.transform.gameObject.tag =="Button")
            {

                hitButton = hit.transform.parent.gameObject.GetComponent<Button>();
                print("name = "+ hitButton.name);
                Debug.Log("Hitting button: " + hitButton.name);

            }

            if (currentButton != hitButton)
            {
                //unhighlight

                if (currentButton != null) {

                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                }


                //make changes
                currentButton = hitButton;

                if (currentButton != null) { 

                    currentButton.onClick.Invoke();
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                }
            }

        }

    }
}
