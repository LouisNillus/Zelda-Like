using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BAITAbility : MonoBehaviour
{

    public Transform myPlayer;
    public AIDestinationSetter myTarget;
    public GameObject myParticles;

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

        if (Input.GetKeyDown(KeyCode.E) && canBait == true)
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
        canBait = false;
        yield return new WaitForSeconds(8);
        canBait = true;
    }

    IEnumerator TimeBeforeDestroy()
    {
        yield return new WaitForSeconds(3);
        myParticles.SetActive(false);
        myTarget.target = null;
        followingPlayer = true;
    }

}
