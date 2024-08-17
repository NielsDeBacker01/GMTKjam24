using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    [SerializeField] private int baseMaxHP = 10;
    [SerializeField] Player player;
    public int speed = 3;
    public int damage = 1;
    private float cooldown;
    private void Start()
    {
        HP = baseMaxHP;
        cooldown = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("PlayerAttack") && cooldown <= 0)
        {
            HP -= player.getDamage();
            cooldown = player.baseAttackActiveTime;
            Debug.Log(HP);
        }
    }

}
