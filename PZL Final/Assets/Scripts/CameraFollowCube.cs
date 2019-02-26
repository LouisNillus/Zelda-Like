using UnityEngine;
using System.Collections;

public class CameraFollowCube : MonoBehaviour
{
    public GameObject CubeD;

    private Vector3 offsetCube;

    void Start()
    {
        offsetCube = transform.position - CubeD.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = CubeD.transform.position + offsetCube;
    }

}