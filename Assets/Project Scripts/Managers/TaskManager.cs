using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyEditor;

public enum Tasks
{
    Dialogue,
    Fetch,
    Puzzle,
    // other
}

public class TaskManager : Singleton<TaskManager>
{
    public Task[] tasks;
    public void TaskStarted() // name and value in the Parameters
    {
        //Sends started task to eventmanager 
    }
    public void TaskCompleted() // name and value in the Parameters
    {
        //Sends completed task to eventmanager
    }
}

[Groups("Base Settings")]
[System.Serializable]
public class Task
{
    #region Array Variables
    public int taskID;
    public Tasks tasks;
    public Day day;
    public TimeSlot timeSlot;
    #endregion
}
