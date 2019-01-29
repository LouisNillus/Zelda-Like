using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondController : MonoBehaviour
{
    [SerializeField]
    float maxSpeed = 1.2f;
    [SerializeField]
    float jumpForce = 200f;
    [SerializeField]
    bool bGrounded;

    //Private
    Rigidbody2D rigidBody;
    bool bFacingRight = true;
    bool bKinematic = false;
    bool bDoubleJump = false;

    //To Manage ground
    public Transform checkGround;
    public float groundRadius = 0.2f;
    public LayerMask groundMask;


    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody.bodyType == RigidbodyType2D.Kinematic)
        {
            bKinematic = true;
        }


    }

    private void FixedUpdate()
    {
        bGrounded = Physics2D.OverlapCircle(checkGround.position, groundRadius, groundMask);

        //Reset the DoubleJump
        if(bGrounded)
        {
            bDoubleJump = false;
        }

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

        if ((moveX > 0 && !bFacingRight) || (moveX < 0 && bFacingRight))
        {
            FlipSprite();
        }
        //Debug.Log("moveX : " + moveX.ToString());
    }

    private void Update()
    {
        /*
        if(bGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }
        */

        //DoubleJump
        if ( (bGrounded || !bDoubleJump) && Input.GetKeyDown(KeyCode.Space) )
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));

            if(!bDoubleJump && !bGrounded)
            {
                bDoubleJump = true;
            }
        }
    }

    void FlipSprite()
    {
        bFacingRight = !bFacingRight;
        Vector3 spriteLocalScale = transform.localScale;
        spriteLocalScale.x *= -1;
        transform.localScale = spriteLocalScale;
    }
}
