using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationMeter : MonoBehaviour
{
    /// <summary>
    /// is the player rotating clockwise?
    /// </summary>
    private bool clockwise; // is clockwise?

    /// <summary>
    /// reference to the rotationImage
    /// </summary>
    private Image image;

    /// <summary>
    /// sprite for clockwise rotation
    /// </summary>
    public Sprite cw; // clockwise

    /// <summary>
    /// sprite for counter-clockwise rotation
    /// </summary>
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
