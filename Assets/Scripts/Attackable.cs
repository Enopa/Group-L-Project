using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    public AudioSource breakSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHitbox")
        {
            breakSound.enabled=true;
            breakSound.Play();
            Destroy(gameObject);
        }
    }
}
