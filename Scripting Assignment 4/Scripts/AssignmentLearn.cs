using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentLearn : MonoBehaviour
{
    private List<GameObject> cubeList = new List<GameObject>();
    public GameObject prefab;
    //Vector3 rndPos;
    private Vector3 scaleFactor;
    private Vector3 origin;
    private Vector3 direction;
    private float[] ops;

    // Start is called before the first frame update
    void Start()
    {
        //rndPos = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        scaleFactor = new Vector3(0.1f, 0.1f, 0.1f);
        origin = new Vector3(-0.9f, 0.0f, 0.1f);
        direction = new Vector3(0.1f, 0.1f, 0.0f);
        ops = new float[2];
        ops[0] = 1.0f;
        ops[1] = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(origin.x < -1.0f)
        {
            origin.x = -1.0f;
            direction.x *= ops[Random.Range(0, 2)];
        }
        if(origin.x > 1.0f)
        {
            origin.x = 1.0f;
            direction.x *= ops[Random.Range(0, 2)];
        }

        if (origin.y < -1.0f)
        {
            origin.y = -1.0f;
            direction.y *= ops[Random.Range(0, 2)];
        }
        if (origin.y > 1.0f)
        {
            origin.y = 1.0f;
            direction.y *= ops[Random.Range(0, 2)];
        }

        for (int i = 0; i < cubeList.Count; i++)
        {
            cubeList[i].transform.localScale -= scaleFactor;
            if(cubeList[i].transform.localScale.x <= 0.1f)
            {
                continue;
            }
            if(i != 0)
            {
                RemoveCube(i);
            }
            else
            {
                setRandom(cubeList[i]);
            }
        }

        origin += direction;
        AddCube();
    }

    private void AddCube()
    {
        Debug.Log("Add Cube was called");
        //cubeList.Add((GameObject)Instantiate(prefab));
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        setRandom(newCube);

        cubeList.Add(newCube);

        Debug.Log("cubeList.Count equal: " +cubeList.Count);

        for (int i = 0; i < cubeList.Count; i++)
        {
            Debug.Log("Cube " + i);
            cubeList[i].name = "Cube " + i;
        }

    }

    private void setRandom(GameObject cube)
    {
        //Color color = new Color(Random.value, Random.value, Random.value, 1.0f);

        //cube.GetComponent<Renderer>().material.color = color;

        cube.transform.localScale = new Vector3(Random.Range(0.8f, 1.0f), Random.Range(0.8f, 1.0f), Random.Range(0.8f, 1.0f));

        cube.transform.localPosition = new Vector3( Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));

        Renderer rend = cube.GetComponent<Renderer>();
        rend.material.SetColor("_Color", Random.ColorHSV());

        Debug.Log("Random was Set");
    }

    private void RemoveCube(int index)
    {
        GameObject deadCube = cubeList[index];

        Debug.Log("Destroying: " + deadCube.name);

        Destroy(deadCube);

        cubeList.Remove(cubeList[index]);
    }
}
