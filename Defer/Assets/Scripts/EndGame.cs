using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Text victoryText;
    public GameObject textObject;

    public GameObject money;
    public bool gotMoney;

    public string menu;
    public bool protect;

    // Start is called before the first frame update
    void Start()
    {
        textObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHp.staticHp <= 0)
        {
            textObject.SetActive(true);
            victoryText.text = "You lose";

            if (gotMoney == false)
            {
                money.GetComponent<Shop>().gold += 10;
                gotMoney = true;
            }

            if (protect == false)
            {
                StartCoroutine(ReturnToMenu());
                protect = true;
            }
        }
        if (EnemyHp.staticHp <= 0)
        {
            textObject.SetActive(true);
            victoryText.text = "Victory";

            if (gotMoney == false)
            {
                money.GetComponent<Shop>().gold += 50;
                gotMoney = true;
            }

            if (protect == false)
            {
                StartCoroutine(ReturnToMenu());
                protect = true;
            }

        }
    }

    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(menu);
    }

}
