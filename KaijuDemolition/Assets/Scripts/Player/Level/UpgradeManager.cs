using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<Upgrade> allUpgrades = new List<Upgrade>();
    private Player player;
    private int itemCount = 10;

    private void Start()
    {
        // lijst van basic upgrades
        allUpgrades.Add(new Upgrade("Health Boost", "Increase max health by 10 & heal 10", UpgradeType.HealthBoost, intValue: 10));
        allUpgrades.Add(new Upgrade("Speed Boost", "Increase speed by 5%", UpgradeType.SpeedBoost, floatValue: 0.05f));
        allUpgrades.Add(new Upgrade("Claw Damage Boost", "Increase claw damage by 15", UpgradeType.ClawDamageBoost, intValue: 15));
        allUpgrades.Add(new Upgrade("Claw Range Boost", "Increase claw size by 10%", UpgradeType.ClawAOE, floatValue: 0.1f));
        allUpgrades.Add(new Upgrade("Claw Speed Boost", "Increase claw attack speed by 10%", UpgradeType.ClawSpeed, floatValue: 0.9f));
        allUpgrades.Add(new Upgrade("Big Health Boost", "Increase max health by 30 & heal 30", UpgradeType.HealthBoost, intValue: 30));
        allUpgrades.Add(new Upgrade("Big Speed Boost", "Increase speed by 15%", UpgradeType.SpeedBoost, floatValue: 0.15f));
        allUpgrades.Add(new Upgrade("Big Claw Damage Boost", "Increase claw damage by 20", UpgradeType.ClawDamageBoost, intValue: 20));
        allUpgrades.Add(new Upgrade("Big Claw Range Boost", "Increase claw size by 20%", UpgradeType.ClawAOE, floatValue: 0.2f));
        allUpgrades.Add(new Upgrade("Claw Speed Boost", "Increase claw attack speed by 20%", UpgradeType.ClawSpeed, floatValue: 0.8f));

        player = GameObject.FindGameObjectWithTag("PlayerCore").GetComponent<Player>();
    }

    // neem 3 random upgrades
    public List<Upgrade> GetRandomUpgrades(int count = 3)
    {
        List<Upgrade> randomUpgrades = new List<Upgrade>();
        List<Upgrade> copyOfAllUpgrades = new List<Upgrade>(allUpgrades);
        List<int> bannedNumbers = new List<int>();

        for (int i = 0; i < count; i++)
        {
            //int index = Random.Range(0, copyOfAllUpgrades.Count + itemCount);
            int index = 17;
            if(index >= copyOfAllUpgrades.Count)
            {
                if(bannedNumbers.Contains(index))
                {
                    randomUpgrades.Add(InvalidItem());
                }
                else
                {
                    randomUpgrades.Add(HandleItems(index - copyOfAllUpgrades.Count));
                    bannedNumbers.Add(index);
                }   
            }
            else
            {
                randomUpgrades.Add(copyOfAllUpgrades[index]);
                copyOfAllUpgrades.RemoveAt(index);
            }
        }

        return randomUpgrades;
    }

    public Upgrade HandleItems(int itemId)
    {
        switch(itemId)
        {
            case 0:
                switch(player.AuraLevel)
                {
                    case 0:
                        return new Upgrade("Frightening Aura Lvl1", "Deal damage to enemies around you", UpgradeType.AuraLevel, intValue: 1);
                    case 1:
                        return InvalidItem();
                }
                break;
            case 1:
                switch(player.BoulderLevel)
                {
                    case 0:
                        return new Upgrade("Boulder Throw Lvl1", "Surround yourself with boulders", UpgradeType.BoulderLevel, intValue: 1);
                    case 1:
                        return InvalidItem();
                }
                break;
            case 2:
                switch(player.BeamLevel)
                {
                    case 0:
                        return new Upgrade("Kaiju Beam Lvl1", "Fire a horizontal beam", UpgradeType.BeamLevel, intValue: 1);
                    case 1:
                        return InvalidItem();
                }
                break;
            case 3:
                switch(player.ArmsLevel)
                {
                    case 0:
                        return new Upgrade("Extra Arms Lvl1", "Add a back attack BUT lower damage by 50%", UpgradeType.ArmsLevel, intValue: 1);
                    case 1:
                        return InvalidItem();
                }
                break;
            case 4:
                switch(player.SurvivorLevel)
                {
                    case 0:
                        return new Upgrade("Adrenaline Lvl1", "Increase claw damage by 30 & increase speed by 20% BUT drop to 1 HP", UpgradeType.SurvivorLevel, intValue: 1);
                    case 1:
                        return InvalidItem();
                }
                break;
            case 5:
                switch(player.BigLevel)
                {
                    case 0:
                        return new Upgrade("Big Arms Lvl1", "Increase claw size by 50% BUT lower claw damage by 50%", UpgradeType.BigLevel, intValue: 1);
                    case 1:
                        return InvalidItem();
                }
                break;
            case 6:
                switch(player.VampireLevel)
                {
                    case 0:
                        return new Upgrade("Vampirism Lvl1", "10% change to heal 1% of max HP when killing enemy", UpgradeType.VampireLevel, intValue: 1);
                    case 1:
                        return InvalidItem();
                }
                break;
            case 7:
                switch(player.DominanceLevel)
                {
                    case 0:
                        return new Upgrade("Dominance Lvl1", "Increase claw damage relative to your size", UpgradeType.DominanceLevel, intValue: 1);
                    case 1:
                        return InvalidItem();
                }
                break;
            case 8:
                switch(player.SkinLevel)
                {
                    case 0:
                        return new Upgrade("Armored Skin Lvl1", "Increase defense by 50 BUT lower speed by 50%", UpgradeType.SkinLevel, intValue: 1);
                    case 1:
                        return new Upgrade("Armored Skin Lvl2", "Increase defense by 50 BUT lower speed by 50%", UpgradeType.SkinLevel, intValue: 1);
                    case 2:
                        return new Upgrade("Armored Skin Lvl3", "Increase defense by 50 BUT lower speed by 50%", UpgradeType.SkinLevel, intValue: 1);
                    case 3:
                        return new Upgrade("Armored Skin Lvl4", "Increase defense by 50 BUT lower speed by 50%", UpgradeType.SkinLevel, intValue: 1);
                    case 4:
                        return new Upgrade("Armored Skin Lvl5", "Increase defense by 50 BUT lower speed by 50%", UpgradeType.SkinLevel, intValue: 1);
                    case 5:
                        return InvalidItem();
                }
                break;
            case 9:
                switch(player.VelociraptorLevel)
                {
                    case 0:
                        return new Upgrade("Velociraptor Genes Lvl1", "Increase speed by 50% and increase claw attack speed by 50% BUT drop attack by 100", UpgradeType.VelociraptorLevel, intValue: 1);
                    case 1:
                        return new Upgrade("Velociraptor Genes Lvl2", "Increase speed by 50% and increase claw attack speed by 50% BUT drop attack by 100", UpgradeType.VelociraptorLevel, intValue: 1);
                    case 2:
                        return new Upgrade("Velociraptor Genes Lvl3", "Increase speed by 50% and increase claw attack speed by 50% BUT drop attack by 100", UpgradeType.VelociraptorLevel, intValue: 1);
                    case 3:
                        return InvalidItem();
                }
                break;
        }
        return InvalidItem();
    }

    public Upgrade InvalidItem()
    {
        int index = Random.Range(0, allUpgrades.Count);
        return allUpgrades[index];
    }


}
