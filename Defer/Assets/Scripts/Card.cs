using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Card
{
    public int id;
    public string cardName;
    public int cost;
    public int attack;
    public int health;
    public string cardDescription;

    
    public Sprite thisImage;

    public string color;

    public Card() { }

    public Card(int Id, string CardName, int Cost, int Attack, int Health, string CardDescription, Sprite ThisImage, string Color)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        attack = Attack;
        health = Health;
        cardDescription = CardDescription;

        thisImage = ThisImage;

        color = Color;
    }
}
