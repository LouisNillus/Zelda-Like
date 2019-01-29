using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISessionAnimate : MonoBehaviour
{
    public float deltaTimeToDisplay = 3f;
    public string sentence = "UI - Session.....";

    //Private
    Text text;
    int nbCharacter;
    int counter = 0;

	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
        nbCharacter = sentence.Length;

        StartCoroutine(DisplaySentence());
    }
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    IEnumerator DisplaySentence()
    {
        yield return new WaitForSeconds(deltaTimeToDisplay);
        text.text = text.text + sentence[counter];
        counter++;
        if (counter >= nbCharacter)
        {
            counter = 0;
            text.text = "";
            StartCoroutine(DisplaySentence());
        }
        else
        {
            StartCoroutine(DisplaySentence());
        }
    }
}
