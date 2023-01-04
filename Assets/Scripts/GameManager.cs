using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    bool gameEnd=false;
    public float restartDelay=.3f;

    // Start is called before the first frame update
    public void Endgame() {

        Debug.Log("Game Over");
        if (gameEnd==false){
            gameEnd=true;
            Cursor.lockState = CursorLockMode.None;
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    //Reloads the game
    public void restart()
    {
        // just using the name of the sample scene to load it for now
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }

    public void nextLevel()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level + 1);
    }
}
