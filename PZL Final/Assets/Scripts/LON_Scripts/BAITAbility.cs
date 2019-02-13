using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BAITAbility : MonoBehaviour
{

    public Transform myPlayer;
    public AIDestinationSetter myTarget;
    public GameObject myParticles;
    public CharacterController controller;

    // Booléens Bait
    private bool canBait = true;
    private bool followingPlayer = true;

    // Start
    void Start ()
    {

    }
	
	// Update
	void Update ()
    {
        if(followingPlayer == true)
        {
            this.gameObject.transform.position = myPlayer.transform.position;
        }
        else
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && canBait == true && controller.reve == false)
        {
            LaunchBait();
        }
    }



    public void LaunchBait()
    {
        followingPlayer = false;
        myParticles.SetActive(true);
        StartCoroutine(CoolDownBait());
        StartCoroutine(TimeBeforeDestroy());
    }


    IEnumerator CoolDownBait()
    {
        Debug.Log("1");
        canBait = false;
        yield return new WaitForSeconds(8);
        canBait = true;
    }

    IEnumerator TimeBeforeDestroy()
    {
        Debug.Log("2");
        yield return new WaitForSeconds(3);
        myParticles.SetActive(false);
        myTarget.target = null;
        followingPlayer = true;
    }

}
