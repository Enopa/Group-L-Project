using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float attackTimer;
    public GameObject hitbox;

    public float attackCooldown;
    public float attackActive;
    private Animator anim; 

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetButtonDown("Fire1") && !hitbox.activeSelf && attackTimer <= 0)
            {
                anim.SetTrigger("attack");
                hitbox.SetActive(true);
                attackTimer = attackActive;
            }
            //condition for animation to go to idle states after attack is done
            if (Input.GetButtonUp("Fire1"))
            {
                anim.SetTrigger("attack");
            }

            if (attackTimer >= 0)
            {
                attackTimer -= Time.deltaTime;
            }

            if (attackTimer <= attackCooldown)
            {
                hitbox.SetActive(false);
            }
        }
    }
}
