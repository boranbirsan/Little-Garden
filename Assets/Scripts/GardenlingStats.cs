using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GardenlingStats
{
    public string name;
    public float health;
    public float strength;
    public float speed;
    public float agility;
    public float charisma;

    public void init(string name, float health, float strength, float speed, float agility, float charisma)
    {
        this.name = name;
        this.health = health;
        this.strength = strength;
        this.speed = speed;
        this.agility = agility;
        this.charisma = charisma;
    }

    public void addHealth(float health){
        this.health += health;
    }

    public void addStrength(float strength){
        this.strength += strength;
    }

    public void addSpeed(float speed){
        this.speed += speed;
    }

    public void addAgility(float agility){
        this.agility += agility;
    }

    public void addCharisma(float charisma){
        this.charisma += charisma;
    }

    public void removeHealth(float health){
        this.health -= health;
    }

    public void removeStrength(float strength){
        this.strength -= strength;
    }

    public void removeSpeed(float speed){
        this.speed -= speed;
    }

    public void removeAgility(float agility){
        this.agility -= agility;
    }

    public void removeCharisma(float charisma){
        this.charisma -= charisma;
    }
}