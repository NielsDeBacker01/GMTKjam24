using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    [SerializeField]
    private int currentExp = 0;
    [SerializeField]
    private int maxExp = 100;
    [SerializeField]
    private int tempMaxExp = 0;
    [SerializeField]
    private int currentLevel;
    [SerializeField]
    AnimationCurve experienceCurve;
    public BarSlider slider;
    
    [SerializeField]
    private LevelUpUI levelUpUI;


    public void Start()
    {
        currentLevel = 1;
        slider.SetBar(currentExp);
        slider.ChangeBar(maxExp);

        levelUpUI = FindObjectOfType<LevelUpUI>();
    }

    public void AddExperience(int amount)
    {
        currentExp += amount;
        slider.SetBar(currentExp);

        if (currentExp >= maxExp)
            LevelUp();
    }

    void LevelUp()
    {

        currentExp = 0;
        currentLevel++;
        tempMaxExp = (int)experienceCurve.Evaluate(currentLevel);
        maxExp = (int)experienceCurve.Evaluate(currentLevel + 1);
        slider.ChangeBar(maxExp - tempMaxExp);

        // toon upgrades
        levelUpUI.ShowUpgrades();
    }

    
}
