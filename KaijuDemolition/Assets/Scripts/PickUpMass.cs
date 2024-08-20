using System;
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
        massAmount *= buildingSize;
        this.transform.localScale = new Vector3((float)(0.3 * Math.Pow(buildingSize,2)),(float)(0.3 * Math.Pow(buildingSize,2)),1);
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
