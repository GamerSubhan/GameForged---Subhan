using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Treasure,
        VitalityBelt,
    }

    public ItemType itemType;
    public int itemAmount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Treasure: return ItemAssets.Instace.treasure;
            case ItemType.VitalityBelt: return ItemAssets.Instace.vitalityBell;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Treasure:
                return true;
            case ItemType.VitalityBelt:

                return false;
        }
    }
}