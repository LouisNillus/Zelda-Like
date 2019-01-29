using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform target;

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(transform.position.x == target.position.x && transform.position.y == target.position.y)
        {
            DestroyProjectile();
        }
	}

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }
}

