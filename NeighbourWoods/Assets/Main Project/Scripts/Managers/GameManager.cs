﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Manager.Item;
using DG.Tweening;
using UnityEngine.UI;
namespace Manager
{
    #region GameState Enum
    public enum GameState
    {
        FREE_ROAM,
        DIALOGUE,
        TITLE_SCREEN,
        PAUSE_SCREEN,
        CREDIT_SCREEN,
    }
    #endregion
    #region GameManager 
    public class GameManager : Singleton<GameManager>
    {
        public int foodLevel;
        public ItemType itemType;
        public GameState gameState;
        public Image startScreen;
        void Start()
        {
            
        }
        void Update()
        {
            if (Input.GetButtonDown("Map"))
            {
                startScreen.DOFade(1, 0.3f);
            }
            else
            {
                startScreen.DOFade(0, 0.3f);
            }
        }
        public void StartDialogue()
        {
            Debug.Log("Start of converstion.");
            if (gameState == GameState.FREE_ROAM)
            {
                gameState = GameState.DIALOGUE;
            }
            GameEvents.ReportGameStateChange(GameState.DIALOGUE);
        }
        public void EndDialogue()
        {
            Debug.Log("End of converstion.");
            if (gameState == GameState.DIALOGUE)
            {
                gameState = GameState.FREE_ROAM;
            }
            GameEvents.ReportGameStateChange(GameState.FREE_ROAM);
        }
        //void OnEnable() //Subscribes to our game events
        //{
        //    GameEvents.OnGameStateChange += OnGameStateChange;
        //}
        //void OnDisable() //Unsubscribes to our game events
        //{
        //    GameEvents.OnGameStateChange -= OnGameStateChange;
        //}
    }
    #endregion
}
