using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCollider : MonoBehaviour
{
    public GameObject dialogueManager;
    public GameObject dialogueBox;
    public Collider dialoguecol;
	void Start () // Use this for initialization
    {
		
	}
	void Update () // Update is called once per frame
    {
        //dialoguecol = GameObject.GetComponent<BoxCollider>();
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
            dialogueBox.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.ReportGameStateChange(GameState.Dialogue);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.ReportGameStateChange(GameState.FreeRoam);
        }
    }
}
