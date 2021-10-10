using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillTarget : MonoBehaviour
{
    public GameObject target;
    public float timeToSelect = 3.0f;
    public ParticleSystem hitEffect;
    public GameObject killEffect;

    private float countDown;

    private int killScore = 0;

    public GameObject enemyText;
    public GameObject targetText;

    public Transform infoBubble;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI missionText;

    public GameObject nextMission;

    // Start is called before the first frame update
    void Start()
    {
        //camera = Camera.main.transform;

        hitEffect.Pause();
        countDown = timeToSelect;

        targetText.SetActive(false);
        enemyText.SetActive(true);

        killEffect.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        Transform camera = Camera.main.transform;

        Ray ray = new Ray(camera.position, camera.transform.rotation * Vector3.forward);

        RaycastHit hit;

        infoBubble.transform.LookAt(infoBubble.position - Camera.main.transform.position);
        infoBubble.transform.rotation = Quaternion.LookRotation((infoBubble.position - Camera.main.transform.position));

        nextMission.transform.LookAt(infoBubble.position - Camera.main.transform.position);
        nextMission.transform.rotation = Quaternion.LookRotation((infoBubble.position - Camera.main.transform.position));

        scoreText.text = "Score: " + killScore;

        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target))
        {
            targetText.SetActive(true);
            enemyText.SetActive(false);

            if (countDown < 0.0f)
            {
                killScore++;

                missionText.text = "Activate Hose";

                nextMission.SetActive(true);

                countDown = timeToSelect;

                //kill target. instantiate here
                killEffect.SetActive(true);
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                target.SetActive(false);
                hitEffect.Stop();

                //Respawn target at a nearby location of earlier death so player can find it easy
                Vector3 randomMix = new Vector3(target.transform.position.x + Random.Range(-2.0f, 2.0f), target.transform.position.y, target.transform.position.z + Random.Range(-2.0f, 2.0f));
                target.transform.position = randomMix;

                killEffect.SetActive(false);
                target.SetActive(true);


            }
            else
            {
                //decrement countdown with time.deltatime, enable hiteffects and place it at hit.point
                countDown -= Time.deltaTime;

                hitEffect.transform.position = hit.point;
                hitEffect.gameObject.SetActive(true);
                hitEffect.Play();
               


            }
        }
        else
        {
            //Reset countdown disable hiteffect
            countDown = timeToSelect;

            hitEffect.Stop();
            hitEffect.gameObject.SetActive(false);

            targetText.SetActive(false);
            enemyText.SetActive(true);
        }
           
    }
}
