using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    [SerializeField]
    AnimationCurve experienceCurve;
    public BarSlider slider;
    
    [SerializeField]
    private LevelUpUI levelUpUI;
    private Player player;

    public void Start()
    {
        player = FindObjectOfType<Player>();
        slider.SetBar(player.getCurrentExp());
        slider.ChangeBar(player.getExpGoal());

        levelUpUI = FindObjectOfType<LevelUpUI>();
    }

    public void AddExperience(int amount)
    {
        int currentExp = player.getCurrentExp();
        int maxExp = player.getExpGoal();
        player.setCurrentExp(currentExp + amount) ;
        slider.SetBar(currentExp);

        if (currentExp >= maxExp)
            LevelUp();
    }

    void LevelUp()
    {
        player.setCurrentExp(0);
        player.setLevel(player.getLevel() + 1);
        player.setExpGoal((int)experienceCurve.Evaluate(player.getLevel() + 1));
        Debug.Log("next level: " + player.getExpGoal());
        slider.SetBar(player.getCurrentExp());
        slider.ChangeBar(player.getExpGoal());

        // toon upgrades
        levelUpUI.ShowUpgrades();
    }

    
}
