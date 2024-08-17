using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int HP;
    [SerializeField] private int baseMaxHP = 10;
    private GameObject playerObject;
    private Player playerValues;
    private float cooldown;

    private void Start()
    {
        HP = baseMaxHP;
        cooldown = 0;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerValues = playerObject.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        //cooldown for damage
        cooldown -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerAttack") && cooldown <= 0)
        {
            HP -= playerValues.getDamage();
            cooldown = playerValues.baseAttackActiveTime;
            Debug.Log(HP);
        }
    }
}
