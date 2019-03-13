using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{

    public bool key1Done = false;

    public Key2 key2;
    public Key3 key3;
    public Key4 key4;

    public WavePuzzleManager wavePuzzleManager;


	// Start
	void Start ()
    {
		
	}
	
	// Update
	void Update ()
    {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("ouais!");

        if (key1Done == false && key2.key2Done == false && key3.key3Done == false && key4.key4Done == false)
        {
            key1Done = true;
        }
        else
        {
            wavePuzzleManager.ResetPuzzle();
        }
    }

}
