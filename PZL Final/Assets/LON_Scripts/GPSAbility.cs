using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GPSAbility : MonoBehaviour
{

    public GameObject myParticles;
    public Transform myPlayer;
    public CharacterController characterController;

    public int i = 0;
    public float gpsCooldownTime;

    private AIDestinationSetter targetManager;

    // Booléens GPS
    public bool canGPS = true;
    public bool isLaunching = false;

    public List<Transform> waypoints = new List<Transform>();


	// Start
	void Start ()
    {
        targetManager = this.GetComponent<AIDestinationSetter>();
	}
	
	// Update
	void Update ()
    {
        if (characterController.reve == true)
        {
            canGPS = true;
        }
        else
        {
            canGPS = false;
        }


        if (isLaunching == false)
        {
            this.gameObject.transform.position = myPlayer.transform.position;
        }
        else
        {
            return;
        }


        if(Input.GetKeyDown("joystick 1 button 1") && canGPS == true)
        {
            isLaunching = true;
            LaunchGPS();
        }

    }


    public void LaunchGPS()
    {
        myParticles.SetActive(true);
        targetManager.target = waypoints[i];
        StartCoroutine(CoolDownGPS());
        StartCoroutine(TimeBeforeDestroy());

    }

    IEnumerator CoolDownGPS()
    {
        canGPS = false;
        yield return new WaitForSeconds(gpsCooldownTime);
        canGPS = true;
    }


    IEnumerator TimeBeforeDestroy()
    {
        yield return new WaitForSeconds(3);
        targetManager.target = null;
        myParticles.SetActive(false);
        isLaunching = false;
    }




}
