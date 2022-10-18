using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity -= Time.deltaTime * 0.03f;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "LightPickup":
                Destroy(other.gameObject);
                light.intensity += 0.1f;
                break;
        }
    }
}
