using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float attackTimer;
    public GameObject hitbox;

    public float attackCooldown;
    public float attackActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !hitbox.activeSelf && attackTimer <= 0)
        {
            hitbox.SetActive(true);
            attackTimer = attackActive;
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
