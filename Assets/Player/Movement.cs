using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12.0f;
    public bool slowdown = false;
    public float countDown = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveX + transform.forward * moveY;

        controller.Move(movement * speed * Time.deltaTime);

        if (slowdown == true) {
            countDown -= Time.deltaTime;
            if (countDown > 0)
            {
                speed = 6.0f;
            }
        }

    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ObstacleCollide")
        {
            slowdown = true;
            Destroy(col.gameObject);
        }
          
    }
    
}
