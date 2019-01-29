using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LivesScript : MonoBehaviour
{

    public List<Color> colorList;
    public float deltaTimeToDisplay;

    public bool[] colorBlinded = { false, false, false };
    public GameObject musicPlayer;
    public GameObject weapon;
    public GameObject soldier;

    public Image[] iconToHighlight;
    public Toggle keepIconHighlighted;


    //Private
    Text text;
    string sentence = "Lives :";
    int counter = 0;
    int colorCounter = 0;
    bool musicIsPlayed = false;
    AudioSource audioSrc;
    MeshRenderer weaponMesh;
    Animator soldierAnimator;

	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
        audioSrc = musicPlayer.GetComponent<AudioSource>();
        weaponMesh = weapon.GetComponent<MeshRenderer>();
        soldierAnimator = soldier.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!musicIsPlayed)
        {
            if (colorBlinded[0] && colorBlinded[1] && colorBlinded[2])
            {
                if (!audioSrc.isPlaying)
                {
                    musicIsPlayed = true;

                    //Play music
                    audioSrc.Play();

                    //Reset Text
                    text.text = "";

                    //Hide Weapon
                    weaponMesh.enabled = false;

                    //Launch coroutine :
                    StartCoroutine(DisplayEffect());

                    //Let's Dance... (David Bowie)
                    soldierAnimator.SetBool("Dance", true);
                }
            }
        }
        else
        {
            if(!audioSrc.isPlaying)
            {
                //Reset Text & Color
                text.text = "Lives :";
                text.color = Color.black;

                //Stop coroutine
                StopCoroutine(DisplayEffect());

                //Reset flags
                for (int i = 0; i < 3; i++)
                {
                    colorBlinded[i] = false;
                }

                //Reset IHM Panel
                keepIconHighlighted.isOn = false;

                //Show weapon
                weaponMesh.enabled = true;

                //Stop show
                soldierAnimator.SetBool("Dance", false);
            }
        }
	}


    IEnumerator DisplayEffect()
    {
        yield return new WaitForSeconds(deltaTimeToDisplay);
        text.text = text.text + sentence[counter];
        text.color = colorList[colorCounter];
        iconToHighlight[colorCounter].color = colorList[Random.Range(0,3)];
        counter++;
        colorCounter++;

        //Reset colorCounter :
        if (colorCounter >= colorList.Count)
        {
            colorCounter = 0;
        }

        if (counter >= sentence.Length)
        {
            counter = 0;
            text.text = "";
            StartCoroutine(DisplayEffect());
        }
        else
        {
            StartCoroutine(DisplayEffect());
        }
    }
}
