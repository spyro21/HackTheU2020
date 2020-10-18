using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasIndicator : MonoBehaviour
{
    private Transform target;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Gas").GetComponent<Transform>();   
    }

    void Update()
    {
        var dir = target.position - transform.position;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
