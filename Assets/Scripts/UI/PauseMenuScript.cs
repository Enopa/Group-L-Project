using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject PauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // game runs at normal speed
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {             
                Play();
            } else {
                PauseMenuCanvas.SetActive(true);
                Stop();
            }
        }
    }

    public void Stop() {
        // when game stopped, canvas is made visible, and game is frozen
        
        Time.timeScale = 0f;
        isPaused = true;

        // cursor is made visible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Play() {
        // function reverses changes made in Stop
        PauseMenuCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
