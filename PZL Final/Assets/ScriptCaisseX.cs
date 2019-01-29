using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCaisseX : MonoBehaviour
{

    public Transform positionJoueur;
 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            positionJoueur = collision.gameObject.GetComponent<Transform>();

            if(positionJoueur.transform.position.x < this.transform.parent.transform.position.x)
            {
                this.transform.parent.transform.position = new Vector2(this.transform.parent.transform.position.x + 0.05f, this.transform.parent.transform.position.y);
            }

            if (positionJoueur.transform.position.x > this.transform.parent.transform.position.x)
            {
                this.transform.parent.transform.position = new Vector2(this.transform.parent.transform.position.x - 0.05f, this.transform.parent.transform.position.y);
            }

        }
    }

}
