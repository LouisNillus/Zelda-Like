﻿using System.Collections;
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

    public float hp = 1;
    public bool dialogueHasStarted = false;
    public bool reve = true;

    private Rigidbody2D rigidBody;

    Animator animator;
    DialogueManager dialogueManager;
    DialogueTrigger dialogueTrigger;
    Slider sliderHP;

    public GameObject tilemap;
    public GameObject dialogueManagerObject;
    public GameObject dialogueTriggerObject;
    public GameObject mySliderHP;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        sliderHP = mySliderHP.GetComponent<Slider>();
        tilemap = GameObject.FindGameObjectWithTag("Reve");
        dialogueManager = dialogueManagerObject.GetComponent<DialogueManager>();
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        nightmare = Input.GetAxis("GoToNightmare");
        dream = Input.GetAxis("GoToDream");

        sliderHP.value = hp;

        if(Input.GetKeyDown(KeyCode.Space) && dialogueHasStarted == false)
        {
            dialogueTrigger = dialogueTriggerObject.GetComponent<DialogueTrigger>();
            dialogueTrigger.TriggerDialogue();
            dialogueHasStarted = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && dialogueHasStarted == true)
        {
            dialogueManager.DisplayNextSentence();
        }
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(maxSpeed * moveX, maxSpeed * moveY);

        IsMoving();
        
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

    void GoToNightmare()
    {
        tilemap.GetComponent<TilemapRenderer>().sortingOrder = 0;
        reve = false;
        //SceneManager.LoadScene("Cauchemar");
    }
    

    void GoToDream()
    {
        tilemap.GetComponent<TilemapRenderer>().sortingOrder = 2;
        reve = true;
        //SceneManager.LoadScene("Reve");
    }
}
