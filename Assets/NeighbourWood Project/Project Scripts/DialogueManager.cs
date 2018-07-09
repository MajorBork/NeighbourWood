using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DialogueManager : Singleton<DialogueManager>
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    public GameState gameState;
    void Start() // Use this for initialization
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(DialogueSentences dialogueSentences)
    {
        nameText.text = dialogueSentences.name;
        sentences.Clear();
        foreach (string sentence in dialogueSentences.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        //Debug.Log(sentence);
    }
    public void EndDialogue()
    {
        Debug.Log("End of converstion.");
        if (gameState == GameState.Dialogue)
        {
            gameState = GameState.FreeRoam;
        }
        GameEvents.ReportGameStateChange(GameState.FreeRoam);
    }
}
