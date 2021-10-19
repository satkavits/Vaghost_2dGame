﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    public Slider slider;

    public void setHealth(int health) 
    {
        slider.value = health;
    }

    public void setMaxHealth(int maxhealth)
    {
        slider.maxValue = maxhealth;
        slider.value = maxhealth;
    }

    
}
