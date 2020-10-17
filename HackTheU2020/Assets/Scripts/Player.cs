using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    //movement values
    public float movementSpeed;


    // rotation values
    private float rotationZ;
    public float rotationOffset;
    public float rotationSpeed;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // forward movement
        if (Input.GetAxisRaw("Jump") != 0) {
            rb.AddForce(transform.up * movementSpeed);
        }
        


        // rotation movement
        rotationSpeed += -(Input.GetAxisRaw("Horizontal") * Time.deltaTime) * rotationOffset;
        rotationZ += rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);



    }
}
