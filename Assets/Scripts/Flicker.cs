using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    float timeOn = 0.1f;
    float timeOff = 0.5f;

    float changeTime = 0f;

    public GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > changeTime)
        {
            light.SetActive(!light.activeSelf);
            timeOff = Random.Range(0.05f, 0.2f);
            timeOn = Random.Range(0.2f, 0.7f);
            if (light.activeSelf)
            {
                changeTime = Time.time + timeOn;
            } else
            {
                changeTime = Time.time + timeOff;
            }
        }
    }
}
