using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    public GameObject CardOne;
    public GameObject CardTwo;
    public GameObject CardThree;
    public GameObject CardFour;

    public int x;

    public int[] HowManyCards;

    public Text CardOneText;
    public Text CardTwoText;
    public Text CardThreeText;
    public Text CardFourText;

    // Start is called before the first frame update
    void Start()
    {
        x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CardOne.GetComponent<CardInCollection>().thisId = x;
        CardTwo.GetComponent<CardInCollection>().thisId = x+1;
        CardThree.GetComponent<CardInCollection>().thisId = x+2;
        CardFour.GetComponent<CardInCollection>().thisId = x+3;

        CardOneText.text = "x" + HowManyCards[x];
        CardTwoText.text = "x" + HowManyCards[x+1];
        CardThreeText.text = "x" + HowManyCards[x+2];
        CardFourText.text = "x" + HowManyCards[x+3];

        if (CardOneText.text == "x0")
        {
            CardOne.GetComponent<CardInCollection>().beGrey = true;
        }
        else
        {
            CardOne.GetComponent<CardInCollection>().beGrey = false;
        }

        if (CardTwoText.text == "x0")
        {
            CardTwo.GetComponent<CardInCollection>().beGrey = true;
        }
        else
        {
            CardTwo.GetComponent<CardInCollection>().beGrey = false;
        }

        if (CardThreeText.text == "x0")
        {
            CardThree.GetComponent<CardInCollection>().beGrey = true;
        }
        else
        {
            CardThree.GetComponent<CardInCollection>().beGrey = false;
        }

        if (CardFourText.text == "x0")
        {
            CardFour.GetComponent<CardInCollection>().beGrey = true;
        }
        else
        {
            CardFour.GetComponent<CardInCollection>().beGrey = false;
        }
    }
    public void Left()
    {
        x -= 4;
    }

    public void Right()
    {
        x += 4;
    }

}
