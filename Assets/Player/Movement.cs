using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12.0f;
    public bool slowdown = false;
    public bool stopmovement=false;
    public float countDown = 0.03f;

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
            speed = 4.0f;

            if (countDown <= 0f)
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
                break;
            case "ObstacleDeath":
                FindObjectOfType<GameManager>().Endgame();
                stopmovement=true;
                break;


        }
    }

}
