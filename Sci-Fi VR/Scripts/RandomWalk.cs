using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{

    public int pos = 5;

    //Added this so the character walks around a designated origin
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepositionWithDelay());
    }

    IEnumerator RepositionWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(pos);

            SetRandomPosition();
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-4.0f, 4.0f);
        float z = Random.Range(-4.0f, 4.0f);

        //This will make character walk to a near by place relative to original place
        transform.position = new Vector3(target.transform.position.x + x, 0.0f ,target.transform.transform.position.z + z);
        //Debug.Log("Let's Go Here: " + transform.position);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
