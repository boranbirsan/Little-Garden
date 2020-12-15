using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public int count = 0;

    public abstract void Start();

    public abstract void Interact();

    public abstract void ShowTip();
    public abstract void RemoveTip();
}
