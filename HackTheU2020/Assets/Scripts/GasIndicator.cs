using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasIndicator : MonoBehaviour
{
    /// <summary>
    /// reference to the gas canister which is the target of the arrow
    /// </summary>
    private Transform gas;


    void Start()
    {
        gas = GameObject.FindGameObjectWithTag("Gas").GetComponent<Transform>();   
    }

    void Update()
    {
        var dir = gas.position - transform.position;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
