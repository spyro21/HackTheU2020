using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private GameObject player;
    private GameObject spawner;

    private float distanceFromX;
    private float distanceFromY;  

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    void Update()
    {
        distanceFromX = player.transform.position.x - transform.position.x;
        distanceFromY = player.transform.position.y - transform.position.y;

        if (distanceFromX > 20 || distanceFromY > 15) {
            Destroy(gameObject);
            spawner.SendMessage("DecrementStars");
        }
    }
}
