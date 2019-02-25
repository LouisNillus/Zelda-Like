using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float maxSpeed = 2f;

    private float moveX = 0f;
    private float moveY = 0f;
    private float nightmare = 0f;
    private float dream = 0f;

    public int hp = 3;
    public int damage = 1;
    public bool dialogueHasStarted = false;
    public bool reve = true;

    public int pushPower = 2;
    public int weight = 6;

    private Rigidbody2D rigidBody;

    Animator animator;
    DialogueManager dialogueManager;
    DialogueTrigger dialogueTrigger;
    Slider sliderHP;

    public GameObject tilemap;
    public GameObject dialogueManagerObject;
    public GameObject dialogueTriggerObject;
    public GameObject mySliderHP;

    private Collider2D[] hitResult = new Collider2D[10];

    public GameObject seeAbility;
    public ParticleSystem notSeeAbility;

    public GameObject[] cauchemarObjects;
    public GameObject[] reveObjects;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        sliderHP = mySliderHP.GetComponent<Slider>();
        tilemap = GameObject.FindGameObjectWithTag("Reve");
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        nightmare = Input.GetAxis("GoToNightmare");
        dream = Input.GetAxis("GoToDream");

        //sliderHP.value = hp;

        if(Input.GetKeyDown(KeyCode.Joystick1Button0) && dialogueHasStarted == false)
        {
            dialogueTrigger = dialogueTriggerObject.GetComponent<DialogueTrigger>();
            dialogueTrigger.TriggerDialogue();
            dialogueHasStarted = true;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button0) && dialogueHasStarted == true)
        {
            dialogueManager = dialogueManagerObject.GetComponent<DialogueManager>();
            dialogueManager.DisplayNextSentence();
        }
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(maxSpeed * moveX, maxSpeed * moveY);

        IsMoving();
        IsAttacking();
        Ability1();
        isDead(hp);
        
        if(nightmare != 0)
        {
            GoToNightmare();
        }
        else if (dream != 0)
        {
            GoToDream();
        }
    }

    void IsMoving()
    { 
        if ((moveX > 0 || moveX < 0) || (moveY > 0 || moveY < 0))
        {
            animator.SetFloat("moveX", moveX);
            animator.SetFloat("moveY", moveY);

            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void IsAttacking()
    {
        if (Input.GetKeyDown("joystick 1 button 0") || Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("isAttacking");
            int nbHitObjects = Physics2D.OverlapCircleNonAlloc(transform.position , 1.0f, hitResult);

            foreach (Collider2D hitObject in hitResult)
            {
                Debug.Log(hitObject);
                if (hitObject.gameObject.tag == "Enemy")
                {
                    Debug.Log(hitObject + " > Life : " + hitObject.gameObject.GetComponent<Ennemy>().hpEnemy);
                    hitObject.gameObject.GetComponent<Ennemy>().hpEnemy = hitObject.gameObject.GetComponent<Ennemy>().hpEnemy - damage;
                }
            }
        }
    }


    void GoToNightmare()
    {
        tilemap.GetComponent<TilemapRenderer>().sortingOrder = 0;
        reve = false;

        reveObjects = GameObject.FindGameObjectsWithTag("CeQuiApparaitEnReve");
        cauchemarObjects = GameObject.FindGameObjectsWithTag("CeQuiApparaitEnCauchemar");

        foreach (GameObject reveObject in reveObjects)
        {
            if (reveObject.GetComponent<SpriteRenderer>() != null)
            {
                reveObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                reveObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }

        foreach (GameObject cauchemarObject in cauchemarObjects)
        {
            if (cauchemarObject.GetComponent<SpriteRenderer>() != null)
            {
                cauchemarObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                cauchemarObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
    }
    
    void GoToDream()
    {
        tilemap.GetComponent<TilemapRenderer>().sortingOrder = 2;
        reve = true;

        reveObjects = GameObject.FindGameObjectsWithTag("CeQuiApparaitEnReve");
        cauchemarObjects = GameObject.FindGameObjectsWithTag("CeQuiApparaitEnCauchemar");

        foreach (GameObject cauchemarObject in cauchemarObjects)
        {
            if (cauchemarObject.GetComponent<SpriteRenderer>() != null)
            {
                cauchemarObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                cauchemarObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }

        foreach (GameObject reveObject in reveObjects)
        {
            if (reveObject.GetComponent<SpriteRenderer>() != null)
            {
                reveObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                reveObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
    }

    void isDead(int hp)
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Ability1()
    {
        if(Input.GetKeyDown("joystick 1 button 1") && !reve)
        {
            Instantiate(seeAbility, transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown("joystick 1 button 1") && reve)
        {
           Instantiate(notSeeAbility, transform.position, Quaternion.identity);  
        }
    }
}
