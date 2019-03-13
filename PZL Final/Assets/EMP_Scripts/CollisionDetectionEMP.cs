using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionEMP : MonoBehaviour
{
    [Range(0, 0.05f), SerializeField]
    private float movingSpeed = 0.02f;

    // Start
    void Start ()
    {

	}
	
	// Update
	void Update ()
    {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            //Objet kinématique sur rail vertical
            if (collision.gameObject.transform.position.y > this.transform.position.y && this.gameObject.tag == "VerticalMovingObject")
            {
                GetDown();
            }
            else if (collision.gameObject.transform.position.y < this.transform.position.y && this.gameObject.tag == "VerticalMovingObject")
            {
                GetUp();
            }

            //Objet kinématique sur rail horizontal
            if (collision.gameObject.transform.position.x > this.transform.position.x && this.gameObject.tag == "HorizontalMovingObject")
            {
                GetLeft();
            }
            else if (collision.gameObject.transform.position.x < this.transform.position.x && this.gameObject.tag == "HorizontalMovingObject")
            {
                GetRight();
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CancelInvoke();
        }
    }

    //Bouger vers le bas
    private void GetDown()
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - movingSpeed);
    }

    //Bouger vers le haut 
    private void GetUp()
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + movingSpeed);
    }

    //Bouger vers la gauche
    private void GetLeft()
    {
        this.transform.position = new Vector2(this.transform.position.x - movingSpeed, this.transform.position.y);
    }

    //Bouger vers la droite
    private void GetRight()
    {
        this.transform.position = new Vector2(this.transform.position.x + movingSpeed, this.transform.position.y);
    }

}
