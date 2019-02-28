using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxSpawnBackground : MonoBehaviour
{
    public GameObject paralaxBackground;
    public GameObject paralaxStar;
    public GameObject paralaxDust;
    public GameObject paralaxNebula;

    private int counter = 0;
    private int random = 0;
    private Vector3 randomPosition;

	void Start ()
    {
		
	}

	void FixedUpdate ()
    {
        //Spawn Background
        if (counter == 0 || counter >= 4000)
        {
            randomPosition.x = -10;
            randomPosition.y = 0;
            randomPosition.z = 0;

            GameObject instance = (GameObject)GameObject.Instantiate(paralaxBackground, randomPosition, paralaxBackground.transform.rotation);
            instance.transform.parent = GameObject.FindGameObjectWithTag("ParalaxBackground").transform;
            counter = 0;
        }

        //Spawn Nebula
        if (counter == 400 || counter == 2400)
        {
            random = Mathf.RoundToInt(Random.Range(1, 1.99f));
            randomPosition.x = -5.4f;
            randomPosition.y = Random.Range(-6, 6);
            randomPosition.z = 0;

            switch (random)
            {
                case(1):
                    GameObject instance1 = (GameObject)GameObject.Instantiate(paralaxNebula, randomPosition, paralaxNebula.transform.rotation);
                    instance1.transform.parent = GameObject.FindGameObjectWithTag("ParalaxBackground").transform;
                    break;

            }
        }

        //Spawn Dust
        if (counter == 500 || counter == 1500 || counter == 2500 || counter == 3500)
        {
            random = Mathf.RoundToInt(Random.Range(1, 1.99f));
            randomPosition.x = -4.7f;
            randomPosition.y = Random.Range(-6, 6);
            randomPosition.z = 0;

            switch (random)
            {
                case (1):
                    GameObject instance1 = (GameObject)GameObject.Instantiate(paralaxDust, randomPosition, paralaxDust.transform.rotation);
                    instance1.transform.parent = GameObject.FindGameObjectWithTag("ParalaxBackground").transform;
                    break;

            }
        }

        //Spawn Stars
        if (counter == 1 || counter == 750 || counter == 2500 || counter == 3000 || counter == 3750)
        {
            random = Mathf.RoundToInt(Random.Range(1, 1.99f));
            randomPosition.x = -3.3f;
            randomPosition.y = Random.Range(-6, 6);
            randomPosition.z = 0;

            switch (random)
            {
                case (1):
                    GameObject instance1 = (GameObject)GameObject.Instantiate(paralaxStar, randomPosition, paralaxStar.transform.rotation);
                    instance1.transform.parent = GameObject.FindGameObjectWithTag("ParalaxBackground").transform;
                    break;

            }
        }
        counter += 1;
	}
}
