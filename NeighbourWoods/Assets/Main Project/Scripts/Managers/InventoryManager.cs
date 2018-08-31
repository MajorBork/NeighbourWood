using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.Item;
using Manager.UI;
using DG.Tweening;
using TMPro;

namespace Manager.Inventory 
{
    #region InventoryVis Enum
    public enum InventoryVis
    {
        IS_LOOKING_IN_INVENTORY,
        NOT_LOOKING_IN_INVENTORY,
    }
    #endregion
    #region InventoryManager Class
    public class InventoryManager : Singleton<InventoryManager>
    {
        public Items iteminInventory;
        public TextMeshProUGUI FoodText;
        public UIManager gameManagerUI;
        public GameObject itemObject;
        public bool inventoryShowing;
        public bool hasItem;
        public int food;
        void Start() // Use this for initialization
        {
            inventoryShowing = false;
            gameManagerUI.inventoryCanvas.alpha = 0;
        }
        void Update() // Update is called once per frame
        {
            
        }
        #region Food Methods
        public void AddFood(int food)
        {
            food++;

        }
        public void MinusFood(int food)
        {
            food--;
        }
        #endregion
        public void PickupItem(GameObject itemObject)
        {

        }
        #region Inventory Event Methods
        void OnEnable()
        {
            GameEvents.OnInventoryVisChange += OnShowInventoryChange;
        }
        void OnDisable()
        {
            GameEvents.OnInventoryVisChange -= OnShowInventoryChange;
        }
        void OnShowInventoryChange(bool inventoryVis)
        {
            if (inventoryVis)
            {
                gameManagerUI.inventoryCanvas.DOFade(1, 0.3f);
                gameManagerUI.inventoryCanvas.interactable = true;
                gameManagerUI.inventoryCanvas.blocksRaycasts = true;
            }
            else
            {
                gameManagerUI.inventoryCanvas.DOFade(0, 0.3f);
                gameManagerUI.inventoryCanvas.interactable = false;
                gameManagerUI.inventoryCanvas.blocksRaycasts = false;
            }
        }
        #endregion
    }
    #endregion
}
