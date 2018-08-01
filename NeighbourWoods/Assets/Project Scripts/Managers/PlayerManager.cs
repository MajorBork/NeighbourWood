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
        #region Object Variables
        public GameObject player;
        public GameObject playerCamera;
        public Transform playerCameraTransform;
        public PostProcessingBehaviour smellOVision;
        public GameObject[] smellObjects = new GameObject[0];
        #endregion
        #region Controls Variables
        public float mouseSensitivity = 10;
        public float walkSpeed = 2;
        public float runSpeed = 6;
        public float turnSmoothTime = 0.2f;
        public float speedSmoothTime = 0.1f;
        float turnSmoothVelocity;
        float speedSmoothVelocity;
        float currentSpeed;
        //public int forwardSpeed = 10;
        //public int backwardSpeed = 10;
        //public int leftSpeed = 10;
        //public int rightSpeed = 10;
        public bool lockCursor;
        Vector3 currentRotation;
        Vector3 rotationSmoothVelocity;
        public Vector2 pitchMinMax = new Vector2(-40,85);
        public float cameraRotation;
        public Transform target;
        float yaw = 0;
        float pitch = 0;
        #endregion
        #endregion
        #region Start() and Update()
        void Start() // Use this for initialization
        {
            player = GameObject.FindWithTag("Player");
            playerCamera = GameObject.FindWithTag("MainCamera");
            playerCameraTransform = Camera.main.transform;
            smellOVision = GetComponentInChildren<PostProcessingBehaviour>();
            smellOVision.profile.vignette.enabled = false;
            vision = Vision.Normal;
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        void Update() // Update is called once per frame
        {
            switch (GameManager.instance.gameState)
            {
                case GameState.FreeRoam:
                    MovementController();
                    VisionController();
                    CameraController();
                    BarkController();
                    DigController();
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
        #region MovementController()
        void MovementController() // The Function that moves the Player 
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 inputDir = input.normalized;
            if (inputDir != Vector2.zero)
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + playerCameraTransform.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
            }
            bool running = Input.GetKey(KeyCode.LeftShift); // Sprinting in Game
            float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
            transform.Translate (transform.forward * currentSpeed * Time.deltaTime, Space.World);
            // Animator?
            //float animationSpeedPercent = ((running) ? 1:0.5f) * inputDir.magnitude;
            //animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
            // Old movement code
            //if (Input.GetKey(KeyCode.W))
            //{
            //    transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
            //}
            //if (Input.GetKey(KeyCode.A))
            //{
            //    transform.position += Vector3.left * Time.deltaTime * leftSpeed;
            //}
            //if (Input.GetKey(KeyCode.D))
            //{
            //    transform.position += Vector3.right * Time.deltaTime * rightSpeed;
            //}
            //if (Input.GetKey(KeyCode.S))
            //{
            //    transform.position += Vector3.back * Time.deltaTime * backwardSpeed;
            //}
        }
        #endregion
        #region VisionController()
        void VisionController() // The Function that switches the Vision enum event to smell or normal so that the colour blind camera comes on and the smell objects are turn on or off
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
        #endregion
        #region CameraController()
        void CameraController() // Controls the third person camera
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
            Vector3 targetRotation = new Vector3(pitch, yaw);
            float rotationSmoothTime = 0.12f;
            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
            playerCamera.transform.eulerAngles = targetRotation;
        }
        #endregion
        void JumpController()
        {

        }
        void DigController()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Test Digging");
            }
        }
        void BarkController()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Bark");
            }
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