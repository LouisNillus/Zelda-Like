using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key3 : MonoBehaviour
{

    public bool key3Done = false;

    public Key1 key1;
    public Key2 key2;
    public Key4 key4;

    public WavePuzzleManager wavePuzzleManager;

    public List<Transform> Key3Bounds = new List<Transform>();

    // Start
    void Start()
    {

    }

    // Update
    void Update()
    {
        //BoundLeft
        if (this.transform.position.x < Key3Bounds[0].position.x)
        {
            this.transform.position = new Vector2(Key3Bounds[0].position.x, this.transform.position.y);
        }

        //BoundRight
        if (this.transform.position.x > Key3Bounds[1].position.x)
        {
            this.transform.position = new Vector2(Key3Bounds[1].position.x, this.transform.position.y);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (key1.key1Done == true && key2.key2Done == true && key3Done == false && key4.key4Done == false)
        {
            key3Done = true;
        }
        else
        {
            wavePuzzleManager.ResetPuzzle();
        }
    }


}