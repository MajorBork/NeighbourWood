using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using EasyEditor;
using PixelCrushers.DialogueSystem;
using Language.Lua;
using Manager.Character;
using Manager.Environment;
namespace Manager.Dialogue 
{
    #region DialogueManager Class
    public class DialogueManager : Singleton<DialogueManager>
    {
        #region Variables
        public LuaNetworkCommands Lua;
        public DialogueDatabase neighbourWoodsDatabase;
        public DialogueActor playerActor;
        public DialogueActor TestCharacter;
        public DialogueActor TestCharacter2;
        public DialogueActor TestCharacter3;
        public EnvironmentManager environmentManager;
        public string food;
        public int conversationID;
        public int dialogueEntryID;
        public GameState gameState;
        #endregion
        #region Start and Update Methods
        void Start() // Use this for initialization
        {
            //IfActorSpoke();
        }
        void Update() // Use this for initialization
        {
            GetConversation();
        }
        #endregion
        void GetConversation()
        {
            DialogueLua.DoesVariableExist(food);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (DialogueLua.DoesVariableExist(food))
                {
                    Debug.Log(DialogueLua.DoesVariableExist(food));
                }
            }
        }
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
