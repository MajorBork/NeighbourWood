using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Level
{
    Day,
    Time,
}

public class LevelManager : Singleton<LevelManager>
{
    public int currentTime;
    public int maxtask;
	void Start () // Use this for initialization
    {
		
	}
	void Update () // Update is called once per frame
    {
		
	}
    void UpdateTime() // updates our time to the next increment 
    {
        // if increment > max add 1 to day
        // resets increment 
    }
}
