using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerValuesReset : MonoBehaviour
{
    [SerializeField] private PlayerValues playerValues;
    public void Initialize()
    {
        playerValues.HP = playerValues.baseMaxHP; 
        playerValues.maxHPIncrease = 0;
        playerValues.speedMult = 1f;
        playerValues.AOEmult = 1f;
        playerValues.clawDamageBoost = 0;
        playerValues.maxExp = 100;
        playerValues.currentExp = 0;
        playerValues.level = 1;
        playerValues.auraLevel = 0;
        playerValues.boulderLevel = 0;
        playerValues.beamLevel = 0;
        playerValues.armsLevel = 0;
        playerValues.survivorLevel = 0;
        playerValues.bigLevel = 0;
        playerValues.vampireLevel = 0;
        playerValues.dominanceLevel = 0;
        playerValues.skinLevel = 0;
        playerValues.velociraptorLevel = 0;
        playerValues.attackCooldownMult = 1;
        playerValues.defense = 0;
    }

    public void Start()
    {
        if(SceneManager.GetActiveScene().name == "Stage1City")
        {
            Initialize();
        }
    }


}
