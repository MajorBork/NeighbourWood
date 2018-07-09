using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tasks
{
    Dialogue,
    Fetch,
    Puzzle,
    // other
}

public class TaskManager : Singleton<TaskManager>
{

	void Start () 	// Use this for initialization
    {
		
	}
	void Update () // Update is called once per frame
    {
		
	}
    public void TaskStarted()
    {
        // 
    }
    public void TaskCompleted() // name and value in the Parameters
    {
        //Sends completed task to eventmanager
    }
}
