using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValuesReset : MonoBehaviour
{
    [SerializeField] private PlayerValues playerValues;
    public void Initialize()
    {
        playerValues.HP = playerValues.baseMaxHP; 
    }
}
