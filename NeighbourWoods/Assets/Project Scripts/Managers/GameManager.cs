using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Manager.Item;
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

        void Start()
        {

        }
        void Update()
        {

        }
    }
    #endregion
}
