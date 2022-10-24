using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverUI; 
    bool gameEnd=false;
    public float restartDelay=.3f;
    // Start is called before the first frame update
    public void Endgame(){
        Debug.Log("Game Over bozo");
        if (gameEnd==false){
            gameEnd=true;
            Invoke("GameOver",restartDelay);
        }

    }

    void GameOver(){
        GameOverUI.SetActive(true);
    }
}
