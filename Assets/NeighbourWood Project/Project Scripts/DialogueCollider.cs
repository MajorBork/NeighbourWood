using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCollider : MonoBehaviour
{
    public GameObject dialogueManager;
    public Text name;
    public Text dialogueBox;
    public Text startConversationText;
    public Text continuetext;
    public Collider dialoguecol;
	void Start () // Use this for initialization
    {
		
	}
	void Update () // Update is called once per frame
    {
        //dialoguecol = GameObject.GetComponent<BoxCollider>();
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            name.enabled = true;
            dialogueBox.enabled = true;
            startConversationText.enabled = true;
            continuetext.enabled = true;
            dialogueManager.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
