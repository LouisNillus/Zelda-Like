using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCaisseY : MonoBehaviour
{

    public Transform positionJoueur;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            positionJoueur = collision.gameObject.GetComponent<Transform>();

            if (positionJoueur.transform.position.y < this.transform.parent.transform.position.y)
            {
                this.transform.parent.transform.position = new Vector2(this.transform.parent.transform.position.x, this.transform.parent.transform.position.y + 0.05f);
            }

            if (positionJoueur.transform.position.y > this.transform.parent.transform.position.y)
            {
                this.transform.parent.transform.position = new Vector2(this.transform.parent.transform.position.x, this.transform.parent.transform.position.y - 0.05f);
            }

        }
    }

}
