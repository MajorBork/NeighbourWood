using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager.Character;
using TMPro;
using DG.Tweening;
using EasyEditor;
namespace Manager.Dialogue
{
    #region DialogueName Enum
    public enum DialogueID
    {
        //PLA_01, 
        //SHI_01,
        //UNI_01,
        MORNING_DAY_1,
        MORNING_DAY_2,
        MORNING_DAY_3,
    }
    #endregion
    #region DialoguePorCHolder Enum
    //public enum DialoguePorCHolder
    //{
        //Player,
        //Character,
    //}
    #endregion
    #region DialogueManager Class
    public class DialogueManager : Singleton<DialogueManager>
    {
        #region Variables
        public List<DialogueList> dialogueList;
        public TMP_Text characterText;
        public TMP_Text characterDialogueText;
        public TMP_Text playerNameText;
        public TMP_Text playerDialogueText;
        private Queue<string> sentences;
        public List<string> sent;
        public GameState gameState;
        #endregion
        #region Start and Update Methods
        void Start() // Use this for initialization
        {
            sentences = new Queue<string>();
            sent = new List<string>();
        }
        #endregion
        #region Dialogue Methods
        public void StartDialogue(DialogueList dialogueList)
        {
            //playerNameText.text = dialogueList.dialogueHolderName;
            sentences.Clear();
            sent.Clear();
            playerDialogueText.text = "";
            characterDialogueText.text = "";
            foreach (string sentence in dialogueList.sentences)
            {
                sent.Add(sentence);
                //sentences.Enqueue(sentence);
                //Debug.Log(sentence);
            }
            DisplayNextSentence();
        }
        public void DisplayNextSentence()
        {
            //if (sentences.Count == 0)
            //{
            //    EndDialogue();
            //    return;
            //}
            //string sentence = sentences.Dequeue();

            string sentence = sent[0];
            Debug.Log(sent[0]);
            if (sentence.EndsWith("/P01/"))
            {
                sentence = sentence.Remove(sentence.Length - 5);
                playerDialogueText.text = sentence;
                characterDialogueText.DOFade(0.5f, 0.3f);
                playerDialogueText.DOFade(1,0.3f);
                
            }
            else if (sentence.EndsWith("/P02/"))
            {
                sentence = sentence.Remove(sentence.Length - 5);
                characterDialogueText.text = sentence;
                playerDialogueText.DOFade(0.5f, 0.3f);
                characterDialogueText.DOFade(1, 0.3f);
                
            }
            else if (sentence.EndsWith("/END/"))
            {
                EndDialogue();
            }
            sent.RemoveAt(0);
            //Debug.Log(sentence);
        }
        public void DialoguePersonSwitch()
        {
            //if ()
            //{
            //
            //}
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
        #region List Variables
        //public DialoguePorCHolder dialoguePorCHolder;
        //public Characters characters;
        public DialogueID dialogueID;
        [TextArea(3, 10)]
        public string[] sentences;
        #endregion
    }
    #endregion
}
