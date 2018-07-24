using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyEditor;
public class DialogueManager : Singleton<DialogueManager>
{
    #region Variables
    public DialogueList[] dialogueList;
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    public GameState gameState;
    #endregion
    #region Start and Update Methods
    void Start() // Use this for initialization
    {
        sentences = new Queue<string>();
    }
    #endregion
    #region Dialogue Methods
    public void StartDialogue(DialogueList dialogueList)
    {
        nameText.text = dialogueList.name;
        sentences.Clear();
        foreach (string sentence in dialogueList.sentences)
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
    #endregion
}
[Groups("Base Settings")]
[System.Serializable]
public class DialogueList
{
    #region Array Variables
    public int dialogueID;
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;
    #endregion
}
