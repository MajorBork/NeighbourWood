using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyEditor;
using Manager.Level;
using PixelCrushers.DialogueSystem;
using Language.Lua;
namespace Manager.Environment
{
    public class EnvironmentManager : Singleton<EnvironmentManager>
    {
        public Day day;
        public TimeSlot timeSlot;
        public Light sceneLight;
        public Color morningLightColour;
        public Color middayLightColour;
        public Color afternoonLightColour;
        public Color eveningLightColour;
        void Start()// Use this for initialization
        {

        }
        void Update()// Update is called once per frame
        {
            switch (Level.LevelManager.instance.timeSlot)
            {
                case TimeSlot.MORNING: // if the GameState enum is in FreeRoam then all of the movement and button controls updates
                    sceneLight.color = morningLightColour;
                    break;
                case TimeSlot.MIDDAY:
                    sceneLight.color = middayLightColour;
                    break;
                case TimeSlot.AFTERNOON:
                    sceneLight.color = afternoonLightColour;
                    break;
                case TimeSlot.EVENING:
                    sceneLight.color = eveningLightColour;
                    break;
                default: break;
            }
        }
        void OnEnable()
        {
            GameEvents.OnTimeChange += OnTimeChange;
        }
        void OnDisable()
        {
            GameEvents.OnTimeChange -= OnTimeChange;
        }
        void OnTimeChange(TimeSlot timeSlot, Day day)
        {
            
        }
    }
    [Groups("Base Settings")]
    [System.Serializable]
    public class Environments
    {

    }
}
