using System.Collections;
using System.Collections.Generic;
using EasyEditor;
using UnityEngine.UI;
using UnityEngine;
namespace Manager.Item
{
    #region ItemType Enums
    public enum ItemType
    {
        Accessory,
        ClueObject,
        FetchObject,
        FoodObject,
        QuestObject,
    }
    #endregion
    #region ItemManager Class
    public class ItemManager : Singleton<ItemManager>
    {
        public Items[] item;
    }
    #endregion
    #region Items Class
    [Groups("Base Settings")]
    [System.Serializable]
    public class Items
    {
        public int itemID;
        public string itemName;
        public ItemType item;
        public Image itemIcon;
        public GameObject itemObject;
    }
    #endregion 
}
