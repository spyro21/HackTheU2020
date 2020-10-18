using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationMeter : MonoBehaviour
{
    private bool clockwise; // is clockwise?


    private Image image;
    public Sprite cw; // clockwise
    public Sprite ccw; // counter-clockwise



    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getRotationVelocity() > 0)
        {
            image.sprite = ccw;
        }
        else
        {
            image.sprite = cw;
        }
    }
}
