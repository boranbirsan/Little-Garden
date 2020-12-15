using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Interaction
{
    public Actions act;
    public float preference;

    public void init(Actions act, float preference)
    {
        this.act = act;
        this.preference = preference;
    }

    public void setPref(float preference)
    {
        this.preference = preference;
    }
}
