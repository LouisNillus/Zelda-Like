using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2 : MonoBehaviour
{

    public bool key2Done = false;

    public Key1 key1;
    public Key3 key3;
    public Key4 key4;

    public WavePuzzleManager wavePuzzleManager;


    // Start
    void Start()
    {

    }

    // Update
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        if (key1.key1Done == true && key2Done == false && key3.key3Done == false && key4.key4Done == false)
        {
            key2Done = true;
        }
        else
        {
            wavePuzzleManager.ResetPuzzle();
        }
    }


}
