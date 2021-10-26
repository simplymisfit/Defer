using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public string play;
    public string deck;
    public string collection;
    public string settings;
    public string shop;

    public string menu;

    public AudioSource audioSource;
    public AudioClip click, welcome;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(welcome, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlay()
    {
        SceneManager.LoadScene(play);
        audioSource.PlayOneShot(click, 1f);
    }
    public void LoadDeck()
    {
        SceneManager.LoadScene(deck);
    }
    public void LoadCollection()
    {
        SceneManager.LoadScene(collection);
    }
    public void LoadShop()
    {
        SceneManager.LoadScene(shop);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menu);
    }
}
