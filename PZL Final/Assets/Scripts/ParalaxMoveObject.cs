using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxMoveObject : MonoBehaviour
{
    [SerializeField] float speedX = 1f;

	void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speedX;
	}
	

	void Update ()
    {
		
	}
}
