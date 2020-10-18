using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guage : MonoBehaviour
{
    /// <summary>
    /// fuel gameObject reference to easily access the fuel text
    /// </summary>
    public GameObject fuel;

    /// <summary>
    /// oxygen gameObject reference to easily access the oxygen text
    /// </summary>
    public GameObject oxygen;

    /// <summary>
    /// fuel text reference to change text
    /// </summary>
    private Text fuelText;

    /// <summary>
    /// oxygen gameObject reference to change text
    /// </summary>
    private Text oxygenText;

    /// <summary>
    /// player reference to get the fuel and oxygen variables
    /// </summary>
    private Player player;

    void Start()
    {
        fuelText = fuel.GetComponent<Text>();
        oxygenText = oxygen.GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        fuelText.text = "Fuel: " + Mathf.Round(player.getFuel());
        oxygenText.text = "Oxygen: " + Mathf.Round(player.getOxygen());
    }
}
