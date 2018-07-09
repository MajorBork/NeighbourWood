using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Stick,
    Bone,
    Frisbee,
    // all the items in the game
}
public class UIManager : Singleton<UIManager>
{
	
	void Start () // Use this for initialization
    {
		
	}
	void Update () // Update is called once per frame
    {
		
	}
    void UpdateItem()
    {
        // replaces inventory icon 
    }
    void AssigningItems()
    {
        // assigns a icon and a scene object to each item
    }
    void UpdateCharacterIcon()
    {

    }
}
