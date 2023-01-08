using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleport : MonoBehaviour
{
    public GameObject enemy;

    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.transform.position = gameObject.transform.position;
            GameObject e = Instantiate(enemy);
            e.name = "1";
            e.GetComponent<EnemyAI>().player = GameObject.Find("PlayerModel");
        }
    }
}
