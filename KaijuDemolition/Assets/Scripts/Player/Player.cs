using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP;
    public int baseMaxHP = 100;
    [SerializeField] private float baseSpeed = 3f;
    [SerializeField] private int baseClawDamage = 1;
    public float invincibilityCooldown = 0.1f;
    public float baseAttackActiveTime = 0.25f;

    private void Start()
    {
        HP = baseMaxHP; 
    }

    public float getSpeed()
    {
        return (float)(baseSpeed * Math.Sqrt(this.transform.lossyScale.x ));
    }

    public float getDamage()
    {
        return baseClawDamage;
    }
}
