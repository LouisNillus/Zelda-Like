using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public GameObject monJoueur;
    CharacterController scriptController;

    private Queue<string> sentences;


    // Start
    void Start()
    {
        sentences = new Queue<string>();
        scriptController = monJoueur.GetComponent<CharacterController>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        Debug.Log("Starting a conversation with " + dialogue.name);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence ()
    {

        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);

    }

    public void EndDialogue()
    {
        Debug.Log("End of discussion");
        scriptController.dialogueHasStarted = false;
    }

}
