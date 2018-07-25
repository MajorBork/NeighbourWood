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
namespace Manager.Character
{
    public class CharacterManager : MonoBehaviour
    {
        public Characters[] characters;
    }
    [Groups("Base Settings")]
    [System.Serializable]
    public class Characters
    {
        public int characterID;
        public string characterName;
        public CharaterType characterType;
        public Tasks tasks;
        public int basePlayerLoyalty;
        public int baseHumanLoyalty;
        public Text icon;
    }
}
