using UnityEngine;
using System.Collections;

public class Ennemy : MonoBehaviour
{
    public  Rigidbody2D _rb       ;
    public  GameObject  projectile;
    private Transform   target    ;

    public  float speed = 4f           ;
    private float backwardDistance = 8f; //A partir de cette distance, l'ennemi recule
    private float timeForShoot = 2f  ;

    public  int   playerDamage; //Dégâts qu'il inflige au joueur

    public  bool  isReve; //Bool pour savoir si c'est le rêve ou le cauchemar.

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        isReve = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().reve;

        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        /******************************************************************************************
        * On Check si on est dans le rêve ou le cauchemar pour savoir quel comportement adopter.  *
        ******************************************************************************************/
        if(isReve == true)
        {
            Reve();
        }
        else
        {
            Cauchemar();
        }
        //TEST
    }

    void Reve()
    {
        //Enemy follow you
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    
    void Cauchemar()
    {
       //Enemy move backward and throw projectile
       if(Vector2.Distance(transform.position, target.position) < backwardDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }

        if (timeForShoot <= 0)
        {
            Debug.Log("tfs " + timeForShoot);
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeForShoot = 2f;
        }
        else
        {
            Debug.Log("tfs " + timeForShoot);
            timeForShoot -= Time.deltaTime;
        }
    }
}