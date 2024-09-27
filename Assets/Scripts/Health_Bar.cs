using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = slider.maxValue;
    }
    // Start is called before the first frame update
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
