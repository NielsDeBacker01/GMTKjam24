using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    [SerializeField] private int baseMaxHP = 10;
    private GameObject playerObject;
    private Player playerValues;
    public int speed = 3;
    public int damage = 1;
    private float cooldown;

    private void Start()
    {
        HP = baseMaxHP;
        cooldown = 0;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerValues = playerObject.GetComponent<Player>();
    }

    private void Update()
    {
        //cooldown for damage
        cooldown -= Time.deltaTime;

        //move towards player
        Vector3 direction = (playerObject.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("PlayerAttack") && cooldown <= 0)
        {
            HP -= playerValues.getDamage();
            cooldown = playerValues.baseAttackActiveTime;
            Debug.Log(HP);
        }
    }
}
