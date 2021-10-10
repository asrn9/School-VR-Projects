using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;
using UnityEngine.AI;

public class MyControllerInput : MonoBehaviour
{
    [System.Serializable]
    public class Callback : UnityEvent<Ray, RaycastHit> { }
    [SerializeField]
    private XRNode xrNodeL = XRNode.LeftHand;
    private XRNode xrNodeR = XRNode.RightHand;
    private InputDeviceRole inputDevice;
    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device;

    public Transform leftHandAnchor = null;
    public Transform rightHandAnchor = null;
    public Transform centerEyeAnchor = null;
    public float maxRayDistance = 500;
    public LayerMask excludeLayers;

    public GameObject doorEnter;
    public GameObject doorExit;
  

    public GameObject XRRig;
    bool triggerValue;

    bool primaryButton;
    public Transform Fire;

    bool secondaryButton;
    public Transform camera;
    public Transform panel;

    //public GameObject target;

    void GetDevice()
    {
        //Add InputDevices here    
        InputDevices.GetDevicesAtXRNode(xrNodeL, devices);
        InputDevices.GetDevicesAtXRNode(xrNodeR, devices);
        device = devices.FirstOrDefault();
    }
    void OnEnable()
    {
        //Check if devices is enabled then enable it    
        if (!device.isValid)
        {
            GetDevice();
        }
    }

    //In the awake we will find the left and right hand controllers and assign them to anchors    
    private void Awake()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Transform>();

        if (leftHandAnchor == null)
        {
            //Debug.LogWarning("Assign LeftHandAnchor in the inspector!");
            GameObject left = GameObject.Find("LeftHand Controller");
            if (left != null)
            {
                leftHandAnchor = left.transform;
            }
        }
        if (rightHandAnchor == null)
        {
            //Debug.LogWarning("Assign RightHandAnchor in the inspector!");
            GameObject right = GameObject.Find("RightHand Controller");
            if (right != null)
            {
                rightHandAnchor = right.transform;
            }
        }
        if (centerEyeAnchor == null)
        {
            //Debug.LogWarning("Assign CenterEyeAnchor in the inspector!");
            GameObject center = GameObject.Find("CenterEyeAnchor");
        if (center != null)
        {
            centerEyeAnchor = center.transform;
        }
    }
}    //we can create a Pointer of type transform and assign the left or right to be active    
    Transform Pointer
    {
        get
        {
            if (rightHandAnchor == null)
            {
                return leftHandAnchor;
            }
            return rightHandAnchor;
        }
    }    // Start is called before the first frame update    

    void Start()
    {
    }
    // Update is called once per frame    
    void Update()
    {
        if (!device.isValid)//checking again to make sure device is assigned        
        {
            GetDevice();
        }

        if(device.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButton) && secondaryButton)
        {
            panel.position = new Vector3(camera.position.x, camera.position.y, camera.position.z + 0.5f);

            panel.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }

        Transform pointer = Pointer;
        if (pointer == null)
        {
            return;
        }
        Ray rayPointer = new Ray(pointer.position, pointer.forward);
        RaycastHit hit;
        NavMeshHit navHit;
        if (Physics.Raycast(rayPointer, out hit, maxRayDistance, ~excludeLayers))
        {
            //Debug.Log("In raycast if statement");
            if (NavMesh.SamplePosition(hit.point, out navHit, 1.0f, NavMesh.AllAreas))
            {
                if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
                {
                    XRRig.transform.position = navHit.position;
                }
            }
            Renderer rend;
            if (hit.transform.gameObject.tag == "EnterDoor")
            {
                //Debug.Log("Door Enterance hit");
                rend = hit.transform.gameObject.GetComponent<Renderer>();
                rend.material.SetColor("_Color", Color.green);
                if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
                {

                    XRRig.transform.position = new Vector3(-3.703f, 35.8f, 33.657f);
                    //pos
                }
                else
                {
                    rend = doorEnter.transform.gameObject.GetComponent<Renderer>();
                    rend.material.SetColor("_Color", Color.white);
                }
            }
            if (hit.transform.gameObject.tag == "ExitDoor")
            {
                //Debug.Log("Door Enterance hit");
                rend = hit.transform.gameObject.GetComponent<Renderer>();
                rend.material.SetColor("_Color", Color.green);
                if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
                {

                    XRRig.transform.position = new Vector3(-3.2f, 35.8f, 27.1f);
                    //pos
                }
                else
                {
                    rend = doorExit.transform.gameObject.GetComponent<Renderer>();
                    rend.material.SetColor("_Color", Color.white);
                }
            }

        }
            else
            {
            }
            if (hit.transform.gameObject.tag == "Fire")
            {
                //On Oculus the pimaryButton is the "A" button
                if (device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButton) && primaryButton)
                {
                    Instantiate(Fire, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                }
            }
        }
    }      