using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages : MonoBehaviour
{

    public GameObject myPlayer;
    CharacterController myControllerScript;

    [Range(0.01f,1), SerializeField]
    private float inflictedDamages;

    void Start()
    {
        myControllerScript = myPlayer.GetComponent<CharacterController>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            InvokeRepeating("SetLifeLower", 0.5f, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CancelInvoke();
        }
    }


    public void SetLifeLower()
    {
        myControllerScript.hp = myControllerScript.hp - inflictedDamages;
    }


}
