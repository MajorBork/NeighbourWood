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
        FreeRoam,
        Dialogue,
        TitleScreen,
        PauseScreen,
        CreditScreen,
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
            if (Input.GetButton("Map"))
            {
                startScreen.DOFade(1, 0.3f);
            }
            else
            {
                startScreen.DOFade(0, 0.3f);
            }
        }
    }
    #endregion
}