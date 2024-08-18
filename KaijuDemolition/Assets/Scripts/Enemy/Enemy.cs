using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP;
    [SerializeField] private int baseMaxHP = 10;
    private GameObject playerObject;
    private Player player;
    public float speed = 3;
    public int damage = 1;
    private float cooldown;
    private float playerCooldown;

    private void Start()
    {
        HP = baseMaxHP;
        cooldown = 0;
        playerObject = GameObject.FindGameObjectWithTag("PlayerCore");
        player = playerObject.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        //cooldown for damage
        cooldown -= Time.deltaTime;
        playerCooldown -= Time.deltaTime;

        //move towards player
        Vector3 direction = (playerObject.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("PlayerAttack") && cooldown <= 0)
        {
            HP -= player.getDamage();
            cooldown = player.getBaseAttackActiveTime();
        }

        if(other.gameObject.CompareTag("Player") && playerCooldown <= 0)
        {
            player.loseHP(damage);
            playerCooldown = player.getInvincibilityCooldown();
        }
    }
}
