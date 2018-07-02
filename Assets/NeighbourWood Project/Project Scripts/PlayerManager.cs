using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public enum Vision
{
    Normal,
    Smell,
}

public class PlayerManager : Singleton<PlayerManager>
{
    public Vision vision;
    GameObject player;
    GameObject playerCamera;
    public PostProcessingBehaviour smellOVision;
    public int forwardSpeed = 10;
    public int backwardSpeed = 10;
    public int leftSpeed = 10;
    public int rightSpeed = 10;
    void Start () // Use this for initialization
    {
        player = GameObject.FindWithTag("Player");
        playerCamera = GameObject.FindWithTag("MainCamera");
        smellOVision = GetComponentInChildren<PostProcessingBehaviour>();
        smellOVision.enabled = false;
        vision = Vision.Normal;
    }
	void Update () // Update is called once per frame
    {
        switch (GameManager.instance.gameState)
        {
            case GameState.FreeRoam:
                MovementController();
                VisionController();
                break;
            case GameState.Dialogue:
                break;
            case GameState.CreditScreen:
                break;
            case GameState.PauseScreen:
                break;
            case GameState.TitleScreen:
                break;
            default: break;
        }
    }

    #region controls
    void MovementController()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * leftSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * rightSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * backwardSpeed;
        }
    }
    void VisionController()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (vision == Vision.Normal)
                vision = Vision.Smell;
            else
                vision = Vision.Normal;
            GameEvents.ReportVisionChange(vision);
            
        }
    }
    void DialogueController()
    {

    }

    #endregion
    //Subscribes to our game events
    void OnEnable()
    {
        GameEvents.OnVisionChange += OnVisionChange;
    }
    //Unsubscribes to our game events
    void OnDisable()
    {
        GameEvents.OnVisionChange -= OnVisionChange;
    }
    void OnVisionChange(Vision vision)
    {
        //Debug.Log("vision mode");
        if (vision == Vision.Normal)
            smellOVision.enabled = false;
        else
            smellOVision.enabled = true;
    }
}
