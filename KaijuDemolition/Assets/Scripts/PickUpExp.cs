using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpExp : MonoBehaviour
{
    public int expAmount = 10; // Hoeveel EXP de speler oppakt
    private PlayerExp playerExp;

    void Start()
    {
        // Verwijzing naar de PlayerExperience-component van de speler
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerExp = player.GetComponent<PlayerExp>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Controleren of de speler het object aanraakt
        if (other.CompareTag("Player"))
        {
            if (playerExp != null)
            {
                playerExp.AddExperience(expAmount); // Voeg EXP toe aan de speler
            }
            Destroy(gameObject); // Verwijder het EXP-object
        }
    }
}
