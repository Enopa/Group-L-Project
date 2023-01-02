using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play() {
        // just using the name of the sample scene to load it for now
        SceneManager.LoadScene("0");
    }

    public void quit() {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }


}
