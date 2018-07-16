using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    FreeRoam,
    Dialogue,
    TitleScreen,
    PauseScreen,
    CreditScreen,
}

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
