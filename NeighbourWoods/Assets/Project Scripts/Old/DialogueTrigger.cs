using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.Dialogue;
using Manager.Character;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public string characterName;
    public DialogueList[] dialogueList;
    public void GetCharacterID()
    {
        foreach(DialogueList dl in dialogueManager.dialogueList)
        {
            //if(dl.dialogueID == )
            //Debug.Log(dl.characters);
        }
    }
    public void TriggerDialogue()
    {
        //dialogueManager.StartDialogue(characterName);
        GetCharacterID();
    }
}
