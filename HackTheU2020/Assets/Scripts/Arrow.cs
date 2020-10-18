using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform player;
    private Transform gas;

    // lock with character
    private Vector3 pos;


    // point towards gas
    private float dx;
    private float dy;
    private float thetaZ;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gas = GameObject.FindGameObjectWithTag("Gas").GetComponent<Transform>();

        pos.z = 1;
    }

    void Update()
    {
        // lock with character
        pos.x = player.position.x;
        pos.y = player.position.y;
        transform.position = pos;

        // points towards gas
        /*
        dx = player.position.x - gas.position.x;
        dy = player.position.y - gas.position.y;
        

        thetaZ = Mathf.Atan2(dy,dx);
        thetaZ = ((thetaZ * 360) / Mathf.PI);
        Debug.Log(thetaZ);
        transform.rotation = Quaternion.Euler(0f, 0f, thetaZ);
        */
        
    }
}
