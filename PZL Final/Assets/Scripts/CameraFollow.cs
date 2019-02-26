using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject CubeD;

    private Vector3 offset;
    private Vector3 offsetCube;

    void Start()
    {
        offset = transform.position - player.transform.position;
        offsetCube = transform.position - CubeD.transform.position;

        Rigidbody2D rbCube = CubeD.GetComponent<Rigidbody2D>();
    }
   
    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        Rigidbody2D rbCube = CubeD.GetComponent<Rigidbody2D>();
        transform.position = player.transform.position + offset;

        if (rbCube.velocity.x <= 0.4f)
        {
            Debug.Log("Je bouge pas " + rbCube.velocity.x);
            transform.position = player.transform.position + offset;
        }
        else
        {
            Debug.Log("Je BOUGE " + rbCube.velocity.x);
            transform.position = CubeD.transform.position + offsetCube;
        }
    }

}