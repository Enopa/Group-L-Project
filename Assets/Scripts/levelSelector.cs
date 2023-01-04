using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelector : MonoBehaviour
{

    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void StartScene()
    {
        SceneManager.LoadScene("" + level.ToString());
    }
}
