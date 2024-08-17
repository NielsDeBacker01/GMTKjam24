using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMass : MonoBehaviour
{
    public float massAmount = 0.1f; 
    private PlayerMass playerMass;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerMass = player.GetComponent<PlayerMass>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            if (playerMass != null)
            {
                playerMass.AddMass(massAmount);
            }
            Destroy(gameObject);
        }
    }
}
