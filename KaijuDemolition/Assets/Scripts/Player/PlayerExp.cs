using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public int currentExp = 0;

    public void AddExperience(int amount)
    {
        currentExp += amount;
        Debug.Log("EXP toegevoegd: " + amount + ". Totale EXP: " + currentExp);
    }
}
