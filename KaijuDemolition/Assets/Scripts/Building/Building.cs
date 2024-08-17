using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int HP;
    private float size;
    [SerializeField] private int baseMaxHP = 10;
    [SerializeField] private GameObject player;
    private Player playerValues;
    private float cooldown;
    private float playersize;

    private void Start()
    {
        HP = baseMaxHP;
        size = this.gameObject.transform.localScale.x * this.gameObject.transform.localScale.y * this.gameObject.transform.localScale.z;
        cooldown = 0;
        player = GameObject.FindGameObjectWithTag("PlayerCore");
        playerValues = player.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        //cooldown for damage
        cooldown -= Time.deltaTime;
        playersize = player.transform.localScale.x * player.transform.localScale.y * player.transform.localScale.z;

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerAttack") && cooldown <= 0)
        {
            if (size <= playersize)
                HP = 0;
            else
            {
                HP -= playerValues.getDamage();
                cooldown = playerValues.baseAttackActiveTime;
                Debug.Log(HP);
            }
        }

        if(other.gameObject.CompareTag("Player"))
        {
            if (size <= playersize)
                HP = 0;
        }
    }
}
