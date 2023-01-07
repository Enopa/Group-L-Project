using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource footstepsSound;
    public AudioSource sprintSound;
    public AudioSource swingSound;
    public AudioSource jumpSound;
    public Movement movement;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    

    void Update(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                jumpSound.enabled=true;
                jumpSound.Play();

            }     
    
            if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D)){
                if(Input.GetKey(KeyCode.LeftShift)&& (movement.stamina>0)){
                    footstepsSound.enabled=false;
                    sprintSound.enabled=true;
                }
                else{

                    sprintSound.enabled=false;
                    footstepsSound.enabled=true;

                }
             }
            else{
                footstepsSound.enabled=false;
            }


        }
        else{
            sprintSound.enabled=false;
            footstepsSound.enabled=false;

        }
        if(Input.GetButtonDown("Fire1")){
            swingSound.enabled=true;
            swingSound.Play();

        } 
        


    }

}
