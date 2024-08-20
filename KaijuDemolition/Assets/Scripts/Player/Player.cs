using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerValues playerValues;
    [SerializeField] private GameObject backAttack;

    public void Start()
    {
        if(playerValues.armsLevel == 0)
        {
            backAttack.SetActive(false);
        }
        else
        {
            backAttack.SetActive(true);
        }
    }
    public float getAoe()
    {
        return (float)(playerValues.baseAOE * playerValues.AOEmult);
    }

    public void growAoe(float value)
    {
        playerValues.AOEmult += value;
    }

    public float getAttackCooldown()
    {
        float ac = (float)(playerValues.attackCooldown * playerValues.attackCooldownMult);
        if(ac < 0.01f)
            return 0.01f;
        return ac;
    }

    public void lowerAttackCooldown(float value)
    {
        playerValues.attackCooldownMult *= value;
    }

    public float getSpeed()
    {
        return (float)((playerValues.baseSpeed + Math.Sqrt(this.transform.lossyScale.x) - 1) * playerValues.speedMult);
    }

    public void raiseSpeedMult(float value)
    {
        playerValues.speedMult += value;
    }

    public void lowerSpeedMult()
    {
        playerValues.speedMult /= 2;
    }

    public float getDamage()
    {
        float attack = playerValues.baseClawDamage + playerValues.clawDamageBoost;
        if(playerValues.dominanceLevel > 0)
        {
            attack *= (float) Math.Sqrt(this.transform.lossyScale.x);
        }
        if(attack < 1)
        {
            return 1;
        }
        return attack;
    }

    public void raiseDamage(int value)
    {
        playerValues.clawDamageBoost += value;
    }

    public void lowerAttack(int value)
    {
        if(value == 2)
        {
            playerValues.clawDamageBoost = (int)Math.Floor(playerValues.clawDamageBoost * 0.5);
        }
        else
        {
            playerValues.clawDamageBoost -= value;
            if(playerValues.clawDamageBoost < 0)
            {
                playerValues.clawDamageBoost = 0;
            }
        }
    }

    public int getCurrentHP()
    {
        return playerValues.HP;
    }
    
    public void loseHP(int damage)
    {
        int newDamage = damage * ( (500 - playerValues.defense) / 500);
        if(newDamage < 1)
        {
            newDamage = 1;
        }
        playerValues.HP -= newDamage;
    }

    public void raiseDefense(int defense)
    {
        playerValues.defense += defense;
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

    public int getLevel()
    {
        return playerValues.level;
    }

    public void setCurrentExp(int value)
    {
        playerValues.currentExp = value;
    }
    
    public void setExpGoal(int value)
    {
        playerValues.maxExp = value;
    }

    public void setLevel(int value)
    {
        playerValues.level = value;
    }

    public int AuraLevel
    {
        get { return playerValues.auraLevel; }
        set { playerValues.auraLevel = value; }
    }

    public int BoulderLevel
    {
        get { return playerValues.boulderLevel; }
        set { playerValues.boulderLevel = value; }
    }

    public int BeamLevel
    {
        get { return playerValues.beamLevel; }
        set { playerValues.beamLevel = value; }
    }

    public int ArmsLevel
    {
        get { return playerValues.armsLevel; }
        set { playerValues.armsLevel = value; }
    }

    public int SurvivorLevel
    {
        get { return playerValues.survivorLevel; }
        set { playerValues.survivorLevel = value; }
    }

    public int BigLevel
    {
        get { return playerValues.bigLevel; }
        set { playerValues.bigLevel = value; }
    }

    public int VampireLevel
    {
        get { return playerValues.vampireLevel; }
        set { playerValues.vampireLevel = value; }
    }

    public int DominanceLevel
    {
        get { return playerValues.dominanceLevel; }
        set { playerValues.dominanceLevel = value; }
    }

    public int SkinLevel
    {
        get { return playerValues.skinLevel; }
        set { playerValues.skinLevel = value; }
    }

    public int VelociraptorLevel
    {
        get { return playerValues.velociraptorLevel; }
        set { playerValues.velociraptorLevel = value; }
    }

    public void vampire()
    {
        int roll = UnityEngine.Random.Range(1, 21);
        if(roll <= VampireLevel && playerValues.HP < getMaxHP())
        {
            playerValues.HP += 1;
        }
        
    }

    public void survivor()
    {
        playerValues.HP = 1;
        raiseSpeedMult(0.2f);
        raiseDamage(30);
    }

    public void unlockArms()
    {
        backAttack.SetActive(true);
    }

    public float getBeamCooldown()
    {
        switch(playerValues.beamLevel)
        {
            case 1:
                return 3;
            case 2:
                return 2;
            case 3:
                return 1;
            default:
                return 3;
        }
    }
}
