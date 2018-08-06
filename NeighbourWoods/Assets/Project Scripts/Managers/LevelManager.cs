using System.Collections;
using System.Collections.Generic;
using EasyEditor;
using UnityEngine;
using Manager.Task;

namespace Manager.Level
{
    #region Days Enum
    public enum Day
    {
        Day1,
        Day2,
        Day3,
        Day4,
        Day5,
        Day6,
        Day7,
    }
    #endregion
    #region TimeSlot Enum
    public enum TimeSlot
    {
        Morning,
        Midday,
        Afternoon,
        Evening,
    }
    #endregion
    #region LevelManager Class
    public class LevelManager : Singleton<LevelManager>
    {
        #region Variables
        public Levels[] levels;
        public Day day;
        public TimeSlot timeSlot;
        public int currentTime;
        public int maxtask;
        #endregion
        #region Start and Update Methods
        void Start() // Use this for initialization
        {

        }
        void Update() // Update is called once per frame
        {

        }
        #endregion
        void UpdateTime() // updates our time to the next increment 
        {
            // if increment > max add 1 to day
            // resets increment 
        }
    }
    #endregion
    #region Levels Class
    [Groups("Base Settings")]
    [System.Serializable]
    public class Levels
    {
        #region Array Variables
        public string locationsName;
        public BoxCollider areaCollider;
        public Tasks tasksInArea;
        #endregion
    }
    #endregion
}
