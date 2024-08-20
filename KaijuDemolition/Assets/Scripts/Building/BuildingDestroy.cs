using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDestroy : MonoBehaviour
{
    public GameObject mass;
    private Building building;
    private AudioManager audioManager;

    void Start()
    {
        building = GetComponent<Building>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void FixedUpdate()
    {
        if (building != null)
        {
            if (building.HP <= 0)
            {
                audioManager.playExplodeSound();
                Destroy(this.gameObject);

                Renderer renderer = GetComponent<Renderer>();
                float buildingSize = (int)Math.Floor(Math.Sqrt(Math.Sqrt( this.gameObject.transform.localScale.x * this.gameObject.transform.localScale.y )));

                GameObject massInstance = Instantiate(mass, transform.position, Quaternion.identity);

                PickUpMass pickUpMass = massInstance.GetComponent<PickUpMass>();
                if (pickUpMass != null)
                {
                    pickUpMass.Initialize(buildingSize);
                }
            }
        }
    }
}
