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

    public static int drawX;
    public int drawXcards;
    public int addXmaxMana;


    public GameObject attackBorder;
    public GameObject Target;
    public GameObject Enemy;
    public bool summonigSickness;
    public bool cantAttack;
    public bool canAttack;
    public static bool staticTargeting;
    public static bool staticTargetingEnemy;
    public bool targeting;
    public bool targetingEnemy;
    public bool onlyThisCardAttack;

    public GameObject summonBorder;

    public bool canBeDestroyed;
    public GameObject Graveyard;
    public bool beInGraveyard;





    //public TurnSystem turnSystem;

    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDatabase.cardList[thisId];
        numberOfCardsInDeck = PlayerDeck.deckSize;

        canBeSummon = false;
        summoned = false;

        drawX = 0;

        canAttack = false;
        summonigSickness = true;

        Enemy = GameObject.Find("EnemyHP");
        targeting = false;
        targetingEnemy = false;

    }

    // Update is called once per frame
    void Update()
    {

        Hand = GameObject.Find("Hand");
        if (this.transform.parent == Hand.transform.parent)
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

        drawXcards = thisCard[0].drawXcards;
        addXmaxMana = thisCard[0].addXmaxMana;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        attackText.text = "" + attack;
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

        staticCardBack = cardBack;

        if (this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";

        }
        if (TurnSystem.currentMana >= cost && summoned == false /* nowe */ && beInGraveyard == false)
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

        if(canAttack == true /* nowe */ && beInGraveyard == false)
        {
            attackBorder.SetActive(true);
        }
        else
        {
            attackBorder.SetActive(false);
        }
        if(TurnSystem.isYourTurn == false && summoned == true)
        {
            summonigSickness = false;
            cantAttack = false;
        }
        if(TurnSystem.isYourTurn == true && summonigSickness == false && cantAttack == false)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
        targeting = staticTargeting;
        targetingEnemy = staticTargetingEnemy;
        if(targetingEnemy == true)
        {
            Target = Enemy;
        }
        else
        {
            Target = null;
        }
        if(targeting==true && targetingEnemy == true && onlyThisCardAttack == true)
        {
            Attack();
        }

        if(canBeSummon == true)
        {
            summonBorder.SetActive(true);
        }
        else
        {
            summonBorder.SetActive(false);
        }
    }

    public void Summon()
    {
        TurnSystem.currentMana -= cost;
        summoned = true;

        MaxMana(addXmaxMana);
        drawX = drawXcards;
    }

    public void MaxMana(int x)
    {
        TurnSystem.maxMana += x;

    }
    public void Attack()
    {
        if (canAttack == true /* nowe */ && summoned == true)
        {
            if (Target != null)
            {
                if (Target == Enemy)
                {
                    EnemyHp.staticHp -= attack;
                    targeting = false;
                    cantAttack = true;
                }   
                if (Target.name == "CardToHand(Clone)")
                {
                    canAttack = true;
                }
            }
        }
    }

    public void UntargetEnemy()
    {
        staticTargetingEnemy = false;
    }
    public void TargetEnemy()
    {
        staticTargetingEnemy = true;
    }
    public void StartAttack()
    {
        staticTargeting = true;
    }
    public void StopAttack()
    {
        staticTargeting = false;
    }
    public void OneCardAttack()
    {
        onlyThisCardAttack = true;
    }
    public void OneCardAttackStop()
    {
        onlyThisCardAttack = false;
    }

    public void Destroy()
    {
        Graveyard = GameObject.Find("My Graveyard");
        canBeDestroyed = true; //just a test
        if(canBeDestroyed == true)
        {
            this.transform.SetParent(Graveyard.transform);
            canBeDestroyed = false;
            summoned = false;
            beInGraveyard = true;
        }
    }
}



