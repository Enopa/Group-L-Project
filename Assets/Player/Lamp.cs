using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light light;

    public float lightDimSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity -= Time.deltaTime * lightDimSpeed;


        //Debug stuff
        if (Input.GetKey(KeyCode.Alpha1))
        {
            lightDimSpeed = 0.0f;
            light.intensity = 0.3f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "LightPickup":
                Destroy(other.gameObject);
                light.intensity += 0.2f;
                break;
        }
    }
}
