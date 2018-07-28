using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Manager.Player;

namespace Manager.Audio
{
    #region AudioManager Class
    public class AudioManager : Singleton<AudioManager>
    {
        public float volume;
        public static bool mute;
        void OnEnable()  //Subscribes to our game events
        {
            GameEvents.OnVisionChange += OnVisionChange;
        }
        void OnDisable() //Unsubscribes to our game events
        {
            GameEvents.OnVisionChange -= OnVisionChange;
        }
        void OnVisionChange(Vision vision)
        {
            Debug.Log("DOG SOUND");
        }
    }
    #endregion
}
