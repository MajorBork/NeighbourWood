using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCollider : MonoBehaviour
{
    public GameObject dialogueManager;
    public GameObject dialogueBox;
    public Collider dialoguecol;
    public GameState gameState;
    void Start () // Use this for initialization
    {
		
	}
	void Update () // Update is called once per frame
    {

	}
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
}
