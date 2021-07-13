using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int attack;
    public int health;
    public string cardDescription;

    public Text nameText;
    public Text costText;
    public Text attackText;
    public Text healthText;
    public Text descriptionText;

    public Sprite thisSprite;
    public Image thatImage;

    public Image frame;

    public bool cardBack;
    public static bool staticCardBack;


    public GameObject Hand;

    public int numberOfCardsInDeck;

    public bool canBeSummon;
    public bool summoned;
    public GameObject battleZone;

    public TurnSystem turnSystem;

    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDatabase.cardList[thisId];
        numberOfCardsInDeck = PlayerDeck.deckSize;

        canBeSummon = false;
        summoned = false;
    }

    // Update is called once per frame
    void Update()
    {

        Hand = GameObject.Find("Hand");
        if(this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }

        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        attack = thisCard[0].attack;
        health = thisCard[0].health;
        cardDescription = thisCard[0].cardDescription;

        thisSprite = thisCard[0].thisImage;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        attackText.text = "" + attack;
        healthText.text = "" + health;
        descriptionText.text = "" + descriptionText;


        thatImage.sprite = thisSprite;

        if(thisCard[0].color == "Red")
        {
            frame.GetComponent<Image>().color = new Color32(242, 110, 92, 255);
        }
        if (thisCard[0].color == "Blue")
        {
            frame.GetComponent<Image>().color = new Color32(66, 135, 245, 255);
        }
        if (thisCard[0].color == "Yellow")
        {
            frame.GetComponent<Image>().color = new Color32(232, 216, 114, 255);
        }
        if (thisCard[0].color == "Purple")
        {
            frame.GetComponent<Image>().color = new Color32(169, 103, 235, 255);
        }

        staticCardBack = cardBack;

        if (this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";

        }
        if (TurnSystem.currentMana >= cost && summoned == false)
        {
            canBeSummon = true;
        }
        else
        {
            canBeSummon = false;
        }

        if (canBeSummon == true)
        {
            gameObject.GetComponent<Draggable>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Draggable>().enabled = false;
        }

        battleZone = GameObject.Find("Zone");

        if (summoned == false && this.transform.parent == battleZone.transform)
        {
            Summon();
        }


    }

    public void Summon()
    {
        TurnSystem.currentMana -= cost;
        summoned = true;
    }

}
