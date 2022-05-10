using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    bool isSelect;
    [SerializeField]
    bool isItemFull;
    [SerializeField]
    Image selectImage;
    [SerializeField]
    Image UISelectImage;
    [SerializeField]
    Text UIDesc;

    void Start()
    {

    }

    void Update()
    {
        if(isSelect)
        {
            selectImage.enabled = true;
        }
        else
        {
            selectImage.enabled = false;
        }
    }

    public void InsertItem()
    {

    }

    public void Deselect()
    {
        isSelect = false;
        selectImage.enabled = false;
    }

    public void Select()
    {
        isSelect = true;
        selectImage.enabled = true;
    }

    public bool GetIsItemFull()
    {
        return isItemFull;
    }
    public void SetIsItemFull(bool _full)
    {
        isItemFull = _full;
    }
    public bool GetIsSelected()
    {
        return isSelect;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        InventoryManager.Instance.InitInventory();
        if(isItemFull)
        {
            Select();
            InventoryManager.Instance.CheckCurItem();
            UISelectImage.sprite = InventoryManager.Instance.curItem.itemSprite;
            UIDesc.text = InventoryManager.Instance.curItem.ItemDesc;
        }
    }
}
