using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    /// <summary>
    /// player reference that is used to refill fuel when player triggers collider, and find a new position for teleporting
    /// </summary>
    private GameObject player;

    // find new position
    /// <summary>
    /// x variable that determines the next x location of gas (-X_OFFSET, X_OFFSET) 
    /// </summary>
    private float X_OFFSET;

    /// <summary>
    /// y variable that determines the next y location of gas (-Y_OFFSET, Y_OFFSET) 
    /// </summary>
    private float Y_OFFSET;

    /// <summary>
    /// new position of the gas canister when player triggers collider
    /// </summary>
    private Vector3 newPos;

    void Start()
    {
        X_OFFSET = 15;
        Y_OFFSET = 10;
        newPos.z = 1;

        player = GameObject.FindGameObjectWithTag("Player");

        teleport();
    }

    /// <summary>
    /// When the player enters the trigger area, refill gas then move to another location with teleport()
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            player.SendMessage("refillGas");
            teleport();
        }


    }

    /// <summary>
    /// makes a new location for the gas canister that is around the player and then moves the canister to that location
    /// </summary>
    public void teleport() {
        newPos.x = player.GetComponent<Transform>().position.x + (Random.Range(-X_OFFSET,X_OFFSET));
        newPos.y = player.GetComponent<Transform>().position.y + (Random.Range(-Y_OFFSET, Y_OFFSET));

        transform.position = newPos;
    }
}
