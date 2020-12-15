using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public InventoryList inventory;

    // Start is called before the first frame update
    void Start()
    {
        if(inventory == null){
            inventory = ScriptableObject.CreateInstance("InventoryList") as InventoryList;
        }else{
            for(int i = 0; i < inventory.itemList.Count; i++){
            InventorySlot inv = this.gameObject.transform.GetChild(i).GetComponent<InventorySlot>();
            
            inv.Setup(inventory.itemList[i], this);
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(Item item)
    {
        inventory.itemList.Add(item);
    }

    public void Remove(){

    }
}
