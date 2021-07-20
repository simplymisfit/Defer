using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    //stworzenie obiektu listy kart
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        //dodanie nowych kart do listy
        cardList.Add(new Card(0, "None", 0, 0, 0, "None", Resources.Load <Sprite>("1"), "None",0,0,0,0));
        cardList.Add(new Card(1, "Elf", 1, 200, 5, "Draw 1 card", Resources.Load<Sprite>("1"), "Red", 2, 0, 0, 0));
        cardList.Add(new Card(2, "Dwarf", 2, 300, 4, "Add 1 max mana", Resources.Load<Sprite>("1"), "Blue", 0, 1, 0, 0));
        cardList.Add(new Card(3, "Human", 3, 400, 3, "Add 3 max mana", Resources.Load<Sprite>("1"), "Yellow", 0, 3, 0, 0));
        cardList.Add(new Card(4, "Demon", 1, 500, 2, "Return 1 Card from graveyard", Resources.Load<Sprite>("1"), "Purple", 0, 0,1, 0));
        cardList.Add(new Card(5, "Lifestealer", 1, 500, 2, "Heal 1000", Resources.Load<Sprite>("1"), "Green", 0, 0, 1, 1000));
    }
}
