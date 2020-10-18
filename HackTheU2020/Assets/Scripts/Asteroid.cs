using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    /// <summary>
    /// rigid body reference in the asteriod class
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// the target for the general area the asteroid will be pushed towards
    /// </summary>
    private Transform player;

    /// <summary>
    /// the amount of power added when the asteroid is first initiated
    /// </summary>
    private float initialThrust;

    /// <summary>
    /// Vector3 to determine when this object should be destroyed for extra space
    /// </summary>
    private Vector3 distanceFrom;

    void Start()
    {
        // initializing instance variables
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        initialThrust = 100;

        //initial thrust
        rb.AddForce(transform.up * initialThrust);
    }

    void Update()
    {
        // destroys asteroids if they get too far from character
        distanceFrom = transform.position - player.position;

        if (Mathf.Abs(distanceFrom.x) > 20 || Mathf.Abs(distanceFrom.y) > 15) {
            Destroy(gameObject);
        }
    }
}
