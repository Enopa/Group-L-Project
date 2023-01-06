using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public Slider sensitivity;

    public Slider volume;

    public TMP_Dropdown diff;

    private void Start()
    {
        sensitivity.value = PlayerPrefs.GetFloat("sensitivity", 100f);
        volume.value = PlayerPrefs.GetFloat("volume", 0.2f);
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 0.2f);

        switch (PlayerPrefs.GetString("difficulty", "MEDIUM"))
        {
            case "EASY":
                diff.value = 0;
                break;
            case "MEDIUM":
                diff.value = 1;
                break;
            case "HARD":
                diff.value = 2;
                break;

        }

    }

    public void quit() {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }

    public void setSensitivity()
    {
        PlayerPrefs.SetFloat("sensitivity", sensitivity.value);
        PlayerPrefs.Save();
    }

    public void setVolume()
    {
        PlayerPrefs.SetFloat("volume", volume.value);
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 0.2f);
        PlayerPrefs.Save();
    }

    public void setDifficulty()
    {
        switch (diff.value)
        {
            case 0:
                PlayerPrefs.SetString("difficulty", "EASY");
                break;
            case 1:
                PlayerPrefs.SetString("difficulty", "MEDIUM");
                break;
            case 2:
                PlayerPrefs.SetString("difficulty", "HARD");
                break;
                
        }
        
        PlayerPrefs.Save();
    }

}
