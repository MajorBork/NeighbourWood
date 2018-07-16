using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueList dialogueList;
    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogueList);
    }
}
