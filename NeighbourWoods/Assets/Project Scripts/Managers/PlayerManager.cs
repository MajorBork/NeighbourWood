using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace Manager.Player
{
    #region Vision Enum
    public enum Vision
    {
        Normal,
        Smell,
    }
    #endregion
    #region PlayerManager Class
    public class PlayerManager : Singleton<PlayerManager>
    {
        #region Variables
        public Vision vision;
        public GameObject player;
        public GameObject playerCamera;
        public PostProcessingBehaviour smellOVision;
        public GameObject[] smellObjects = new GameObject[0];
        #region Controls Variables
        public float mouseSensitivity = 10;
        public int forwardSpeed = 10;
        public int backwardSpeed = 10;
        public int leftSpeed = 10;
        public int rightSpeed = 10;
        Vector3 currentRotation;
        Vector3 rotationSmoothVelocity;
        public Vector2 pitchMinMax = new Vector2(-40,85);
        public float cameraRotation;
        public Transform target;
        float yaw = 0;
        float pitch = 0;
        #endregion
        #endregion
        #region Start and Update Methods
        void Start() // Use this for initialization
        {
            player = GameObject.FindWithTag("Player");
            playerCamera = GameObject.FindWithTag("MainCamera");
            smellOVision = GetComponentInChildren<PostProcessingBehaviour>();
            smellOVision.profile.vignette.enabled = false;
            vision = Vision.Normal;
        }
        void Update() // Update is called once per frame
        {
            switch (GameManager.instance.gameState)
            {
                case GameState.FreeRoam:
                    MovementController();
                    VisionController();
                    CameraController();
                    break;
                case GameState.Dialogue:
                    DialogueController();
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
        #endregion
        #region Control Methods
        void MovementController() // The Function that moves the Player 
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
        void VisionController() // The Function that switches the 
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (vision == Vision.Normal)
                {
                    vision = Vision.Smell;
                }
                else
                {
                    vision = Vision.Normal;
                }
                GameEvents.ReportVisionChange(vision);
            }
        }
        void CameraController()
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
            Vector3 targetRotation = new Vector3(pitch, yaw);
            float rotationSmoothTime = 0.12f;
            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
            playerCamera.transform.eulerAngles = targetRotation;
        }
        void DialogueController()
        {

        }
        #endregion
        #region Event Methods
        #region Vision Event and Listeners
        void OnEnable() //Subscribes to our game events
        {
            GameEvents.OnVisionChange += OnVisionChange;
        }
        void OnDisable() //Unsubscribes to our game events
        {
            GameEvents.OnVisionChange -= OnVisionChange;
        }
        void OnVisionChange(Vision vision)
        {
            //Debug.Log("vision mode");
            if (vision == Vision.Normal)
            {
                Camera.main.GetComponent<GenericImageEffect>().enabled = false;
                smellOVision.profile.vignette.enabled = false;
                foreach (GameObject smellObject in smellObjects)
                {
                    smellObject.SetActive(false);
                }
            }
            else
            {
                Camera.main.GetComponent<GenericImageEffect>().enabled = true;
                smellOVision.profile.vignette.enabled = true;
                foreach (GameObject smellObject in smellObjects)
                {
                    smellObject.SetActive(true);
                }
            }
        }
        #endregion
        #endregion
    }
    #endregion
}