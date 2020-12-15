using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Relation
{
    public GameObject character;
    public float relation;
    public ArrayList interactions;

    public void init(GameObject character, float relation)
    {
        this.character= character;
        this.relation = relation;
        interactions = new ArrayList();
    }

    public void addInteractions(Actions act, float preference)
    {
        Interaction interaction = new Interaction();
        interaction.init(act, preference);
        interactions.Add(interaction);
    }

    public void setRealation(float relation)
    {
        this.relation = relation;
    }
}
