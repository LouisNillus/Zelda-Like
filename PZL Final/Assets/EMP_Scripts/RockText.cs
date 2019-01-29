using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockText : MonoBehaviour
{
    [ColorUsage(true, true, 0f, 8f, 0.125f, 3f)]
    public Color color;
    public Text text;

    // Use this for initialization
    void Start ()
    {
        text.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
