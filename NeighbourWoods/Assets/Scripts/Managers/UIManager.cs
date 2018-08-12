using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Manager.UI 
{
    #region UIManager Class
    public class UIManager : Singleton<UIManager>
    {
        #region Variables
        public CanvasGroup dialogueBoxCanvas;
        public CanvasGroup buttonPressBox;
        #endregion
        #region Start and Update
        void Start() // Use this for initialization
        {
            dialogueBoxCanvas.alpha = 0;
            buttonPressBox.alpha = 0;
        }
        void Update() // Update is called once per frame
        {

        }
        #endregion
        #region Methods
        void UpdateItem()
        {
            // replaces inventory icon 
        }
        void AssigningItems()
        {
            // assigns a icon and a scene object to each item
        }
        void UpdateCharacterIcon()
        {

        }
        #endregion
        #region Dialogue Event and Listeners
        void OnEnable()
        {
            GameEvents.OnGameStateChange += OnGameStateChange;
        }
        void OnDisable()
        {
            GameEvents.OnGameStateChange -= OnGameStateChange;
        }
        void OnGameStateChange(GameState gameState)
        {
            if (gameState == GameState.Dialogue)
            {
                dialogueBoxCanvas.alpha = 1;
            }
            else
            {
                dialogueBoxCanvas.alpha = 0;
            }
        }
        #endregion
    }
    #endregion
}
