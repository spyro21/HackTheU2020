using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    /// <summary>
    /// reference to the time text gameobjects text component
    /// </summary>
    private Text timeText;

    /// <summary>
    /// time the player has survived
    /// </summary>
    private float time;

    void Start()
    {
        time = 0;
        timeText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Time: " + Mathf.Round(time);
    }
}
