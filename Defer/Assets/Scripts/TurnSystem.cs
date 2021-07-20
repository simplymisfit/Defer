using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public static bool isYourTurn;
    public int yourTurn;
    public int yourOpponentTurn;
    public Text turnText;

    public static int maxMana;
    public static int currentMana;
    public Text manaText;

    public static bool startTurn;

    public int random;


    // Start is called before the first frame update
    void Start()
    {
        /*        isYourTurn = true;
                yourTurn = 1;
                yourOpponentTurn = 0;

                maxMana = 1;
                currentMana = 1;

                startTurn = false;*/

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (isYourTurn == true)
        {
            turnText.text = "Your turn";
        }
        else
        {
            turnText.text = "Opponent turn";
        }

        manaText.text = currentMana + "/" + maxMana;
    }

    public void EndYourTurn()
    {
        isYourTurn = false;
        yourOpponentTurn += 1;
    }

    public void EndYourOpponentTurn()
    {
        isYourTurn = true;
        yourTurn += 1;

        maxMana += 1;
        currentMana = maxMana;

        startTurn = true;
    }
    public void StartGame()
    {
        random = Random.Range(0, 2);
        if (random == 0)
        {
            isYourTurn = true;
            yourTurn = 1;
            yourOpponentTurn = 0;

            maxMana = 1;
            currentMana = 1;

            startTurn = false;
        }
        if (random == 1)
        {
            isYourTurn = false;
            yourTurn = 0;
            yourOpponentTurn = 1;

            maxMana = 0;
            currentMana = 0;

        }
    }
}
