using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMusic : MonoBehaviour
{
    //Public
    public GameObject musicPlayer;
    public AudioClip defaultMusic;
    public Text buttonText;

    //Private
    AudioSource audioSrc;
    AudioClip clipSaved;
    

	// Use this for initialization
	void Start ()
    {
        audioSrc = musicPlayer.GetComponent<AudioSource>();
        clipSaved = audioSrc.clip;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPlayMusic()
    {
        if (!audioSrc.isPlaying)
        {
            audioSrc.clip = defaultMusic;
            audioSrc.Play();
            buttonText.text = "Stop Music";
        }
        else
        {
            audioSrc.Stop();
            audioSrc.clip = clipSaved;
            buttonText.text = "¨Play Music";
        }

    }
}
