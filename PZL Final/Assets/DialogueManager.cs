using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public AudioSource audioKey;
    public Animator animator;
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
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

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
        dialogueText.text = sentence;

        StopAllCoroutines();
        StartCoroutine(LetterByLetter(sentence));

    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of discussion");
        scriptController.dialogueHasStarted = false;
    }

    IEnumerator LetterByLetter (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            audioKey.Play();
            yield return new WaitForSeconds(0.05f);
        }
    }


}
