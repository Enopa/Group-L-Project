using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject text;

    public GameObject box;

    public GameObject player;

    public float timer;

    public GameObject lights;

    public GameObject door;

    public SafeDoor button;

    public GameObject enemy;

    enum GameState {Start, Moved, Jumped, Sprinted, Lights, Obstacle, Saferoom, Scare}
    private GameState state = GameState.Start;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       switch (state)
        {
            case GameState.Start:
                setText("Press WASD to move");
                if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0)
                {
                    state = GameState.Moved;
                }
                break;
            case GameState.Moved:
                setText("Press SPACEBAR to Jump");
                if (Input.GetButtonDown("Jump"))
                {
                    state = GameState.Jumped;
                }
                break;
            case GameState.Jumped:
                setText("Press LEFT SHIFT to Sprint.\n Sprinting uses up stamina");
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    text.SetActive(false);
                    box.SetActive(false);
                    timer = 5f;
                    state = GameState.Lights;           
                }
                break;
            case GameState.Lights:
                if (timer > 0f)
                {
                    timer -= Time.deltaTime;
                } else
                {
                    Destroy(lights);
                    Destroy(door);
                    text.SetActive(true);
                    box.SetActive(true);
                    setText("Use your lamp to illuminate the dark.\n Yellow batteries keep the lamp bright");
                    if (player.GetComponent<Lamp>().light.intensity > player.GetComponent<Lamp>().minLight)
                    {
                        state = GameState.Obstacle;
                    }
                }
                break;
            case GameState.Obstacle:
                setText("Press LEFT MOUSE BUTTON to attack.\n Attacking destroys GREEN obstacles");
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    state = GameState.Saferoom;
                }
                break;
            case GameState.Saferoom:
                setText("Get to the safe room and hit the panic button to survive!");
                if (button.closing)
                {
                    text.SetActive(false);
                    box.SetActive(false);
                    timer = 5f;
                    state = GameState.Scare;
                }
                break;
            case GameState.Scare:
                if (timer > 0f)
                {
                    timer -= Time.deltaTime;
                } else
                {
                    enemy.SetActive(true);
                }
                break;
            default:
                break;
        }
      
    }

    void setText(string message)
    {
        text.GetComponent<TextMeshProUGUI>().text = message;
    }
}
