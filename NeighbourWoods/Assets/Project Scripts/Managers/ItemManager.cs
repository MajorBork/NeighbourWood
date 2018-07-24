using System.Collections;
using System.Collections.Generic;
using EasyEditor;
using UnityEngine.UI;
using UnityEngine;
public enum Item
{
    Stick,
    Ball,
}

public class ItemManager : MonoBehaviour
{
    public Items[] item;

}

[Groups("Base Settings")]
[System.Serializable]
public class Items
{
    public int itemID;
    public Item item;
    public Text itemIcon;
}
