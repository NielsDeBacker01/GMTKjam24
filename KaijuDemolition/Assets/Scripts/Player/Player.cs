using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP;
    [SerializeField] private int baseMaxHP = 100;
    [SerializeField] private int baseSpeed = 3;
    [SerializeField] private int baseClawDamage = 1;
    [SerializeField] private float invincibilityCooldown = 0.1f;
    public float baseAttackActiveTime = 0.25f;
    private float cooldown;

    private void Start()
    {
        HP = baseMaxHP;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy") && cooldown <= 0)
        {
            HP -= other.gameObject.GetComponent<Enemy>().damage;
            cooldown = invincibilityCooldown;
            Debug.Log(HP);
        }
    }

    public int getSpeed()
    {
        return baseSpeed;
    }

    public int getDamage()
    {
        return baseClawDamage;
    }
}
