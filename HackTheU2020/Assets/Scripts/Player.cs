using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float rotationZ;
    public float rotationSpeed;
    public bool clockWiseRotation;

    void Start()
    {
        
    }

    void Update()
    {

        // rotation movement
        //rotationZ += Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;
        rotationSpeed += -(Input.GetAxisRaw("Horizontal") * Time.deltaTime);
        rotationZ += rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
