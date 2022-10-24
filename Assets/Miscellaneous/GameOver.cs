using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverUI; 
    public void Start(){
        GameOverUI.SetActive(false);
    }
    public void play() {
        // just using the name of the sample scene to load it for now
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quit() {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }


}
