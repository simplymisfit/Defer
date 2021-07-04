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
        cardList.Add(new Card(0, "None", 0, 0, 0, "None", Resources.Load <Sprite>("1"), "None"));
        cardList.Add(new Card(1, "Elf", 1, 2, 5, "Some elf found in the woods", Resources.Load<Sprite>("1"), "Red"));
        cardList.Add(new Card(2, "Dwarf", 2, 3, 4, "It's a might dwarf card", Resources.Load<Sprite>("1"), "Blue"));
        cardList.Add(new Card(3, "Human", 3, 4, 3, "Just a mere human", Resources.Load<Sprite>("1"), "Yellow"));
        cardList.Add(new Card(4, "Demon", 4, 5, 2, "Powerful demon that leads hell", Resources.Load<Sprite>("1"), "Purple"));
    }
}
