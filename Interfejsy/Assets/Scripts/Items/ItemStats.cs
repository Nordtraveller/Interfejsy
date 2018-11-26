using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Stats", order = 1)]
public class ItemStats : ScriptableObject
{
    public Sprite icon;

    public int armor = 0;
    public int damage = 0;
    public itemType type = itemType.None;
    public string itemName;
    public string itemDescription;
}
