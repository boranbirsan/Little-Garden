using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : Interactable
{
    public float invPadding = 20f;
    public List<Item> inventory;

    public GameObject chestPanel;
    public GameObject inventoryPanel;
    public GameObject buttonTip;
    
    private GameObject inventoryMenu;
    private GameObject infoMenu;
    
    private bool isOpen;
    private bool showingButton;
    private GameObject currentTip;
    private GameObject playerInv;
    private GameObject currentInv;

    public override void Start(){
        isOpen = false;
        inventoryMenu = GameObject.Find("Inventory Menu");
        infoMenu = GameObject.Find("Info Menu");
        showingButton = false;
    }

    void FixedUpdate(){
        if(currentTip != null){
            // Vector3 tipPos = Camera.main.WorldToScreenPoint(transform.position);
            // tipPos.y += 40f;
            // tipPos.z = 0;
            // currentTip.transform.position = tipPos;
        }
    }

    public override void Interact(){
        bool reversed = false;
        if(isOpen){
            isOpen = false;
            Destroy(currentInv);
            Destroy(playerInv);
            inventoryMenu.SetActive(false);
        }else{
            isOpen = true;
            Vector3 panelPos = Vector3.zero; 
            panelPos = Camera.main.WorldToScreenPoint(transform.position);
            panelPos.z = 0f;

            if(panelPos.x + 235f + 20f > Screen.width){
                panelPos.x = panelPos.x - 235/2 - 20f;
            }else{
                panelPos.x = panelPos.x + 235/2 + 20f;
            }

            if(panelPos.y + 45f > Screen.height){
                panelPos.y = panelPos.y - 85/2 - 20f - 45f;
                reversed = true; 
            }else if(panelPos.y + 85 + 20f > Screen.height){
                panelPos.y = panelPos.y - 85/2 - 20f;
                reversed = true;
            }
            else{
                panelPos.y = panelPos.y + 85/2 + 20f;
                reversed = false;
            }

            inventoryMenu.SetActive(true);
            currentInv = Instantiate(chestPanel, panelPos, Quaternion.identity);
            OpenInventory(panelPos, reversed);
            currentInv.transform.SetParent(inventoryMenu.transform);
        }
        
    }

    public void OpenInventory(Vector3 panelPos, bool reversed){
        Vector3 invPos = panelPos;

        if(reversed){
            invPos.y = panelPos.y + 85/2 + 45/2f;
        }else{
            invPos.y = panelPos.y - 85/2 - 45/2f;
        }

        playerInv = Instantiate(inventoryPanel, invPos, Quaternion.identity);
        playerInv.transform.SetParent(inventoryMenu.transform);
    }

    public override void ShowTip(){
        if(!showingButton){
            Vector3 tipPos = transform.position;
            tipPos.y += 1f;
            tipPos.z = 0;

            count++;
            currentTip = Instantiate(buttonTip, tipPos, Quaternion.identity);
            currentTip.transform.SetParent(infoMenu.transform);

            showingButton = true;
        }
        
    }

    public override void RemoveTip(){
        if(showingButton){
            Destroy(currentTip);
            showingButton = false;
        }
    }
}
