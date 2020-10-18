using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    // for interaction with player instance variables and position
    private GameObject player;

    //find new position
    private float X_OFFSET;
    private float Y_OFFSET;
    private Vector3 newPos;

    void Start()
    {
        X_OFFSET = 15;
        Y_OFFSET = 10;
        newPos.z = 1;

        player = GameObject.FindGameObjectWithTag("Player");

        teleport();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            player.SendMessage("refillGas");
            teleport();
        }


    }

    public void teleport() {
        newPos.x = player.GetComponent<Transform>().position.x + (Random.Range(-X_OFFSET,X_OFFSET));
        newPos.y = player.GetComponent<Transform>().position.y + (Random.Range(-Y_OFFSET, Y_OFFSET));

        transform.position = newPos;
    }

    void Update()
    {

    }
}
