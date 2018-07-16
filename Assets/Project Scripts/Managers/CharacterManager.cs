using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using EasyEditor;

public enum CharaterType
{
    Dog,
    Cat,
    Fox,
}

public class CharacterManager : MonoBehaviour
{
    public Character[] CharacterList;
}
[Groups("Base Settings")]
[System.Serializable]
public class Character
{
    public int characterID;
    public string characterName;
    public CharaterType characterType;
    public Tasks tasks;
    public int basePlayerLoyalty;
    public int baseHumanLoyalty;
    public Text icon;
}
