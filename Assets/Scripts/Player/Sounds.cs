using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource footstepsSound;
    public AudioSource sprintSound;
    public AudioSource swingSound;
    public Movement movement;

    void Update(){
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

        if(Input.GetButtonDown("Fire1")){
            swingSound.enabled=true;
            swingSound.Play();

        }   


    }

}
