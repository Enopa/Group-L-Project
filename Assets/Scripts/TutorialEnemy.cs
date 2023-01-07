using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnemy : MonoBehaviour
{
    public GameObject finalScreen;
    public GameObject player;
    public AudioSource music;
    public AudioSource bangingSound;
    public AudioSource title;

    public Rigidbody body;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Movement>().enabled = false;
        music.enabled=false;
        bangingSound.enabled=false;
        title.enabled=true;
        body = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        body.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            finalScreen.SetActive(true);
            Invoke("nextScene", 3.0f);
        }
    }

    void nextScene()
    {
        SceneManager.LoadScene("1");
    }
}
