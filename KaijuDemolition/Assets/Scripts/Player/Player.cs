using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerValues playerValues;

    public float getSpeed()
    {
        return (float)(playerValues.baseSpeed * playerValues.speedMult * Math.Sqrt(this.transform.lossyScale.x ));
    }

    public void raiseSpeedMult(float value)
    {
        playerValues.speedMult += value;
    }

    public float getDamage()
    {
        return playerValues.baseClawDamage + playerValues.clawDamageBoost;
    }

    public void raiseDamage(int value)
    {
        playerValues.clawDamageBoost += value;
    }

    public int getCurrentHP()
    {
        return playerValues.HP;
    }
    
    public void loseHP(int damage)
    {
        playerValues.HP -= damage;
    }
    
    public int getMaxHP()
    {
        return playerValues.baseMaxHP + playerValues.maxHPIncrease;
    }

    public void raiseHPMax(int value)
    {
        playerValues.maxHPIncrease += value;
        playerValues.HP += value;
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
