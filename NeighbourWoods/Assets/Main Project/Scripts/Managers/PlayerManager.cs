using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;
using TMPro;
namespace Manager.Player
{
    #region Vision Enum
    public enum Vision //The Enum that controls which vision state you are in  
    {
        NORMAL,
        SMELL,
    }
    #endregion
    #region PlayerManager Class
    public class PlayerManager : Singleton<PlayerManager> // An script that will not be destroyed when going new levels (if we need to load new levels)
    {
        #region Variables
        public Vision vision;
        public TMP_Text testTMP;
        #region Object Variables
        // All of the Variables that link to objects or components
        public GameObject player;
        public GameObject playerCamera;
        public Transform playerCameraTransform;
        public PostProcessingBehaviour smellOVision;
        public CharacterController characterController;
        public GameObject[] smellObjects = new GameObject[0];
        #endregion
        #region Controls Variables
        //Old movement variables
        //public int forwardSpeed = 10;
        //public int backwardSpeed = 10;
        //public int leftSpeed = 10;
        //public int rightSpeed = 10;
        //Space//
        //All of the controls variables used in the control functions
        public float mouseSensitivity = 10;
        public float walkSpeed = 2;
        public float runSpeed = 6;
        public float gravity = -12;
        public float jumpHeight = 1;
        [Range(0, 1)]
        public float airControlPercent;
        private float velocityY;
        public float turnSmoothTime = 0.2f;
        public float speedSmoothTime = 0.1f;
        private float turnSmoothVelocity;
        private float speedSmoothVelocity;
        private float currentSpeed;
        public bool lockCursor;
        Vector3 currentRotation;
        Vector3 rotationSmoothVelocity;
        public Vector2 pitchMinMax = new Vector2(-40,85);
        public float cameraRotation;
        public Transform target;
        private float yaw = 0;
        private float pitch = 0;
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
            vision = Vision.NORMAL;
            characterController = GetComponent<CharacterController>();
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        void Update() // Update is called once per frame
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 inputDir = input.normalized;
            bool running = Input.GetButton("Sprint"); // Sprinting in Game
            switch (GameManager.instance.gameState)
            {
                case GameState.FREE_ROAM: // if the GameState enum is in FreeRoam then all of the movement and button controls updates
                    MovementController(inputDir,running);
                    VisionController();
                    CameraController();
                    BarkController();
                    DigController();
                    JumpController();
                    break;
                case GameState.DIALOGUE: // if the GameState enum is in Dialogue then the DialogueController() updates 
                    DialogueController();
                    break;
                case GameState.TITLE_SCREEN:
                    break;
                case GameState.PAUSE_SCREEN:
                    break;
                case GameState.CREDIT_SCREEN:
                    break;
                default: break;
            }
        }
        #endregion
        #region Control Methods
        #region MovementController()
        void MovementController(Vector2 inputDir, bool running) // The Function that moves the Player 
        {
            if (inputDir != Vector2.zero)
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + playerCameraTransform.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
            }
            float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));
            velocityY += Time.deltaTime * gravity;
            Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
            characterController.Move(velocity * Time.deltaTime);
            if (characterController.isGrounded)
            {
                velocityY = 0;
            }
            #region Animator?
            // Animator?
            //float animationSpeedPercent = ((running) ? currentSpeed/runSpeed : currentSpeed/walkSpeed* .5f);
            //animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
            //currentSpeed = new Vector2(characterController.velocity.x, characterContoller.velocity.z).magnitude;
            #endregion
            #region Old MovementCode
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
            #endregion
        }
        float GetModifiedSmoothTime(float smoothTime) // The Function that allows me to control the amount of movement that the player has when in the air
        {
            if (characterController.isGrounded)
            {
                return smoothTime;
            }
            if (airControlPercent == 0)
            {
                return float.MaxValue;
            }
            return smoothTime / airControlPercent;
        }
        #endregion
        #region VisionController()
        void VisionController() // The Function that switches the Vision enum event to smell or normal so that the colour blind camera comes on and the smell objects are turn on or off
        {
            if (Input.GetButtonDown("SMELL-O-Vision"))
            {
                if (vision == Vision.NORMAL)
                {
                    vision = Vision.SMELL;
                }
                else
                {
                    vision = Vision.NORMAL;
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
        #region JumpController()
        void JumpController()
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (characterController.isGrounded)
                {
                    float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
                    velocityY = jumpVelocity;
                }
            }
        }
        #endregion
        #region DigController()
        void DigController()
        {
            if (Input.GetButtonDown("Dig"))
            {
                Debug.Log("Test Digging");
                //testTMP.text = ("Test Digging to be coded");
            }
        }
        #endregion
        #region BarkController()
        void BarkController()
        {
            if (Input.GetButtonDown("Bark"))
            {
                Debug.Log("Bark");
                //testTMP.text = ("Bark to be coded");
            }
        }
        #endregion
        void MapController()
        {
            if (Input.GetButtonDown("Map"))
            {
                Debug.Log("Map");
                //testTMP.text = ("Map to be coded");
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
            if (vision == Vision.NORMAL)
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