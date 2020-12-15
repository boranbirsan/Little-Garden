using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item List", menuName = "Inventory/List")]
public class InventoryList : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}
