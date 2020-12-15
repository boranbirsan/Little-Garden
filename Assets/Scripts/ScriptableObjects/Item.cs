using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    protected string itemName;
    protected string itemDescription;
    protected bool usable;
    public Sprite itemSprite;

    protected Item(string name, string desc, bool usable){
        this.itemName = name;
        this.itemDescription = itemDescription;
        this.usable = usable;
    }

    public abstract void Use();
}
