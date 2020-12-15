using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Gardenling
{
    public string name;
    public int strength;
    public int speed;
    public int charisma;
    public Personality persona;
    public Force force;
    public Emotion emotion;

    public void init(string name, int strength, int speed, int charisma, Personality persona, Force force, Emotion emotion)
    {
        this.name = name;
        this.strength = strength;
        this.speed = speed;
        this.charisma = charisma;
        this.persona = persona;
        this.force = force;
        this.emotion = emotion;
    }
}