using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private Transform player;
    private GameObject spawner;

    private float distanceFromX;
    private float distanceFromY;
    private float distanceFrom;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    void Update()
    {
        distanceFromX = transform.position.x - player.position.x;
        distanceFromY = transform.position.y - player.position.y;

        distanceFrom = Mathf.Sqrt(Mathf.Pow(distanceFromX, 2) + Mathf.Pow(distanceFromY, 2));

        if (Mathf.Abs(distanceFrom) > 25) {
            Destroy(gameObject);
            spawner.SendMessage("decrementStars");
        }
    }
}
