using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.Item;
using Manager.UI;
using DG.Tweening;

namespace Manager.Inventory 
{
    public enum InventoryVis
    {
        IS_LOOKING_IN_INVENTORY,
        NOT_LOOKING_IN_INVENTORY,
    }
    public class InventoryManager : Singleton<InventoryManager>
    {
        public Items iteminInventory;
        public UIManager gameManagerUI;
        public bool inventoryShowing;
        void Start() // Use this for initialization
        {
            inventoryShowing = false;
            gameManagerUI.inventoryCanvas.alpha = 0;
        }
        void Update() // Update is called once per frame
        {
            
        }
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
    }
}
