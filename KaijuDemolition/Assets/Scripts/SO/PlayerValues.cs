using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerValues : ScriptableObject
{
    public int HP;
    public int baseMaxHP = 100;
    public float baseSpeed = 3f;
    public int baseClawDamage = 1;
    public float invincibilityCooldown = 0.1f;
    public float baseAttackActiveTime = 0.25f;
    public int currentExp = 0;
    public int maxExp = 100;
}
