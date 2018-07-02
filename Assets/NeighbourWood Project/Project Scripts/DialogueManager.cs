using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DialogueManager : Singleton<DialogueManager>
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    void Start() // Use this for initialization
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
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
        GameEvents.ReportGameStateChange(GameState.FreeRoam);
    }
}
