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
    private float auraCooldown;
    private float rockCooldown;
    private float playerCooldown;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioSource sfx2;
    [SerializeField] AudioValues volume;
    [SerializeField] Animator animator;
    private float timer;

    private void Start()
    {
        HP = baseMaxHP;
        cooldown = 0;
        auraCooldown = 0;
        rockCooldown = 0;
        playerObject = GameObject.FindGameObjectWithTag("PlayerCore");
        player = playerObject.GetComponent<Player>();
        animator = player.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //cooldown for damage
        cooldown -= Time.deltaTime;
        auraCooldown -= Time.deltaTime;
        rockCooldown -= Time.deltaTime;
        playerCooldown -= Time.deltaTime;

        //move towards player
        Vector3 direction = (playerObject.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        if(sprite != null)
        {
            if(direction.x > 0.1)
            {
                sprite.flipX = false;
            }
            else if(direction.x < -0.1)
            {
                sprite.flipX = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("PlayerAttack") && cooldown <= 0)
        {
            sfx.volume = volume.sfx;
            sfx.Play();
            HP -= player.getDamage();
            player.vampire();
            cooldown = player.getBaseAttackActiveTime();
        }

        if(other.gameObject.CompareTag("AuraAttack") && auraCooldown <= 0)
        {
            sfx.volume = volume.sfx / 4;
            sfx.Play();
            float damage = player.getDamage() * (player.AuraLevel / 10);
            if(damage < 0.5f)
            {
                damage = 0.5f;
            }
            HP -= damage;
            player.vampire();
            auraCooldown = player.getBaseAttackActiveTime() / 2;
        }
        
        if(other.gameObject.CompareTag("RockAttack") && rockCooldown <= 0)
        {
            sfx.volume = volume.sfx / 4;
            sfx.Play();
            float damage = player.getDamage() * (player.BoulderLevel / 8);
            if(damage < 0.5f)
            {
                damage = 0.5f;
            }
            HP -= damage;
            player.vampire();
            rockCooldown = player.getBaseAttackActiveTime() / 2;
        }

        if(other.gameObject.CompareTag("Player") && playerCooldown <= 0)
        {
            player.loseHP(damage);
            PlayAnimation();
            sfx2.volume = volume.sfx;
            sfx2.Play();
            playerCooldown = player.getInvincibilityCooldown();
        }
    }

    void PlayAnimation()
    {
        timer += Time.deltaTime;
        if(timer < 2)
            animator.SetBool("hit", true);
        else
            animator.SetBool("hit", true);
    }
}
