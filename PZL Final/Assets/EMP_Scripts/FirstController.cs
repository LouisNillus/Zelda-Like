 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour
{
    [SerializeField]
    float maxSpeed = 1.2f;

    //Private
    Rigidbody2D rigidBody;
    bool bFacingRight = true;
    bool bKinematic = false;


	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody.bodyType == RigidbodyType2D.Kinematic)
        {
            bKinematic = true;
        }

 
	}

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (bKinematic)
        {
            rigidBody.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);
        }
        else
        {
            rigidBody.velocity = new Vector2(moveX * maxSpeed, rigidBody.velocity.y);
        }

        if((moveX > 0 && !bFacingRight) || (moveX < 0 && bFacingRight) )
        {
            FlipSprite();
        }
        //Debug.Log("moveX : " + moveX.ToString());
    }

    void FlipSprite()
    {
        bFacingRight = !bFacingRight;
        Vector3 spriteLocalScale = transform.localScale;
        spriteLocalScale.x *= -1;
        transform.localScale = spriteLocalScale;
    }
}
