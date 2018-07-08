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
    //Subscribes to our game events
    void OnEnable()
    {
        GameEvents.OnGameStateChange += OnGameStateChange;
    }
    //Unsubscribes to our game events
    void OnDisable()
    {
        GameEvents.OnGameStateChange -= OnGameStateChange;
    }
    void OnGameStateChange(GameState gamestate)
    {
        if (GameManager.instance.gameState == GameState.Dialogue)
        {
            Debug.Log("working");
            dialogueBox.SetActive(true);
        }
        if (GameManager.instance.gameState == GameState.FreeRoam)
        {
            Debug.Log("working");
            dialogueBox.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameState == GameState.FreeRoam)
            {
                gameState = GameState.Dialogue;
            }
            else
            {
                gameState = GameState.FreeRoam;
            }
            GameEvents.ReportGameStateChange(GameState.Dialogue);
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
