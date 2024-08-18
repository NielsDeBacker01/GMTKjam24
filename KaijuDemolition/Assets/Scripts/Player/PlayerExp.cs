using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public int currentExp = 0;
    public int maxExp = 100;
    public BarSlider slider;

    public void Start()
    {
        slider.SetBar(currentExp);
    }

    public void AddExperience(int amount)
    {
        currentExp += amount;
        slider.SetBar(currentExp);
        slider.ChangeBar(maxExp);

        if (currentExp >= maxExp)
            LevelUp();
    }

    void LevelUp()
    {
        currentExp = 0;
        maxExp += 150 ;
        Upgrade();
        Debug.Log(maxExp);
    }

    void Upgrade()
    {
        // kies 3 random upgrades van lijst van upgrades
    }
}
