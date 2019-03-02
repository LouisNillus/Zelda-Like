using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject cubeD;
    public GameObject cubeN;
    public GameObject cubeDEnCours;
    public GameObject cubeNEnCours;

    public Vector3 objectPos;

    void Start ()
    {
        objectPos = transform.position;
    }

    private void Update()
    {
        cubeDEnCours = GameObject.Find("CubeD");
        cubeNEnCours = GameObject.Find("CubeN");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("pillar") )
        {
            Debug.Log("Coucou cauchemar");
            Destroy(cubeNEnCours);
            Destroy(cubeDEnCours);
            respawnBox();
        }
        else if (collision.gameObject.tag == "CeQuiApparaitEnReve")
        {
            Debug.Log("Coucou reve");
            Destroy(cubeDEnCours);
            Destroy(cubeNEnCours);
            respawnBox();
        }
    }

    void respawnBox()
    {
        GameObject SaveD = cubeD;
        GameObject SaveN = cubeN;

        Debug.Log(cubeD);
        Debug.Log(cubeN);

        GameObject newBox = Instantiate(cubeD , objectPos, Quaternion.identity);
        GameObject newBox2 = Instantiate(cubeN, objectPos, Quaternion.identity);

        newBox.name = "CubeD";
        newBox2.name = "CubeN";

        newBox.GetComponent<Respawn>().cubeD = SaveD;
        newBox.GetComponent<Respawn>().cubeN = SaveN;

        if (GameObject.Find("CharacterAnim").GetComponent<CharacterController>().reve == false)
        {
            newBox.GetComponent<SpriteRenderer>().enabled = false;
            newBox2.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            newBox2.GetComponent<SpriteRenderer>().enabled = false;
            newBox.GetComponent<SpriteRenderer>().enabled = true;
        }

        /*cubeDEnCours.GetComponent<DistanceJoint2D>().distance = 0.005f;
        cubeNEnCours.GetComponent<DistanceJoint2D>().distance = 0.005f;*/
    }
}
