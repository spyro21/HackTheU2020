using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // instance variables
    private Transform target;

    public float speed;
    private float catchUpSpeed;

    void Start()
    {
        // initializing instance variables if needed
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        catchUpSpeed = speed * 3;
    }

    void Update()
    {

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getVelocity() > 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, catchUpSpeed * Time.deltaTime);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        // move toward target(player)
    }
}
