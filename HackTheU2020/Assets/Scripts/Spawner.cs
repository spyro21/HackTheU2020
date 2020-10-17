using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject player;

    private float randomNumber;

    private float xOffset;
    private float yOffset;

    private int spawnSide;

    public GameObject asteroidGo;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        xOffset = 15;
        yOffset = 10;
    }

    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(0f, 100f);

        if (randomNumber < 1) {
            spawnSide = (int)Random.Range(0f, 4f);
            createAsteroid(spawnSide);
        }
    }


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
