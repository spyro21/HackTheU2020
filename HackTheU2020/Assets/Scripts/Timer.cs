using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timeText;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        timeText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Time: " + Mathf.Round(time);
    }
}
