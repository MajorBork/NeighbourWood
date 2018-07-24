using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public enum ItemType
{
    Stick,
    Bone,
    Frisbee,
    // all the items in the game
}
public class UIManager : Singleton<UIManager>
{
    #region Variables
    public CanvasGroup dialogueCanvas;
    #endregion
    #region Start and Update
    void Start () // Use this for initialization
    {
        dialogueCanvas.alpha = 0;
	}
	void Update () // Update is called once per frame
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
            dialogueCanvas.alpha = 1;
        }
        else
        {
            dialogueCanvas.alpha = 0;
        }
    }
    #endregion
}
