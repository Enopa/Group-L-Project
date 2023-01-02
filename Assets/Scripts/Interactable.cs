using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public GameObject ui;
    public Sprite image;

    private bool hover;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hover)
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                ui.SetActive(true);
                ui.GetComponent<Image>().sprite = image;
            }
        }
    }

    public void activate()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        hover = true;
        
    }

    public void deactivate()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        hover = false;
        ui.SetActive(false);
    }
}
