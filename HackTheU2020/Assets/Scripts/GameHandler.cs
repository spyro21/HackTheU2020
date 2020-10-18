using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    /// <summary>
    /// loads the next scene that is currently in the build
    /// </summary>
    public void nextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// goes back to the previous scene in the build, mainly used for going back to the Game Scene
    /// </summary>
    public void playGameAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
