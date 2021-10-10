using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositioner : MonoBehaviour
{

    public GameObject rectileCursor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;

        Ray ray = new Ray(camera.position, camera.transform.rotation * Vector3.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)){

            //Debug.Log("New position for cursor's Z: " + hit.distance);

            rectileCursor.transform.localPosition = new Vector3(0, 0, hit.distance);
        }
    }
}
