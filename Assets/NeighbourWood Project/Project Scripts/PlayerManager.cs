using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    GameObject playerCamera;
    PostProcessingBehaviour smellOVision;
    public int forwardSpeed = 10;
    public int backwardSpeed = 10;
    public int leftSpeed = 10;
    public int rightSpeed = 10;
    void Start () // Use this for initialization
    {
        player = GameObject.FindWithTag("Player");
        playerCamera = GameObject.FindWithTag("MainCamera");
        smellOVision = GetComponentInChildren<PostProcessingBehaviour>();
    }
	void Update () // Update is called once per frame
    {
        MovementController();
        VisionController();
    }
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
            //smellOVision.SetActive(false);
        }
    }
}
