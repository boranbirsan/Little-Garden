using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Text command;
    private Image image;
    private RectTransform imageRect;

    void Setup(string text, Sprite sprite, float sizeX, float sizeY){
        command.text = text;
        image.sprite = sprite; 
        imageRect.sizeDelta = new Vector2(sizeX, sizeY);
    }

    // Start is called before the first frame update
    void Start(){
        image = GetComponent<Image>();
        imageRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update(){}
}
