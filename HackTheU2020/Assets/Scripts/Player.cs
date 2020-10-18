using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    // health
    private GameObject healthGo;
    private bool damaged;

    //for game over (oxygen)
    private GameObject gameHandler;

    // Sprite Renderer
    private SpriteRenderer sr;
    public Sprite rocketNoFire;
    public Sprite rocketFire;


    // fuel
    public float fuel = 500f;
    public float oxygen = 10f;


    //movement values
    public float thrustSpeed;
    public float forwardVelocity;

    // rotation values
    private float rotationZ;
    public float rotationOffset;
    public float rotationVelocity;

    void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("GameHandler");

        healthGo = GameObject.FindGameObjectWithTag("Health");
        damaged = false;

        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();


        sr.sprite = rocketNoFire;

        
    }

    // on collision with asteroid
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
        damaged = false;
    }

    

    void Update()
    {
        // find velocity of ship through pythagorean theorem
        forwardVelocity = Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.y, 2));

        // check if oxygen is depleted, game over
        if (fuel <= 0) {
            oxygen -= Time.deltaTime;

            if (oxygen <= 0)
            {
                gameHandler.SendMessage("nextScene");
            }
        }

        

        // damage check
        if (damaged) {
            StartCoroutine(waitForDamaged());
        }


        // forward movement
        if (Input.GetAxisRaw("Jump") != 0 && fuel > 0)
        {
            
            // caps the velocity to a certain maximum
            if(!(forwardVelocity > 10)) {
                rb.AddForce(transform.up * thrustSpeed);
            }


            sr.sprite = rocketFire;
            fuel -= 0.5f;

        }
        else
        {
            sr.sprite = rocketNoFire;
        }
        


        // rotation movement
        rotationVelocity += -(Input.GetAxisRaw("Horizontal") * Time.deltaTime) * rotationOffset;
        rotationZ += rotationVelocity;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);



    }

    // getter method
    public float getVelocity()
    {
        return forwardVelocity;
    }

    public float getRotationVelocity()
    {
        return rotationVelocity;
    }

    public float getFuel()
    {
        return fuel;
    }

    public float getOxygen()
    {
        return oxygen;
    }

    public void refillGas()
    {
        fuel = 500;
    }

}