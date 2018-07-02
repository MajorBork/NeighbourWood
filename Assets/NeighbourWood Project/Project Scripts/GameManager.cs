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
    public int score = 0;
    public int lives;
    public float timer = 100;

    public GameState gameState;
    
    void Start()
    {
        
    }
    void Update()
    {
        timer -= Time.deltaTime;
    }
    //Subscribes to our game events
    void OnEnable()
    {
        //GameEvents.OnEnemyHit += OnEnemyHit;
    }

    //Unsubscribes to our game events
    void OnDisable()
    {
        //GameEvents.OnEnemyHit -= OnEnemyHit;
    }

    void OnEnemyHit()
    {
        score += 10;
        timer += 1;
    }
    

}
