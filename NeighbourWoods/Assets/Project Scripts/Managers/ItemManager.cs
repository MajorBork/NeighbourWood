using System.Collections;
using System.Collections.Generic;
using EasyEditor;
using UnityEngine.UI;
using UnityEngine;
public enum ItemType
{
    #region ItemType Enums
    Accessory,
    ClueObject,
    FetchObject,
    FoodObject,
    QuestObject,
    #endregion
}
namespace Manager.Item
{
    #region ItemManager Class
    public class ItemManager : MonoBehaviour
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
