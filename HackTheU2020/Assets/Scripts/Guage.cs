using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guage : MonoBehaviour
{


    public GameObject fuel;
    public GameObject oxygen;
    private Text fuelText;
    private Text oxygenText;

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
