using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BAITAbility : MonoBehaviour
{

    public Transform myPlayer;
    public AIDestinationSetter myTarget;
    public GameObject myParticles;
    public CharacterController characterController;
    public AbilityManager abilityManager;

    // Booléens Bait
    public bool canBait = true;
    public float baitCooldownTime;
    public bool baitIsLaunched = false;
    private bool followingPlayer = true;

    // Start
    void Start ()
    {

    }
	
	// Update
	void Update ()
    {
        if(characterController.reve == true)
        {
            canBait = false;
        }
        else if(characterController.reve == false)
        {
            canBait = true;
        }


        if(followingPlayer == true)
        {
            this.gameObject.transform.position = myPlayer.transform.position;
        }
        else
        {
            return;
        }

        if (Input.GetKeyDown("joystick 1 button 1") && canBait == true && baitIsLaunched == false)
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
        baitIsLaunched = true;
        yield return new WaitForSeconds(baitCooldownTime);
        baitIsLaunched = false;
        canBait = true;
    }

    IEnumerator TimeBeforeDestroy()
    {
        yield return new WaitForSeconds(3);
        myParticles.SetActive(false);
        followingPlayer = true;
        myTarget.target = null;

    }

}
