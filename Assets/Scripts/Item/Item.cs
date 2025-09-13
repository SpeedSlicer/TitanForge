using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID;
    public Sprite sprite;
    public ItemType itemType;


    public enum ItemType
    {
        none,
        weapon,
        tool,
    };

    public Item(int id, Sprite texture, ItemType type)
    {
        itemID = id;
        sprite = texture;
        itemType = type;
    }
}
