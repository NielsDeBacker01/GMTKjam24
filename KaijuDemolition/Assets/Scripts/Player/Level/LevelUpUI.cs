using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    public GameObject upgradePanel;
    public Button[] upgradeButtons;
    private UpgradeManager upgradeManager;
    private Player player;


    private void Start()
    {
        upgradeManager = FindObjectOfType<UpgradeManager>();
        player = FindObjectOfType<Player>();
        upgradePanel.SetActive(false); // Hide panel initially
    }

    public void ShowUpgrades()
    {
        
        List<Upgrade> upgrades = upgradeManager.GetRandomUpgrades();

        for (int i = 0; i < upgrades.Count; i++)
        {
            Upgrade upgrade = upgrades[i];
            foreach(TextMeshProUGUI textElements in upgradeButtons[i].GetComponentsInChildren<TextMeshProUGUI>())
            {
                if(textElements.tag == "Description")
                {
                    textElements.text = upgrade.description;
                } 
                else{
                    textElements.text = upgrade.upgradeName;
                }
            }
            upgradeButtons[i].onClick.RemoveAllListeners();
            upgradeButtons[i].onClick.AddListener(() => ApplyUpgrade(upgrade));
        }

        upgradePanel.SetActive(true);
        Time.timeScale = 0;
    }


    public void ApplyUpgrade(Upgrade upgrade)
    {
        upgrade.ApplyUpgrade(player);
        upgradePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
