using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeDoor : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;
    public float moveSpeed;
    public float closePos;
    public GameObject nextLevel;
    public PauseMenuScript pause;

    public bool closing = false;
    private bool closedDoors;

    public GameObject enemy;
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
                closedDoors = true;
                enemy.SetActive(false);
            }
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerHitbox")
        {
            if (closedDoors)
            {
                pause.Stop();
                if (SceneManager.GetActiveScene().name != "0")
                {
                    nextLevel.SetActive(true);
                }
            } else
            {
                closing = true;
            }
            
        }

        
    }
}
