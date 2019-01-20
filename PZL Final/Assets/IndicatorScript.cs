using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{

    SpriteRenderer myRenderer;

	// Start
	void Start ()
    {
        myRenderer = this.GetComponent<SpriteRenderer>();

	}
	
    public void DisplayIndicator()
    {
        myRenderer.enabled = true;
    }

    public void HideIndicator()
    {
        myRenderer.enabled = false;
    }

}
