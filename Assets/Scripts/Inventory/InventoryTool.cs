using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Tool")]
public class InventoryTool : Item
{
    public InventoryTool(string name, string description) : base(name, description, true)
    {

    }

    public override void Use(){
        
    }
}
