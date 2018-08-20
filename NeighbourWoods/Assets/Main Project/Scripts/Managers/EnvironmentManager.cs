using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyEditor;
using Manager.Level;
namespace Manager.Environment
{
    public class EnvironmentManager : Singleton<EnvironmentManager>
    {
        public Day day;
        public TimeSlot timeSlot;
        public Light sceneLight;
        void Start()// Use this for initialization
        {

        }

        void Update()// Update is called once per frame
        {

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
            //sceneLight.color
        }
    }
    [Groups("Base Settings")]
    [System.Serializable]
    public class Environments
    {

    }
}
