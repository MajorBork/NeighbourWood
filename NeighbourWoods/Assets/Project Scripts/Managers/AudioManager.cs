using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Manager.Player;
using EasyEditor;

namespace Manager.Audio
{
    public enum AudioType
    {
        Character,
        CharacterDialogue,
        PlayerDialogue,
        Player,
        SoundEffect,
        Game,
        Music,
    }
    #region AudioManager Class
    public class AudioManager : Singleton<AudioManager>
    {
        AudioFiles[] audioFiles;
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
    [Groups("Base Settings")]
    [System.Serializable]
    public class AudioFiles
    {
        public int audioFileID;
        public AudioClip audioClip;
        public AudioType audioType;
    }
}
