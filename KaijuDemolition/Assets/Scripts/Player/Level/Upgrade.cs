using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    HealthBoost,
    SpeedBoost,
    ClawDamageBoost
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
        }
    }
}
