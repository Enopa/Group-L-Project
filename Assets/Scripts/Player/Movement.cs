using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    //Basic Movement Variables
    private float speed = 12.0f;
    public float baseSpeed = 12.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.0f;
    public float staminaDrain = 0.05f;
    public float staminaGain = 0.05f;
    public float stamina = 1;

    //Variables for checking the ground
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

   

    Vector3 velocity;
    

    //Slow and stop
    private bool stopmovement=false;
    private float slowTimer;
    private bool slowdown = false;

    //animation variable
    private Animator anim; 

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //BASIC MOVEMENT SCRIPT

        //Creates a small sphere that checks for collisions
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //This allows for basic movement on the x and z axis
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * moveX + transform.forward * moveY;
        controller.Move(movement * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //This applies gravity to the player to ensure they fall
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //Sprinting stuff
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && stamina > 0)
        {
            anim.SetBool("sprint", true);
            speed = baseSpeed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("sprint", false);
            speed = baseSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            stamina -= Time.deltaTime * staminaDrain;
            if (stamina <= 0)
            {
                anim.SetBool("sprint", false);
                speed = baseSpeed;
            }
        } else
        {
            stamina += Time.deltaTime * staminaGain;
        }
        stamina = Mathf.Clamp(stamina, 0, 1);


        //SLOWDOWN + EFFECTS
        if (slowdown == true) {
            slowTimer -= Time.deltaTime;
            speed = baseSpeed / 3f;

            if (slowTimer <= 0f)
            {
                slowdown = false;
                speed = baseSpeed;
            }
        }

        if (stopmovement==true){
            speed = 0f;

        }

        //DebugStuff
        if (Input.GetKey(KeyCode.Alpha2))
        {
            staminaDrain = 0f;
        }

        //animation set ups with key presses

        if (movement== Vector3.zero){
            anim.SetFloat("Blend", 0, 0.1f, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W)){
            anim.SetFloat("Blend", 0.25f, 0.1f, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)){
            anim.SetFloat("Blend", 0.75f, 0.1f, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)){
            anim.SetFloat("Blend", 0.5f, 0.1f, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)){
            anim.SetFloat("Blend", 1, 0.1f, Time.deltaTime);
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
