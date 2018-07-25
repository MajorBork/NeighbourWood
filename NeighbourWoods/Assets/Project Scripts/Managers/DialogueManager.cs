using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager.Character;
using EasyEditor;

public enum DialoguePorCHolder
{
    Player,
    Character,
}
namespace Manager.Dialogue
{
    #region DialogueManager Class
    public class DialogueManager : Singleton<DialogueManager>
    {
        #region Variables
        public DialogueList[] dialogueList;
        public Text characterText;
        public Text characterDialogueText;
        public Text playerNameText;
        public Text playerDialogueText;
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
            playerNameText.text = dialogueList.dialogueHolderName;
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
            playerDialogueText.text = sentence;
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
    #endregion
    #region DialogueList Class
    [Groups("Base Settings")]
    [System.Serializable]
    public class DialogueList
    {
        #region Array Variables
        public DialoguePorCHolder dialoguePorCHolder;
        Characters[] characters;
        public int dialogueID;
        public string dialogueHolderName;
        [TextArea(3, 10)]
        public string[] sentences;
        #endregion
    }
    #endregion
}
