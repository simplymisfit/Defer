using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AICardToHand : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();


    public static List<Card> cardsInHandStatic = new List<Card>();
    public List<Card> cardsInHand = new List<Card>();
    public static int cardsInHandNumber;


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

    public static int DrawX;
    public int drawXcards;
    public int addXmaxMana;

    public int hurted;
    public int actuallpower;
    public int returnXcards;

    public GameObject Hand;
    public int z = 0;
    public GameObject It;

    public int numberOfCardsInDeck;
    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDatabase.cardList[thisId];
        Hand = GameObject.Find("Enemy Hand");

        z = 0;
        numberOfCardsInDeck = AI.deckSize;

    }

    // Update is called once per frame
    void Update()
    {
        if(z == 0)
        {
            It.transform.SetParent(Hand.transform);
            It.transform.localScale = new Vector3(0.7f, 1.1f, 1.0f);
            It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
            It.transform.eulerAngles = new Vector3(25, 0, 0);
            z = 1;
        }
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        attack = thisCard[0].attack;
        health = thisCard[0].health;
        cardDescription = thisCard[0].cardDescription;

        thisSprite = thisCard[0].thisImage;

        drawXcards = thisCard[0].drawXcards;
        addXmaxMana = thisCard[0].addXmaxMana;

        returnXcards = thisCard[0].returnXcards;

        //healXpower = thisCard[0].healXpower;

        nameText.text = "" + cardName;
        costText.text = "" + cost;

        actuallpower = attack - hurted;

        attackText.text = "" + actuallpower;
        healthText.text = "" + health;
        descriptionText.text = "" + cardDescription;



        thatImage.sprite = thisSprite;

        if (thisCard[0].color == "Red")
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

        if(this.tag == "Clone")
        {
            thisCard[0] = AI.staticEnemyDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            AI.deckSize -= 1;
            this.tag = "Untagged";
        }

    }
}
