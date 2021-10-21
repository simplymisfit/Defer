using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{
    public GameObject Hand;
    public GameObject It;
    //public int z = 0;
    // Start is called before the first frame update
    void Start()
    {
        Hand = GameObject.Find("Hand");
        //z = 0;
        //if (z == 0) 
        //{ 
            It.transform.SetParent(Hand.transform);
            It.transform.localScale = new Vector3(1.5f, 2.3f, 1.0f);
            It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
            It.transform.eulerAngles = new Vector3(25, 0, 0);
            It.tag = "Untagged";
            //z = 1;
            transform.tag = "Clone";
            transform.tag = "Clone";
            transform.tag = "Clone";
            //}
            //}   

        }

    // Update is called once per frame
    void Update()
    {
        //Dzieki temu nie wywala bledu z indexem
        Hand = GameObject.Find("Hand");
        It.tag = "Untagged";
    }
}
