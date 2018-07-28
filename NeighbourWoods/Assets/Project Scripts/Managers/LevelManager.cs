using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
public enum TimeSlot
{
    Morning,
    Midday,
    Afternoon,
    Evening,
}
namespace Manager.Level
{
    
    public class LevelManager : Singleton<LevelManager>
    {
        #region Variables
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
}
