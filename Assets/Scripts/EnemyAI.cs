using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetString("difficulty", "MEDIUM"))
        {
            case "EASY":
                agent.speed = 7f;
                break;
            case "MEDIUM":
                agent.speed = 10f;
                break;
            case "HARD":
                agent.speed = 13f;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
