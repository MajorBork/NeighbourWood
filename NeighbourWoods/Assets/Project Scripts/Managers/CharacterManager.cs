using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Manager.Task;
using EasyEditor;
namespace Manager.Character
{
    #region CharacterID Enum
    public enum CharacterID
    {
        Shobe,
        ForestUnicorn,
        ForestSpirit,
        Leia,
        Oscar,
        ConeDog,
        Deer,
        Muffles,
        Keg,
        TheStrays,
        Bundy,
        Milly,
        Midnight,
        Ginger,
        Mishka,
        BullyDog,
        Chickens,
        Familliar,
        Komondor,
        TheColony,
        MurphyCallie,
        FrangelinaFrankenface,
        Gingie,
        Snowball,
        Archie,
        TheMurder,
        Ebony,
        Roger,
        MotherDuck,
        MotherCat,
        TheTrio,
        Squirrel,
        TheFox,
        Owner,
        Witch,
        Children,
        Mole,
        YoungTurtles,
        Kelpie, 
    }
    #endregion
    #region CharacterGender Enum
    public enum CharacterGender
    {
        Male,
        Female,
        Unknown,
        Mixed,
    }
    #endregion
    #region CharacterType Enum
    public enum CharaterType
    {
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
    }
    #endregion
    #region CharacterBreed Enum
    public enum CharacterBreed
    {
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
        Chickens,
        BorderCollies,
        AmericanShorthairBreed,
        GingerShorthair,
        BlackDomesticShorthair,
        Labrador,
        ShetlandSheepdog,
        Unknown,
    }
    #endregion
    #region CharacterManager Class
    public class CharacterManager : Singleton<CharacterManager>
    {
        public Characters[] characters;
    }
    #endregion
    #region Characters Class
    [Groups("Base Settings")]
    [System.Serializable]
    public class Characters
    {
        public CharacterID characterName;
        public CharacterGender characterGender;
        public CharaterType characterType;
        public CharacterBreed characterBreed;
        public int basePlayerLoyalty;
        public int baseHumanLoyalty;
        public string task;
        public string dialogueID;
        public Image icon;
    }
    #endregion
}