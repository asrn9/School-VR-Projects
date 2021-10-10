using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment : MonoBehaviour
{
    public GameObject Cube;
    private int i = 0;
    private float origScaleX;
    //public Vector3 currentScale;
    List<GameObject> cubeList = new List<GameObject>();
    List<GameObject> deleteList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        origScaleX = Cube.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("i value is: " + i);

        this.Cube = Instantiate(Cube);

        this.Cube.name = "Cube " + i;

        Debug.Log("New Cube of name: " + this.Cube.name);

        Color color = new Color(Random.value, Random.value, Random.value, 1.0f);
        this.Cube.GetComponent<Renderer>().material.color = color;

        this.Cube.transform.localPosition = new Vector3(
            (Cube.transform.localPosition.x) + Random.Range(-1.0f, 1.0f),
            (Cube.transform.localPosition.y) + Random.Range(-1.0f, 1.0f),
            (Cube.transform.localPosition.z) + Random.Range(-1.0f, 1.0f));

        cubeList.Add(this.Cube);

        foreach (GameObject Cube in cubeList)
        {
            if (Cube.transform.localScale.x < (0.1f))
            {
                deleteList.Add(Cube);
            }
            else
            {
                Cube.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            }
        }

        foreach (GameObject Cube in deleteList)
        {
            Destroy(Cube);
        }

    }
}
