using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {


    public Dialogue dialogue;

    CharacterController scriptController;


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject myPlayer = collision.gameObject;
            scriptController = myPlayer.GetComponent<CharacterController>();
            scriptController.dialogueTriggerObject = this.gameObject;

            IndicatorScript indicatorRenderer = GetComponentInChildren<IndicatorScript>();
            indicatorRenderer.DisplayIndicator();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject myPlayer = collision.gameObject;
            scriptController = myPlayer.GetComponent<CharacterController>();
            scriptController.dialogueTriggerObject = null;

            IndicatorScript indicatorRenderer = GetComponentInChildren<IndicatorScript>();
            indicatorRenderer.HideIndicator();
        }
    }

}
