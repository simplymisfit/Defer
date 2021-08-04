using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public Text goldText;
    public int gold;


    // Start is called before the first frame update
    void Start()
    {
        gold = 750;

        gold = PlayerPrefs.GetInt("gold", 750);
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Your Gold: " + gold + " $";
    }

    public void BuyPack()
    {
        gold -= 100;

        PlayerPrefs.SetInt("gold", gold);

        SceneManager.LoadScene("OpenPack");
    }
}
