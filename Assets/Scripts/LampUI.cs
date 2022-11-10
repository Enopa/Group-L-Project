using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampUI : MonoBehaviour
{
    public Slider slider;
    public Slider staminaSlider;

    public Light light;
    public Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = light.intensity;
        staminaSlider.value = movement.stamina;
    }
}
