using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    [SerializeField]
    private AudioValues audioLevel;    
    
    [SerializeField]
    private bool sfx = false;

    public Slider slider;

    

    public void Start()
    {
        if(sfx)
        {
            slider.value = audioLevel.sfx;
        }
        else
        {
            slider.value = audioLevel.music;
        }
    }

    public void OnSliderChange(float value){
        if(sfx)
        {
            audioLevel.sfx = value;
        }
        else
        {
            audioLevel.music = value;
        }
        
    }
}