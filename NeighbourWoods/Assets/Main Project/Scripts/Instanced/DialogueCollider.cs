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
    public CanvasGroup buttonPressBox;
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
                Debug.Log(dl);
            }  
        }
    }
    #endregion
    #region ColliderTriggerMethods
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canStartDialogue = true;
            Debug.Log("Entering in character collider working");
        }
    }
    void OnTriggerStay(Collider Other)
    {
        if (Other.tag == "Player")
        {
            buttonPressBox.alpha = 1;
        }
        if (canStartDialogue && Input.GetKeyDown(KeyCode.E))
        {
            if (gameState == GameState.FREE_ROAM)
            {
                gameState = GameState.DIALOGUE;
                GameEvents.ReportGameStateChange(gameState);
                SetDialogueID();
                
            }
            else
            {
                gameState = GameState.FREE_ROAM;
                GameEvents.ReportGameStateChange(gameState);
                buttonPressBox.alpha = 2;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canStartDialogue = false;
            GameEvents.ReportGameStateChange(GameState.FREE_ROAM);
            Debug.Log("Exiting from character collider working");
            buttonPressBox.alpha = 0;
        }
    }
    #endregion
}
