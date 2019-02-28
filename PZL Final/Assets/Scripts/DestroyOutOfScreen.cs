using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfScreen : MonoBehaviour
{

	void Start ()
    {
		
	}

	void Update ()
    {
		
	}

    private void OnBecameInvisible() //Prend en comptes TOUTES les caméras, même celle de la scène Unity
    {
        Destroy(this.gameObject);
    }
}
