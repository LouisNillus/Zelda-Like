using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnParticleCollisionPlay : MonoBehaviour
{
    [SerializeField]
    private bool playParticleSystem = false;


	// Start
	void Start ()
    {
	    	


	}
	
	// Update
	void Update ()
    {
		


	}


    private void OnParticleCollision(GameObject other)
    {
        if(playParticleSystem == true)
        {
            ParticleSystem myParticleSystem = GetComponent<ParticleSystem>();
            myParticleSystem.Emit(1);
        }

    }
}
