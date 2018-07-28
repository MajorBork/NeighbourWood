using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents 
{
    #region Events Variables
    public static event Action<Vision> OnVisionChange = null;
    public static event Action<GameState> OnGameStateChange = null;
    public static event Action<Day> OnDayChange = null;
    public static event Action<TimeSlot> OnTimeSlotChange = null;
    //public static event Action<Tasks> OnTaskStartedChange = null;
    #endregion
    #region Events
    public static void ReportVisionChange(Vision vision)
    {
        //Debug.Log (">>> EVENT: ReportOnVisionChange((" + vision +")");
        if (OnVisionChange != null)
        {
            OnVisionChange(vision);
        }
    }
    public static void ReportGameStateChange(GameState gamestate)
    {
        //Debug.Log (">>> EVENT: ReportOnDialogueChange((" + game +")");
        if (OnGameStateChange != null)
        {
            OnGameStateChange(gamestate);
        }
    }
    public static void ReportDayChange(Day day)
    {
        if(OnDayChange != null)
        {
            OnDayChange(day);
        }
    }
    public static void ReportOnTimeSlotChange(TimeSlot timeSlot)
    {
        if (OnTimeSlotChange != null)
        {
            OnTimeSlotChange(timeSlot);
        }
    }
    #endregion
}
