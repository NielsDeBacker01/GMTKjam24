using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMass : MonoBehaviour
{
    public float massAmount; 
    private PlayerMass playerMass;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerCore");
        if (player != null)
        {
            playerMass = player.GetComponent<PlayerMass>();
        }
    }

    public void Initialize(float buildingSize)
    {
        // Scale massAmount based on the building size
        massAmount *= buildingSize;
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
