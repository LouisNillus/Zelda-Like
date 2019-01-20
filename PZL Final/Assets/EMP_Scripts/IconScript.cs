using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconScript : MonoBehaviour
{
    public Color color;
    public Toggle keepIconLighted;
    public Text livesText;

    //Private
    Image image;
    Color colorSaved;
    LivesScript liveScript;

	// Use this for initialization
	void Start ()
    {
        image = GetComponent<Image>();
        liveScript = livesText.GetComponent<LivesScript>();
        colorSaved = image.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnIconEnter()
    {
        image.color = color;
    }

    public void OnIconExit()
    {
        if (!keepIconLighted.isOn)
        {
            image.color = colorSaved;
        }
        else
        {
            switch (int.Parse(gameObject.tag))
            {
                case 0:
                    liveScript.colorBlinded[0] = true;
                    break;

                case 1:
                    liveScript.colorBlinded[1] = true;
                    break;

                case 2:
                    liveScript.colorBlinded[2] = true;
                    break;

                default:
                    break;
            }
        }

        

    }
}
