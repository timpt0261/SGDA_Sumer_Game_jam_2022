using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int interger;

    public void SetHealth(int health) {
        slider.value = health;
    }
}
