using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Movement playermovement;
    // Start is called before the first frame update

    void onTriggerEnter(Collider other){
        if (other.gameObject.tag == "DeathObstacle"){
            print("Game Over bozo");

        }
    }
}
