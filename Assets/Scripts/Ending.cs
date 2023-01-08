using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public AudioSource endingNoise;
    private bool end = false;
    public float timer;

    public GameObject blackScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            timer -= Time.deltaTime;
            if (endingNoise.time >= 30)
            {
                blackScreen.SetActive(true);

            }
            if (endingNoise.time >= 40)
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!end)
        {
            if (other.tag == "PlayerHitbox")
            {
                end = true;
                endingNoise.Play();
            }
        }
        
    }
}
