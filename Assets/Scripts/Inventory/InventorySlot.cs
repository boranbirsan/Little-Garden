using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("Image to change")]
    [SerializeField] private Image itemImage;
    [SerializeField] private GameObject child;

    [Header("Variables from the item")]
    public Sprite itemSprite;
    public Item thisItem;
    public InventoryManager thisManager;

    public void Setup(Item newItem, InventoryManager newManager){
        thisItem = newItem;
        thisManager = newManager;

        if(thisItem){
            itemImage.sprite = thisItem.itemSprite;
            child.SetActive(true);
        }
    }

    public void Remove(){
        itemImage.sprite = null;
        thisItem = null;
        itemSprite = null;
        thisManager = null;
        child.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
