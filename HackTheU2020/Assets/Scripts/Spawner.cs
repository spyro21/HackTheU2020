using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /// <summary>
    /// reference to the player gameObject
    /// </summary>
    private GameObject player;

    // asteroids
    /// <summary>
    /// random number that decides the spawnrate of asteroids
    /// </summary>
    private float asteroidSpawnRate;

    /// <summary>
    /// offset for asteroid spawn location on x coord
    /// </summary>
    private float xOffset;

    /// <summary>
    /// offset for asteroid spawn location on y coord
    /// </summary>
    private float yOffset;

    /// <summary>
    /// random number between 0-3 that determine which side of the player the asteroids spawn on
    /// </summary>
    private int spawnSide;


    /// <summary>
    /// reference to the asteroid gameObjecta
    /// </summary>
    public GameObject asteroidGo;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        xOffset = 15;
        yOffset = 10;

        for (int i = 0; i < 50; i++) {
            //createStar();
        }

    }

    void Update()
    {
        asteroidSpawnRate = Random.Range(0f, 100f);

        if (asteroidSpawnRate < 1) {
            spawnSide = (int)Random.Range(0f, 4f);
            createAsteroid(spawnSide);
        }
    }

    /// <summary>
    /// spawns a new asteroid gameobject that is pointing in the general direction of the player, with a random side.
    /// </summary>
    /// <param name="side">random number that decides which side the asteroid spawns on</param>
    private void createAsteroid(int side) {
        float xPos = 0;
        float yPos = 0;
        float zRot = 0;

        switch (side) {
            case 0:
                xPos = -xOffset + player.transform.position.x;
                yPos = (Random.Range(-yOffset, yOffset)) + player.transform.position.y;
                zRot = Random.Range(-45f, -135f);
                break;

            case 1:
                xPos = (Random.Range(-xOffset, xOffset)) + player.transform.position.x;
                yPos = yOffset + player.transform.position.y;
                zRot = Random.Range(-135f, -225f);
                break;

            case 2:
                xPos = xOffset + player.transform.position.x;
                yPos = (Random.Range(-yOffset, yOffset)) + player.transform.position.y;
                zRot = Random.Range(45f, 135f);
                break;

            case 3:
                xPos = (Random.Range(-xOffset, xOffset)) + player.transform.position.x;
                yPos = -yOffset + player.transform.position.y;
                zRot = Random.Range(-45f, 45f);
                break;
        }
        
        GameObject newAsteroid = Instantiate(asteroidGo,new Vector3(xPos,yPos,1),Quaternion.Euler(0f,0f,zRot));
        newAsteroid.transform.SetParent(transform); //sets asteroid to be a sub gameobject of Spawner
    }

}
