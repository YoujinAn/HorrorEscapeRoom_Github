using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    #region singleton
    private static InventoryManager instance = null;


    private void Awake()
    {
        //Cursor.visible = false;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static InventoryManager Instance => instance == null ? null : instance;

    #endregion

    public List<Item> invItems;
    public List<Slot> slots;
    public Item curItem;

    void Start()
    {
        InitInventory();
    }

    public void AddItem(Item _item)
    {
        invItems.Add(_item);
        GameManager.Instance.invItemIdxList.Add(_item.itemIdx);
        InitInventory();
    }

    public void DeleteItem(Item _item)
    {

    }

    public void CheckCurItem()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if(slots[i].GetIsSelected())
            {
                curItem = invItems[i];
            }
        }
    }

    public void InitInventory()
    {
        for(int i = 0; i < slots.Count; i++)
        {
            slots[i].Deselect();
            if (invItems.Count > i)
            {
                slots[i].GetComponent<Image>().sprite = invItems[i].itemSprite;
                slots[i].SetIsItemFull(true);
            }
        }
    }
}
