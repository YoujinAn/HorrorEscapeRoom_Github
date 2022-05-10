using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    [SerializeField]
    Item item;
    [SerializeField]
    int convNum;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(item);
            GameManager.Instance.playerCanControl = false;
            DialogueManager.Instance.StartConversation(convNum);
            Destroy(gameObject);
        }
    }
}
