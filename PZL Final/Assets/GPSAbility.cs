using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GPSAbility : MonoBehaviour
{

    public GameObject myParticles;
    public Transform myPlayer;
    public CharacterController controller;

    public int i = 0;

    private AIDestinationSetter targetManager;

    // Booléens GPS
    private bool canBeLaunched = true;
    private bool isLaunching = false;

    public List<Transform> waypoints = new List<Transform>();


    // Start
    void Start()
    {
        targetManager = this.GetComponent<AIDestinationSetter>();
    }

    // Update
    void Update()
    {

        if (isLaunching == false)
        {
            this.gameObject.transform.position = myPlayer.transform.position;
        }
        else
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && canBeLaunched == true && controller.reve == true)
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
        canBeLaunched = false;
        yield return new WaitForSeconds(5);
        canBeLaunched = true;
    }


    IEnumerator TimeBeforeDestroy()
    {
        yield return new WaitForSeconds(3);
        targetManager.target = null;
        myParticles.SetActive(false);
        isLaunching = false;
    }




}
