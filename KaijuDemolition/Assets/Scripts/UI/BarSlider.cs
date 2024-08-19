using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarSlider : MonoBehaviour
{
    public Slider slider;

    public void SetBar(int value)
    {
        if(value < 0)
        {   
            value = 0;
        }
        slider.value = value;
    }

    public void ChangeBar(int maxValue)
    {
        slider.maxValue = maxValue;
    }
}
