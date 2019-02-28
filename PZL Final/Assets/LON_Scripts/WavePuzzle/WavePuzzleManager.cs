﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePuzzleManager : MonoBehaviour
{
    public Key1 key1;
    public Key2 key2;
    public Key3 key3;
    public Key4 key4;

    private int rotationSpeed = 10;
    private float angle = 0f;

    [SerializeField]
    private bool canLaunchWaves = false;
    private bool moveTarget = true;

    public bool wavePuzzleComplete = false;

    public Transform targetRotator;
    public Transform waveTarget;
    public SpriteRenderer pressX;
    public ParticleSystem waveParticles;
    public Transform waveParticlesTransform;

    void Update()
    {
        if (wavePuzzleComplete == true)
        {
            Debug.Log("YOU MADE IT");
        }

        Emitter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pressX.enabled = true;
            canLaunchWaves = true;

            InvokeRepeating("MoveWaveTarget", 0.01f, 0.01f);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pressX.enabled = false;
            canLaunchWaves = false;

            CancelInvoke();
        }
    }

    public void Emitter()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) && canLaunchWaves == true)
        {
            Vector2 rotationVector = new Vector2(waveTarget.position.x - waveParticlesTransform.position.x, waveTarget.position.y - waveParticlesTransform.position.y);
            float angleValue = Mathf.Atan2(rotationVector.normalized.y, rotationVector.normalized.x) * Mathf.Rad2Deg;

            ParticleSystem.ShapeModule wpshape = waveParticles.shape;
            wpshape.rotation = new Vector3(0, 0, angleValue);

            waveParticles.Emit(1);
        }
    }

    public void MoveWaveTarget()
    {

        Vector2 rotationVector = new Vector2(waveParticlesTransform.position.x - waveTarget.position.x, waveParticlesTransform.position.y - waveTarget.position.y);
        float angleValue = Mathf.Atan2(rotationVector.normalized.y, rotationVector.normalized.x) * Mathf.Rad2Deg;

        if(Input.GetKey("joystick 1 button 5"))
        {
            angle = angle - 1f;
        }
        else if (Input.GetKey("joystick 1 button 4"))
        {
            angle = angle + 1f;
        }

        targetRotator.localEulerAngles = new Vector3(0, 0, angle);

    }


    /*public void MoveWaveTargetAutomatic()
    {

        waveTarget.RotateAround(new Vector3(-1.441f, -9.750812f, 0), Vector3.forward, rotationSpeed * Time.deltaTime);

    }*/

    public void ResetPuzzle()
    {
        key1.key1Done = false;
        key2.key2Done = false;
        key3.key3Done = false;
        key4.key4Done = false;
    }

}