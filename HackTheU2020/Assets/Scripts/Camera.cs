using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // instance variables

    /// <summary>
    /// the player reference for the camera, so that the camera can follow this gameObject
    /// </summary>
    private Transform player;

    /// <summary>
    /// speed of camera 
    /// </summary>
    public float speed;


    void Start()
    {
        // initializing instance variables if needed
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        // move toward target(player)
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getVelocity() > 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, (speed * 3) * Time.deltaTime);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
