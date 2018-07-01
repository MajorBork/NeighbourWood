using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    GameObject playerCamera;
    PostProcessingBehaviour smellOVision;
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime;
        }
    }
    void VisionController()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            smellOVision.SetActive(false);
        }
    }
}
