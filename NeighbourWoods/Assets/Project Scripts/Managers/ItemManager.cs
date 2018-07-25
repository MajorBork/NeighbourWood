using System.Collections;
using System.Collections.Generic;
using EasyEditor;
using UnityEngine.UI;
using UnityEngine;
public enum ItemObject
{
    Stick,
    Ball,
}
namespace Manager.Item
{
    public class ItemManager : MonoBehaviour
    {
        public Items[] item;
    }

    [Groups("Base Settings")]
    [System.Serializable]
    public class Items
    {
        public int itemID;
        public ItemObject item;
        public Image itemIcon;
    }
}
