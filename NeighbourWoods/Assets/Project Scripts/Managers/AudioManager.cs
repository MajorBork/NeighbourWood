using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    public float volume;
    public static bool mute;

    //Subscribes to our game events
    void OnEnable()
    {
        GameEvents.OnVisionChange += OnVisionChange;
    }
    //Unsubscribes to our game events
    void OnDisable()
    {
        GameEvents.OnVisionChange -= OnVisionChange;
    }
    void OnVisionChange(Vision vision)
    {
        Debug.Log("DOG SOUND");

    }
}
