using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float rotationZ;
    public float rotationSpeed;
    public bool clockWiseRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        rotationZ += Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;


        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
