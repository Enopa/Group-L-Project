using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12.0f;
    private bool stopmovement=false;
    private float slowTimer;
    private bool slowdown = false;

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
            slowTimer -= Time.deltaTime;
            speed = 3.0f;

            if (slowTimer <= 0f)
            {
                slowdown = false;
                speed = 12.0f;
            }
        }

        if (stopmovement==true){
            speed = 0f;

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "ObstacleCollide":
                Destroy(other.gameObject);
                slowdown = true;
                slowTimer = 0.5f;
                break;
            case "ObstacleDeath":
                FindObjectOfType<GameManager>().Endgame();
                stopmovement=true;
                break;
        }
    }

}
