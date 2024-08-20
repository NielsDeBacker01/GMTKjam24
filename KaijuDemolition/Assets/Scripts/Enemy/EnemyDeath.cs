using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDeath : MonoBehaviour
{
    public GameObject exp;
    private Enemy enemy;
    [SerializeField] private bool boss = false;
    [SerializeField] private float expMult = 1f;
    private AudioManager audioManager;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void FixedUpdate()
    {
        if (enemy != null)
        {
            if (enemy.HP <= 0)
            {
                if(boss)
                {
                    if(SceneManager.GetActiveScene().name == "Stage1City")
                    {
                        SceneManager.LoadScene("Stage2World");
                    }
                    if(SceneManager.GetActiveScene().name == "Stage2World")
                    {
                        SceneManager.LoadScene("Stage3Space");
                    }
                    if(SceneManager.GetActiveScene().name == "Stage3Space")
                    {
                        GameObject.FindGameObjectWithTag("UI").GetComponent<UIControls>().Victory();
                    }
                    
                }
                audioManager.playEnemyDeathSound();

                Renderer renderer = GetComponent<Renderer>();

                GameObject expInstance = Instantiate(exp, transform.position, Quaternion.identity);

                PickUpExp pickUpMass = expInstance.GetComponent<PickUpExp>();
                if (pickUpMass != null)
                {
                    pickUpMass.Initialize(expMult);
                }

                Destroy(this.gameObject);
            }
        }
    }
}
