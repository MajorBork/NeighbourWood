using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class DialogueCollider : MonoBehaviour
{
    #region Variables
    public Collider dialoguecol;
    public GameState gameState;
    #endregion
    #region ColliderTriggerMethods
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameState == GameState.FreeRoam)
            {
                gameState = GameState.Dialogue;
                GameEvents.ReportGameStateChange(gameState);
            }
            else
            {
                gameState = GameState.FreeRoam;
                GameEvents.ReportGameStateChange(gameState);
            }
            Debug.Log("working");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.ReportGameStateChange(GameState.FreeRoam);
            Debug.Log("working");
        }
    }
    #endregion
}
