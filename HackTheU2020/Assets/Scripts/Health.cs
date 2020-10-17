using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private GameObject gameHandler;

    public GameObject[] hearts;
    private int health;

    public Sprite fullHeart;
    public Sprite emptyHeart;



    void Start()
    {
        health = hearts.Length;
        gameHandler = GameObject.FindGameObjectWithTag("GameHandler");
    }

    void Update()
    {
        if (health <= 0) {
            gameHandler.SendMessage("gameOver");
        }
    }

    public void takeDamage()
    {
        health--;
        hearts[health].GetComponent<Image>().sprite = emptyHeart;
    }
}
