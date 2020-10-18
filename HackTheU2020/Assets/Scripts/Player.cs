using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// reference to the players rigidBody component for player movement
    /// </summary>
    private Rigidbody2D rb;

    // health
    /// <summary>
    /// health gameObject reference to take damage when hit
    /// </summary>
    private GameObject healthGo;

    /// <summary>
    /// boolean value to determine the state of the player, if damaged == true player is invicible for a period
    /// </summary>
    private bool damaged;

    //for game over (oxygen)
    /// <summary>
    /// gameHandler reference to end game when the oxygen is less than or equal to 0
    /// </summary>
    private GameObject gameHandler;

    // Sprite Renderer
    /// <summary>
    /// reference to the players spriteRenderer component to show when using rocketss
    /// </summary>
    private SpriteRenderer sr;

    /// <summary>
    /// sprite for when player is not using boost
    /// </summary>
    public Sprite rocketNoFire;

    /// <summary>
    /// sprite for when player is using boost
    /// </summary>
    public Sprite rocketFire;


    // fuel
    /// <summary>
    /// fuel variable that is used to boost
    /// </summary>
    private float fuel = 500f;

    /// <summary>
    /// oxygen variable that is depleted when the fuel is out. if oxygen reaches 0, game is over
    /// </summary>
    private float oxygen = 10f;


    //movement values
    /// <summary>
    /// thrust speed when player uses the boost
    /// </summary>
    private float thrustSpeed = 3f;

    /// <summary>
    /// velocity of the player in a variable to cap out speed
    /// </summary>
    private float forwardVelocity;

    // rotation values
    /// <summary>
    /// rotation variable
    /// </summary>
    private float rotationZ;

    /// <summary>
    /// multiplier for the rotation
    /// </summary>
    private float rotationOffset = 3f;
    
    /// <summary>
    /// velocity of rotation to add momentum
    /// </summary>
    private float rotationVelocity;

    void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("GameHandler");

        healthGo = GameObject.FindGameObjectWithTag("Health");
        damaged = false;

        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();


        sr.sprite = rocketNoFire;

        
    }

    /// <summary>
    /// on collision with an asteroid
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        
        if (!damaged)
        {
            healthGo.SendMessage("takeDamage");
            damaged = true;
        }
    }

    /// <summary>
    /// invulnaribliity period
    /// </summary>
    /// <returns></returns>
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

    // getter methods
    /// <summary>
    /// getter method for forwardVelocity
    /// </summary>
    /// <returns>spacial velocity of the player</returns>
    public float getVelocity()
    {
        return forwardVelocity;
    }

    /// <summary>
    /// getter method for rotationVelocity
    /// </summary>
    /// <returns>rotation velocity of player</returns>
    public float getRotationVelocity()
    {
        return rotationVelocity;
    }

    /// <summary>
    /// getter method for fuel
    /// </summary>
    /// <returns>fuel</returns>
    public float getFuel()
    {
        return fuel;
    }

    /// <summary>
    /// getter method for oxygen
    /// </summary>
    /// <returns>oxygen</returns>
    public float getOxygen()
    {
        return oxygen;
    }

    // setter methods
    /// <summary>
    /// refill gas to a full canister
    /// </summary>
    public void refillGas()
    {
        fuel = 500f;
    }

}