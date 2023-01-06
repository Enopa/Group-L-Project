using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f;

    public Transform body;

    float xRotation = 0.0f;

    public GameObject interact;
    bool key;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        interact = gameObject;
        sensitivity = PlayerPrefs.GetFloat("sensitivity", 100f);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);


        //Checking to see if player is looking at interactable object
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Interactable")
            {
                interact = hit.collider.gameObject;
                interact.GetComponent<Interactable>().activate();
                key = true;
            }
            else
            {
                // Hitting something else.
                if (interact.tag == "Interactable")
                {
                    interact.GetComponent<Interactable>().deactivate();
                }
                key = false;
            }
        }
        else if (key)
        {
            // not anymore.
            key = false;
        }
    }
}
