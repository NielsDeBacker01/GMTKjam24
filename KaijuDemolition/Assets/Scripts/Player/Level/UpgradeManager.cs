using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<Upgrade> allUpgrades = new List<Upgrade>();

    private void Start()
    {
        // lijst van upgrades
        allUpgrades.Add(new Upgrade("Health Boost", "Increase max health by 20", UpgradeType.HealthBoost, intValue: 20));
        allUpgrades.Add(new Upgrade("Speed Boost", "Increase speed by 5%", UpgradeType.SpeedBoost, floatValue: 1.05f));
        allUpgrades.Add(new Upgrade("Claw Damage Boost", "Increase claw damage by 15", UpgradeType.ClawDamageBoost, intValue: 15));
        allUpgrades.Add(new Upgrade("Health Boost", "Increase max health by 100", UpgradeType.HealthBoost, intValue: 100));
        allUpgrades.Add(new Upgrade("Speed Boost", "Increase speed by 15%", UpgradeType.SpeedBoost, floatValue: 1.15f));
        allUpgrades.Add(new Upgrade("Claw Damage Boost", "Increase claw damage by 20", UpgradeType.ClawDamageBoost, intValue: 20));
        // ...
    }

    // neem 3 random upgrades
    public List<Upgrade> GetRandomUpgrades(int count = 3)
    {
        List<Upgrade> randomUpgrades = new List<Upgrade>();
        List<Upgrade> copyOfAllUpgrades = new List<Upgrade>(allUpgrades);

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, copyOfAllUpgrades.Count);
            randomUpgrades.Add(copyOfAllUpgrades[index]);
            copyOfAllUpgrades.RemoveAt(index); // Remove to prevent duplicates
        }

        return randomUpgrades;
    }
}
