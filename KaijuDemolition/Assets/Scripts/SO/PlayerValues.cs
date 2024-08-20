using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerValues : ScriptableObject
{
    public int HP;
    public int baseMaxHP = 100;
    public int maxHPIncrease = 0;
    public float baseSpeed = 3f;
    public float speedMult = 1f;
    public float baseAOE = 3f;
    public int defense = 0;
    public float AOEmult = 1f;
    public int baseClawDamage = 1;
    public int clawDamageBoost = 0;
    public float invincibilityCooldown = 0.1f;
    public float baseAttackActiveTime = 0.25f;
    public float attackCooldown= 0.5f;
    public float attackCooldownMult= 1f;
    public int currentExp = 0;
    public int maxExp = 100;
    public int level = 1;
    public int auraLevel = 1;
    public int boulderLevel = 1;
    public int beamLevel = 1;
    public int armsLevel = 1;
    public int survivorLevel = 1;
    public int bigLevel = 1;
    public int vampireLevel = 1;
    public int dominanceLevel = 1;
    public int skinLevel = 1;
    public int velociraptorLevel = 1;
}
