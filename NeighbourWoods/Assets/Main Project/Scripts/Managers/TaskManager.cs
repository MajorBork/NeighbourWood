using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyEditor;
using Manager.Level;

namespace Manager.Task
{
    #region TaskName Enum
    public enum TaskName
    {
        FIND_PUUPIES,
        GIVE_TURTLES_PIZZA,
        CHASE_OFF_FOX,
        SECURE_CHICKEN_COOP,
        DEAL_WITH_FOX,
        MEDIATE_BETWEEN_FOX_AND_CHICKENS,
        HELP_SQUIRREL,
        CONVENIENCE_STORE_HEIST,
        DEAL_WITH_DEER,
        MEET_UNICORN,
        FAWN_RESCUE,
        WITCH_HOUSE_VISIT,
        FIND_SOCKS_FOR_ARCHIE
    }
    #endregion
    #region Tasktype Enum
    public enum Taskstype
    {
        Dialogue,
        Fetch,
        Puzzle,
        // other
    }
    #endregion
    #region TasManager Class
    public class TaskManager : Singleton<TaskManager>
    {
        public Tasks[] tasks;
        #region TaskStarted() TaskCompleted()
        public void TaskStarted(Tasks tasks) // name and value in the Parameters
        {
            //Sends started task to eventmanager 
        }
        public void TaskCompleted(Tasks tasks) // name and value in the Parameters
        {
            //Sends completed task to eventmanager
        }
        #endregion
    }
    #endregion
    #region Task Class
    [Groups("Base Settings")]
    [System.Serializable]
    public class Tasks
    {
        #region Array Variables
        public TaskName taskName;
        public bool taskStarted;
        public bool taskCompleted;
        public Taskstype tasksType;
        public Day day;
        public TimeSlot timeSlot;
        #endregion
    }
    #endregion
}
