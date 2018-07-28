using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using EasyEditor;
public enum CharacterGender
{
    #region CharacterGender Enums
    Male,
    Female,
    Unknown,
    Mixed,
    #endregion
}
public enum CharaterType
{
    #region CharacterType Enums
    Dog,
    Cat,
    Fox,
    Rabbit,
    Crow,
    Duck,
    Squirrel,
    Chickens,
    Deer,
    ForestSpirit,
    RedFox,
    Unknown,
    #endregion
}
public enum CharacterBreed
{
    #region CharacterBreed Enums 
    ShibaInu,
    Unicorn,
    Mutt,
    Corgi,
    Pug,
    Staffy,
    GreatDane,
    BlackDwarfLop,
    Dward,
    BlackBritishShorthair,
    Chihuahua,
    Bengal,
    Komondor,
    BorderCollies,
    AmericanShorthairBreed,
    GingerShorthair,
    BlackDomesticShorthair,
    Labrador,
    ShetlandSheepdog,
    Unknown,
    #endregion
}
namespace Manager.Character
{
    
    #region CharacterManager Class
    public class CharacterManager : MonoBehaviour
    {
        public Characters[] characters;
    }
    #endregion
    #region Characters Class
    [Groups("Base Settings")]
    [System.Serializable]
    public class Characters
    {
        public int characterID;
        public string characterName;
        public CharacterGender characterGender;
        public CharaterType characterType;
        public CharacterBreed characterBreed;
        public int basePlayerLoyalty;
        public int baseHumanLoyalty;
        public Tasks tasks;
        public Image icon;
    }
    #endregion
}
