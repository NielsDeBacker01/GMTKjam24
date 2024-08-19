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
        playerValues.clawDamageBoost = 0;
        playerValues.maxExp = 100;
        playerValues.currentExp = 0;
        playerValues.level = 1;
    }

    public void Start()
    {
        if(SceneManager.GetActiveScene().name == "Stage1City")
        {
            Initialize();
        }
    }


}
