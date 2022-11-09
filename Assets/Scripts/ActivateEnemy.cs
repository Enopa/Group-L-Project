using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.SetActive(true);
            text.SetActive(true);
        }
    }
}
