using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    public int itemIdx;
    public Sprite itemSprite;
    public string itemName;
    public string ItemDesc;
    public bool isUsable;

}
