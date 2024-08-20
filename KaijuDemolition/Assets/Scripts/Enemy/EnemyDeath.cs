using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDeath : MonoBehaviour
{
    public GameObject exp;
    public GameObject hp;
    private Enemy enemy;
    [SerializeField] private bool boss = false;
    private AudioManager audioManager;
    public float rng = 0.01f;

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
                float buildingSize = this.gameObject.transform.localScale.x * this.gameObject.transform.localScale.y;

                GameObject massInstance = Instantiate(exp, transform.position, Quaternion.identity);

                PickUpMass pickUpMass = massInstance.GetComponent<PickUpMass>();
                if (pickUpMass != null)
                {
                    pickUpMass.Initialize(buildingSize);
                }

                float randomValue = Random.Range(0f, 1f);
                if (randomValue <= rng)
                {
                    Instantiate(hp, transform.position, Quaternion.identity);
                }

                Destroy(this.gameObject);
            }
        }
    }
}
