using UnityEngine;
using System.Collections;

public class LookMoveTo : MonoBehaviour {

    public GameObject[] ground;

	// Use this for initialization
	void Start () {
        //Debug.Log("\nCAMERA LOCATION 1: " + Camera.main.transform.position.ToString("F2"));
    }
	
	// Update is called once per frame
	void Update () {

        Transform camera = Camera.main.transform;

        //Debug.Log("\nCAMERA LOCATION: " + Camera.main.transform.position.ToString("F2"));

        Ray ray;
        // RaycastHit hit;
        RaycastHit[] hits; 
        GameObject hitObject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward*100.0f, Color.red, 1, true);

        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        hits = Physics.RaycastAll(ray);
        for (int i =0; i<hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;

            for (int j = 0; j <= ground.Length; j++)
            {
                if (hitObject == ground[j])
                {
                    //Debug.Log("Hit (x,y,z): " + hit.point.ToString("F2"));
                    transform.position = hit.point;
                }
            }
        }

        // extra challenge - Layer mask, see
        //http://stackoverflow.com/questions/24563085/raycast-but-ignore-yourself

        // only hit ground
        //if (Physics .Raycast(ray, out hit))
        //{
        //    hitObject = hit.collider.gameObject;

        //    if (hitObject == ground)
        //    {
        //        Debug.Log("Hit (x,y,z): " + hit.point.ToString("F2"));
        //        transform.position = hit.point;
        //    }
        //}

    }
}
