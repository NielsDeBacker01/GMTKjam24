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
        Debug.Log("EXP toegevoegd: " + amount + ". Totale EXP: " + currentExp);
    }

    void LevelUp()
    {
        if (currentExp >= maxExp)
        {
            currentExp = 0;
            Upgrade();
        }
    }

    void Upgrade()
    {
        // kies 3 random upgrades van lijst van upgrades
    }
}
