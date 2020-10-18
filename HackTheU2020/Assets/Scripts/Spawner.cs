using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject player;

    // stars
    private float starX;
    private float starY;

    public GameObject starGo;

    private int numStars;

    // asteroids
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

        for (int i = 0; i < 50; i++) {
            //createStar();
        }

    }

    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(0f, 100f);

        if (randomNumber < 1) {
            spawnSide = (int)Random.Range(0f, 4f);
            createAsteroid(spawnSide);
        }

        if (randomNumber < 10 && numStars < 100) {
           // createStar();
        }
    }

    private void createStar() {
        
        starY = Random.Range(-yOffset, yOffset) + player.transform.position.y;
        starX = Random.Range(-xOffset, xOffset) + player.transform.position.x;

        int side = (int)Random.Range(0f, 4f);

        switch (side) {
            case 0:
                starX = Random.Range(-xOffset, -10);
                starY = Random.Range(-yOffset, yOffset) + player.transform.position.y;
                break;

            case 1:
                starX = Random.Range(-xOffset, xOffset) + player.transform.position.x;
                starY = Random.Range(5, yOffset);
                break;

            case 2:
                starX = Random.Range(10, xOffset);
                starY = Random.Range(-yOffset, yOffset) + player.transform.position.y;
                break;

            case 3:
                starX = Random.Range(-xOffset, xOffset) + player.transform.position.x;
                starY = Random.Range(yOffset, -5);
                break;
        }

        GameObject star = Instantiate(starGo, new Vector3(starX, starY, 1), Quaternion.identity);
        star.transform.SetParent(transform);
        numStars++;
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

    public void decrementStars() {
        numStars--;
    }

}
