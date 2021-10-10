using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed;

    [SerializeField]
    private bool rotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            transform.Rotate(speed * Time.deltaTime, Space.World);
        }
    }

    public void StartRotation()
    {
        rotate = true;
    }

    public void StopRotation()
    {
        rotate = false;
    }
}
