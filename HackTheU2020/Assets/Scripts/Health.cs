using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    /// <summary>
    /// reference to the gameHandler to end game when health reaches 0
    /// </summary>
    private GameObject gameHandler;

    // health
    /// <summary>
    /// reference to all of the heart gameObjects in the canvas to change sprites when needed
    /// </summary>
    public GameObject[] hearts;

    /// <summary>
    /// keeps the health of character by keeping track of the amount of full hearts
    /// </summary>
    private int health;

    // sprite references
    /// <summary>
    /// sprite for a full heart
    /// </summary>
    public Sprite fullHeart;

    /// <summary>
    /// sprite reference for an empty heart
    /// </summary>
    public Sprite emptyHeart;

    void Start()
    {
        health = hearts.Length;
        gameHandler = GameObject.FindGameObjectWithTag("GameHandler");
    }

    void Update()
    {
        // check if dead
        if (health <= 0) {
            gameHandler.SendMessage("nextScene");
        }
    }

    /// <summary>
    /// whenever player is hit by an asteroid, decrement the health by 1 and update the UI hearts
    /// </summary>
    public void takeDamage()
    {
        health--;
        hearts[health].GetComponent<Image>().sprite = emptyHeart;
    }
}
