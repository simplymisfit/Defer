using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToHeaven : MonoBehaviour
{
    public GameObject background;
    public float x;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        x = 550;
        background = GameObject.Find("Background");
        this.transform.SetParent(background.transform);
        this.transform.localScale = new Vector3(0.6f, 0.6f, 1);
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Defer")

        this.transform.position = new Vector3(transform.position.x, x+= 500 * Time.deltaTime, transform.position.z);
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);
        Destroy(obj);
    }
}
