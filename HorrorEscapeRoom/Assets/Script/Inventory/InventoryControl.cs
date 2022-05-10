using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    [SerializeField]
    GameObject invPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenInven()
    {
        invPanel.SetActive(true);
        InventoryManager.Instance.InitInventory();

        GameManager.Instance.playerCanControl = false;
    }
    public void CloseInven()
    {
        invPanel.SetActive(false);
        GameManager.Instance.playerCanControl = true;
    }
}
