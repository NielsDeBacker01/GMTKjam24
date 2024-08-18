using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerValues playerValues;

    public float getSpeed()
    {
        return (float)(playerValues.baseSpeed * Math.Sqrt(this.transform.lossyScale.x ));
    }

    public float getDamage()
    {
        return playerValues.baseClawDamage;
    }

    public int getCurrentHP()
    {
        return playerValues.HP;
    }
    
    public int loseHP(int damage)
    {
        return playerValues.HP -= damage;
    }
    
    public int getMaxHP()
    {
        return playerValues.baseMaxHP;
    }
    
    public float getInvincibilityCooldown()
    {
        return playerValues.invincibilityCooldown;
    }
    
    public float getBaseAttackActiveTime()
    {
        return playerValues.baseAttackActiveTime;
    }
    
    public int getCurrentExp()
    {
        return playerValues.currentExp;
    }
    
    public int getExpGoal()
    {
        return playerValues.maxExp;
    }
}
