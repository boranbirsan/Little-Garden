using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class InventoryItem : Item
{
    public int count;

    public InventoryItem(string name, string description, bool usable, int count) : base(name, description, usable)
    {
        this.count = count;
    }

    public override void Use(){}
}
