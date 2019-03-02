using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject CubeD;

    public Camera mainCamera;
    public Camera cubeCamera;
    public Camera playerCamera;

    private Vector3 offset;
    private Vector3 offsetCube;

    void Start()
    {
        offset = transform.position - player.transform.position;
        cubeCamera.enabled = false;
        playerCamera.enabled = false;
        mainCamera.enabled = true;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (CubeD != null)
        {
            Rigidbody2D rbCube = CubeD.GetComponent<Rigidbody2D>();

            transform.position = player.transform.position + offset;

            if (rbCube.velocity.x <= 0.4f)
            {
                mainCamera.enabled = true;
                cubeCamera.enabled = false;
                playerCamera.enabled = false;
            }
            else
            {
                mainCamera.enabled = false;
                cubeCamera.enabled = true;
                playerCamera.enabled = true;
            }
        }
        else
        {
            mainCamera.enabled = true;
            cubeCamera.enabled = false;
            playerCamera.enabled = false;
        }
    }
}
