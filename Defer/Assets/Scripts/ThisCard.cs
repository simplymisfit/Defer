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

    public int hurted;
    public int actuallpower;
    public int returnXcards;
    public bool useReturn;
    public static bool UcanReturn;

    public int healXpower;
    public bool canHeal;

    public GameObject EnemyZone;
    public AICardToHand aiCardToHand;

    public bool spell;
    public int damageDealBySpell;
    public bool dealDamage;
    public bool stopDealDamage;


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

        canHeal = true;

        EnemyZone = GameObject.Find("Enemy Zone");
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

        returnXcards = thisCard[0].returnXcards;

        healXpower = thisCard[0].healXpower;


        spell = thisCard[0].spell;
        damageDealBySpell = thisCard[0].damageDealBySpell;




        nameText.text = "" + cardName;
        costText.text = "" + cost;

        actuallpower = attack-hurted;

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

        staticCardBack = cardBack;

        if (this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";

        }
        if (TurnSystem.currentMana >= cost && summoned == false  && beInGraveyard == false && TurnSystem.isYourTurn == true && TurnSystem.protectStart == false)
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
        if(targeting==true && onlyThisCardAttack == true)
        {
            Attack();
        }

        if(canBeSummon == true || UcanReturn == true && beInGraveyard == true)
        {
            summonBorder.SetActive(true);
        }
        else
        {
            summonBorder.SetActive(false);
        }
        if (actuallpower <= 0 && spell == false)
        {
            Destroy();
        }
        if (returnXcards > 0 && summoned == true && useReturn == false && TurnSystem.isYourTurn == true)
        {
            Return(returnXcards);
            useReturn = true;
        }
        if(TurnSystem.isYourTurn == false)
        {
            UcanReturn = false;
        }

        if(canHeal == true && summoned == true)
        {
            Heal();
            canHeal = false;
        }

        if(damageDealBySpell > 0)
        {
            dealDamage = true;
        }
        if(dealDamage == true && this.transform.parent == battleZone.transform)
        {
            attackBorder.SetActive(true);
        }
        else
        {
            attackBorder.SetActive(false);
        }
        if(dealDamage == this.transform.parent == battleZone.transform)
        {
            dealxDamage(damageDealBySpell);
        }
        if(stopDealDamage == true)
        {
            attackBorder.SetActive(false);
            dealDamage = false;
        }
        if(this.transform.parent == battleZone.transform && spell == true && dealDamage == false)
        {
            Destroy();
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
            }
            else
            {
                foreach (Transform child in EnemyZone.transform)
                {
                    if (child.GetComponent<AICardToHand>().isTarget == true)
                    {
                        child.GetComponent<AICardToHand>().hurted = attack;
                        hurted = child.GetComponent<AICardToHand>().attack;
                        cantAttack = true;
                    }
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
            /*            this.transform.SetParent(Graveyard.transform);
                        canBeDestroyed = false;
                        summoned = false;
                        beInGraveyard = true;
                        hurted = 0;*/

            for (int i = 0; i < 40; i++)
            {
                if (Graveyard.GetComponent<GraveyardScript>().graveyard[i].id == 0)
                {
                    Graveyard.GetComponent<GraveyardScript>().graveyard[i] = CardDatabase.cardList[id];

                    canBeDestroyed = false;
                    summoned = false;
                    beInGraveyard = true;

                    hurted = 0;

                    transform.SetParent(Graveyard.transform);

                    transform.position = new Vector3(transform.position.x + 4000, transform.position.y, transform.position.z);//Hidden outside of canvas, but not disabled

                    break;
                }
            }
        }
    }
    public void Return(int x)
    {
        for (int i = 0; i <= x; i++)
        {
            ReturnCard();
        }
    } 
    public void ReturnCard()
    {
        UcanReturn = true;
    }
    public void ReturnThis()
    {
        if(beInGraveyard == true && UcanReturn == true)
        {
            this.transform.SetParent(Hand.transform);
            UcanReturn = false;
            beInGraveyard = false;
            summonigSickness = true;
        }
    }

    public void Heal()
    {
        PlayerHp.staticHp += healXpower;
    }

    public void dealxDamage(int x)
    {
        if(Target != null)
        {
            if(Target == Enemy && stopDealDamage == false && Input.GetMouseButton(0))
            {
                EnemyHp.staticHp -= damageDealBySpell;
                stopDealDamage = true;
            }
        }
        else
        {
            foreach (Transform child in EnemyZone.transform)
            {
                if (child.GetComponent<AICardToHand>().isTarget == true)
                {
                    child.GetComponent<AICardToHand>().hurted += damageDealBySpell;
                    stopDealDamage = true;

                }
            }
        }
    }

}



