using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP;
    [SerializeField] private int baseMaxHP = 100;
    [SerializeField] private float baseSpeed = 3f;
    [SerializeField] private int baseClawDamage = 1;
    public float invincibilityCooldown = 0.1f;
    public float baseAttackActiveTime = 0.25f;
    private float cooldown;
    public BarSlider slider;

    private void Start()
    {
        HP = baseMaxHP; 
    }

    private void FixedUpdate()
    {
        cooldown -= Time.deltaTime;
        slider.SetBar(HP);
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
