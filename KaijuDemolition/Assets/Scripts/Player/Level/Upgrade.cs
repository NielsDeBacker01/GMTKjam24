using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    HealthBoost,
    SpeedBoost,
    ClawDamageBoost,
    ClawAOE,
    ClawSpeed,
    AuraLevel,
    BoulderLevel,
    BeamLevel,
    ArmsLevel,
    SurvivorLevel,
    BigLevel,
    VampireLevel,
    DominanceLevel,
    SkinLevel,
    VelociraptorLevel,
}

public class Upgrade
{
    public string upgradeName;
    public string description;
    public UpgradeType upgradeType;
    public int intValue; // Use this for health or damage upgrades
    public float floatValue; // Use this for speed, invincibility, or attack time upgrades

    public Upgrade(string name, string description, UpgradeType type, int intValue = 0, float floatValue = 0f)
    {
        this.upgradeName = name;
        this.description = description;
        this.upgradeType = type;
        this.intValue = intValue;
        this.floatValue = floatValue;
    }

    public void ApplyUpgrade(Player player)
    {
        switch (upgradeType)
        {
            case UpgradeType.HealthBoost:
                player.raiseHPMax(intValue);
                break;
            case UpgradeType.SpeedBoost:
                player.raiseSpeedMult(floatValue);
                break;
            case UpgradeType.ClawDamageBoost:
                player.raiseDamage(intValue);
                break;
            case UpgradeType.ClawAOE:
                player.growAoe(floatValue);
                break;
            case UpgradeType.ClawSpeed:
                player.lowerAttackCooldown(floatValue);
                break;
            case UpgradeType.AuraLevel:
                player.AuraLevel += intValue;
                break;            
            case UpgradeType.BoulderLevel:
                player.BoulderLevel += intValue;
                break;            
            case UpgradeType.BeamLevel:
                player.BeamLevel += intValue;
                break;            
            case UpgradeType.ArmsLevel:
                player.ArmsLevel += intValue;
                break;            
            case UpgradeType.SurvivorLevel:
                player.SurvivorLevel += intValue;
                break;            
            case UpgradeType.BigLevel:
                player.BigLevel += intValue;
                break;            
            case UpgradeType.VampireLevel:
                player.VampireLevel += intValue;
                break;            
            case UpgradeType.DominanceLevel:
                player.DominanceLevel += intValue;
                break;            
            case UpgradeType.SkinLevel:
                player.SkinLevel += intValue;
                player.raiseDefense(50);
                player.lowerSpeedMult();
                break;            
            case UpgradeType.VelociraptorLevel:
                player.VelociraptorLevel += intValue;
                player.raiseSpeedMult(0.5f);
                player.lowerAttackCooldown(0.5f);
                player.lowerAttack(100);
                break;   
        }
    }
}
