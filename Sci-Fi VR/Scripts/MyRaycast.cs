using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MyRaycast : MonoBehaviour
{
    private Transform camera;
    public float maxRayDistance = 500.0f;
    public LayerMask excludeLayers;
    public Button hitButton;
    public Button currentButton;
    private float timer;
    public GameObject doorOpening;
    public GameObject doorOpening2;
    public GameObject nextMission;
    public Transform xrRig;
    public TextMeshProUGUI sprayerTimer;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(camera.position, camera.transform.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxRayDistance, ~excludeLayers))
        {
            if(hit.collider.gameObject.gameObject == doorOpening)
            {
                Debug.Log("If dooropen was called");
                xrRig.transform.position = new Vector3(16.84f, xrRig.transform.position.y, -18.011f);
            }
            if(hit.collider.gameObject.gameObject == doorOpening2)
            {
                Debug.Log("If dooropen2 was called");
                xrRig.transform.position = new Vector3(17.19f, xrRig.transform.position.y, -49.09f);

            }
            if (hit.collider.gameObject.gameObject == nextMission)
            {
                Debug.Log("If nextMission was called");
                xrRig.transform.position = new Vector3(15.78f, xrRig.transform.position.y, -5.8f);
                xrRig.transform.localEulerAngles = new Vector3(xrRig.transform.rotation.x, -164.64f, xrRig.transform.rotation.z);

            }
            if (hit.transform.gameObject.tag == "Button")
            {

                timer += Time.deltaTime;

                string timetext = timer.ToString();
                

                //create a timer using Time.delta
                hitButton = hit.transform.parent.gameObject.GetComponent<Button>();

                if (currentButton != null)
                {
                    //use the OnPointerExit(new PointerEventData(EventSystem.current)) to turn off the highlights

                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));

                }

                currentButton = hitButton; // this asigns the Button that you are currently using

                if (currentButton != null)
                {
                    //use the .OnPointerEnter(new PointerEventData(EventSystem.current))  for the highlight when hovering
                    sprayerTimer.text = timetext;
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                }
                if (timer >= 3)
                {
                    // use onClick.Invoke(); to activate your button

                    sprayerTimer.text = "Button Activated";

                    currentButton.onClick.Invoke();
                }
            }
            else
            {
                timer = 0;
                sprayerTimer.text = "";
            }
        }
    }
}
