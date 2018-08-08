using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using Manager.Task;
using Manager.UI;
using Manager.Dialogue;

public class DialogueCollider : MonoBehaviour
{
    #region Variables
    public Collider dialoguecol;
    public DialogueID dialogueID;
    public GameState gameState;
    //public CanvasGroup otherDialogueName;
    //public CanvasGroup buttonPressBox;
    public DialogueManager dialogueManager;
    public TaskManager taskManager;
    public bool canStartDialogue = false;
    #endregion
    #region Dialogue Methods
    public void SetDialogueID()
    {
        foreach (DialogueList dl in dialogueManager.dialogueList)
        {
            if (dl.dialogueID == dialogueID)
            {
                dialogueManager.StartDialogue(dl);
            }
            //Debug.Log(dl.characters);
        }
    }
    public void SetTaskID()
    {
        
    }
    public void TriggerDialogue()
    {
        //dialogueManager.StartDialogue(characterName);
        SetDialogueID();
    }
    #endregion
    #region ColliderTriggerMethods
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canStartDialogue = true;
            Debug.Log("working");
        }
    }
    void OnTriggerStay(Collider Other)
    {
        if (canStartDialogue && Input.GetKeyDown(KeyCode.E))
        {
            if (gameState == GameState.FreeRoam)
            {
                gameState = GameState.Dialogue;
                GameEvents.ReportGameStateChange(gameState);
                SetDialogueID();
            }
            else
            {
                gameState = GameState.FreeRoam;
                GameEvents.ReportGameStateChange(gameState);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canStartDialogue = false;
            GameEvents.ReportGameStateChange(GameState.FreeRoam);
            Debug.Log("working");
        }
    }
    #endregion
}
