using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelDisplay : MonoBehaviour
{

    //Private
    RectTransform panelTransform;
    bool deployed = false;
    public Animator panelAnimator;

	// Use this for initialization
	void Start ()
    {
        panelTransform = (RectTransform)this.transform;
        panelAnimator = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnPanelEnter()
    {
        if (!deployed)
        {
            panelAnimator.SetTrigger("DeployPanel");
            deployed = true;
        }
        
    }

    public void OnPanelExit()
    {
        if(deployed)
        {
            panelAnimator.SetTrigger("UndeployPanel");
            deployed = false;
        }
    }
}
