using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject healthGo;
    private bool damaged;

    private Rigidbody2D rb;


    // Sprite Renderer
    private SpriteRenderer sr;
    public Sprite rocketNoFire;
    public Sprite rocketFire;



    //movement values
    public float movementSpeed;

    // rotation values
    private float rotationZ;
    public float rotationOffset;
    public float rotationSpeed;

    void Start()
    {
        healthGo = GameObject.FindGameObjectWithTag("Health");
        damaged = false;

        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();


        sr.sprite = rocketNoFire;

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        
        if (!damaged)
        {
            healthGo.SendMessage("takeDamage");
            damaged = true;
        }
    }


    IEnumerator waitForDamaged() {
        yield return new WaitForSeconds(4f);
    }


    void Update()
    {

        // damage check
        if (damaged) {
            StartCoroutine(waitForDamaged());
            damaged = false;
        }


        // forward movement
        if (Input.GetAxisRaw("Jump") != 0)
        {
            rb.AddForce(transform.up * movementSpeed);
            sr.sprite = rocketFire;

        }
        else
        {
            sr.sprite = rocketNoFire;
        }
        


        // rotation movement
        rotationSpeed += -(Input.GetAxisRaw("Horizontal") * Time.deltaTime) * rotationOffset;
        rotationZ += rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);



    }
}




//healthGo.SendMessage("takeDamage");
