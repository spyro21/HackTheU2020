using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform target;

    public float initPush;


    private Vector3 distanceFrom;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * initPush);
    }

    // Update is called once per frame
    void Update()
    {
        

        distanceFrom = transform.position - target.position;

        if (Mathf.Abs(distanceFrom.x) > 20 || Mathf.Abs(distanceFrom.y) > 15) {
            Destroy(gameObject);
        }
    }
}
