using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SafeDoor : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;
    public float moveSpeed;
    public float closePos;

    private bool closing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (closing)
        {
            doorLeft.transform.Translate(new Vector3(0, 0, -moveSpeed * Time.deltaTime));
            doorRight.transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
            if (doorLeft.transform.position.x <= closePos)
            {
                closing = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHitbox")
        {
            closing = true;
        }
    }
}