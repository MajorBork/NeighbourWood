using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
using Manager.Inventory;

public class BananaQuestObject : MonoBehaviour
{
    public string questTitle;
    private string inventoryMethodName = "PickupItem";
    public Image bananaObject;
    public QuestState newQuestState = QuestState.Success;
    public string message;
    private InventoryManager inventoryManager;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestLog.SetQuestState(questTitle, newQuestState);
            DialogueManager.ShowAlert(message);
            inventoryManager.SendMessage(inventoryMethodName, bananaObject);
            this.gameObject.SetActive(false);
        }
    }
}
