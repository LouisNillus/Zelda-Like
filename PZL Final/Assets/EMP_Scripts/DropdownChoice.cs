using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownChoice : MonoBehaviour
{
    //Public
    public Dropdown dropdownDiva;
    public AudioClip[] musics;
    public GameObject musicPlayer;
    public GameObject soldier;

    //Private
    AudioClip currentMusic;
    AudioSource audioSrc;
    Animator soldierAnimator;
 
	// Use this for initialization
	void Start ()
    {
        audioSrc = musicPlayer.GetComponent<AudioSource>();
        currentMusic = audioSrc.clip;
        soldierAnimator = soldier.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDropDownChoice()
    {
        if (audioSrc.isPlaying)
        {
            if (dropdownDiva.value == 2)
            {
                soldierAnimator.SetBool("Dance", false);
                soldierAnimator.SetBool("DanceBowie", true);
            }
            else if (dropdownDiva.value == 1)
            {
                soldierAnimator.SetBool("DanceBowie", false);
                soldierAnimator.SetBool("Dance", true);
            }

            audioSrc.Stop();
            audioSrc.clip = musics[dropdownDiva.value];
            audioSrc.Play();
        }
    }
}
