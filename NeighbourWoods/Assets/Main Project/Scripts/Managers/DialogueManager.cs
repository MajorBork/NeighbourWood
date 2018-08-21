using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager.Character;
using TMPro;
using DG.Tweening;
using EasyEditor;
using PixelCrushers.DialogueSystem;
using Language.Lua;
namespace Manager.Dialogue 
{
    #region DialogueManager Class
    public class DialogueManager : Singleton<DialogueManager>
    {
        #region Variables
        public LuaNetworkCommands Lua;
        public DialogueDatabase neighbourWoodsDatabase;
        public DialogueActor playerActor;
        public GameState gameState;
        #endregion
        #region Start and Update Methods
        void Start() // Use this for initialization
        {

        }
        void Update() // Use this for initialization
        {
            //neighbourWoodsDatabase.GetDialogueEntry(int conversationID, int dialogueEntryID);
        }
        #endregion
    }
    #endregion
    #region DialogueList Class
    [Groups("Base Settings")]
    [System.Serializable]
    public class DialogueList
    {

    }
    #endregion
}
