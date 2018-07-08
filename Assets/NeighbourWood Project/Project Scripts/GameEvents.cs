using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static event Action<Vision> OnVisionChange = null;
    public static event Action<Dialogue> OnDialogueChange = null;
    public static event Action<GameState> OnGameStateChange = null;

    //Events
    #region Events
    public static void ReportVisionChange(Vision vision)
    {
        //Debug.Log (">>> EVENT: ReportOnVisionChange((" + vision +")");
        if (OnVisionChange != null)
            OnVisionChange(vision);
    }
    public static void ReportDialogueChange(Dialogue dialogue)
    {
        //Debug.Log (">>> EVENT: ReportOnDialogueChange((" + vision +")");
        if (OnDialogueChange != null)
            OnDialogueChange(dialogue);
    }
    public static void ReportGameStateChange(GameState gamestate)
    {
        //Debug.Log (">>> EVENT: ReportOnDialogueChange((" + game +")");
        if (OnGameStateChange != null)
            OnGameStateChange(gamestate);
    }
    #endregion
}
