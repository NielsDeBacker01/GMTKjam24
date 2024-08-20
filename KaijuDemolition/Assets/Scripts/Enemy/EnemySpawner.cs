using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy1_1;
    [SerializeField] private GameObject enemy1_2;
    [SerializeField] private GameObject enemy1_3;
    [SerializeField] private GameObject enemy1_X;
    [SerializeField] private GameObject enemy2_1;
    [SerializeField] private GameObject enemy2_2;
    [SerializeField] private GameObject enemy2_3;
    [SerializeField] private GameObject enemy2_X;
    [SerializeField] private GameObject enemy3_1;
    [SerializeField] private GameObject enemy3_2;
    [SerializeField] private GameObject enemy3_3;
    [SerializeField] private GameObject enemy3_X;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float cooldown = 1.5f;
    [SerializeField] private Transform player;
    private float timerValue = 0;
    private float scale1Stop = 0;
    private float scale2Stop = 0;
    private float scaleBossSpawn = 0;
    private bool bossSpawned;

    private void Start()
    {
        timerValue = 0;
        bossSpawned = false;

        switch(SceneManager.GetActiveScene().name)
        {
            case "Stage1City":
                scale1Stop = 10;
                scale2Stop = 20;
                scaleBossSpawn = 40;
                break;
            case "Stage2World":
                scale1Stop = 10;
                scale2Stop = 24;
                scaleBossSpawn = 40;
                break;       
            case "Stage3Space":
                scale1Stop = 8;
                scale2Stop = 20;
                scaleBossSpawn = 30;
                break;
        }

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if(timerValue < 70)
            {
                for (int i = (int)Math.Ceiling(timerValue/10); i > 0; i--)
                {
                    spawnEnemy(1);
                }
            }
            else if(player.lossyScale.x < scale1Stop && 70 < timerValue)
            {
                for (int i = 0; i < 4; i++)
                {
                    spawnEnemy(1);
                }
            }

            if(timerValue > 50 && 120 > timerValue)
            {
                for (int i = (int)Math.Ceiling((timerValue-50)/10); i > 0; i--)
                {
                    spawnEnemy(2);
                }
            }
            else if(player.lossyScale.x < scale2Stop && 120 < timerValue)
            {
                for (int i = 0; i < 4; i++)
                {
                    spawnEnemy(2);
                }
            }

            if(timerValue > 100 && 180 > timerValue)
            {
                for (int i = (int)Math.Ceiling((timerValue-50)/10); i > 0; i--)
                {
                    spawnEnemy(3);
                }
            }
            else if(player.lossyScale.x < scale2Stop && 180 < timerValue)
            {
                for (int i = 0; i < 4; i++)
                {
                    spawnEnemy(3);
                }
            }
            
            if(player.lossyScale.x > scaleBossSpawn)
            {
                if(!bossSpawned)
                {
                    spawnBoss();
                    bossSpawned = true;
                }
            }

            yield return new WaitForSeconds(cooldown);
        }
    }

    private void FixedUpdate() {
        timerValue += Time.deltaTime;
    }

    private void spawnEnemy(int number)
    {
        float randomAngle = UnityEngine.Random.Range(0f, Mathf.PI * 2);
        Vector3 spawnPosition = new Vector3(
            Mathf.Cos(randomAngle) * (float)(radius * player.lossyScale.x ),    
            Mathf.Sin(randomAngle) * (float)(radius * player.lossyScale.x ),    
            0f                                  
        );
        spawnPosition += this.gameObject.transform.position;
        switch(SceneManager.GetActiveScene().name)
        {
            case "Stage1City":
                if(number == 1)
                {
                    Instantiate(enemy1_1, spawnPosition, Quaternion.identity);
                }else if(number == 2)
                {
                    Instantiate(enemy1_2, spawnPosition, Quaternion.identity);
                }else if(number == 3)
                {
                    Instantiate(enemy1_3, spawnPosition, Quaternion.identity);
                }
                break;
            case "Stage2World":
                if(number == 1)
                {
                    Instantiate(enemy2_1, spawnPosition, Quaternion.identity);
                }else if(number == 2)
                {
                    Instantiate(enemy2_2, spawnPosition, Quaternion.identity);
                }else if(number == 3)
                {
                    Instantiate(enemy2_3, spawnPosition, Quaternion.identity);
                }
                break;       
            case "Stage3Space":
                if(number == 1)
                {
                    Instantiate(enemy3_1, spawnPosition, Quaternion.identity);
                }else if(number == 2)
                {
                    Instantiate(enemy3_2, spawnPosition, Quaternion.identity);
                }else if(number == 3)
                {
                    Instantiate(enemy3_3, spawnPosition, Quaternion.identity);
                }
                break;
        }
    }

    private void spawnBoss()
    {
        float randomAngle = UnityEngine.Random.Range(0f, Mathf.PI * 2);
        Vector3 spawnPosition = new Vector3(
            Mathf.Cos(randomAngle) * (float)(radius * Math.Sqrt(player.lossyScale.x ) * 2),    
            Mathf.Sin(randomAngle) * (float)(radius * Math.Sqrt(player.lossyScale.x ) * 2),    
            0f                                  
        );
        spawnPosition += this.gameObject.transform.position;
        switch(SceneManager.GetActiveScene().name)
        {
            case "Stage1City":
                Instantiate(enemy1_X, spawnPosition, Quaternion.identity);
                break;
            case "Stage2World":
                Instantiate(enemy2_X, spawnPosition, Quaternion.identity);
                break;       
            case "Stage3Space":
                Instantiate(enemy3_X, spawnPosition, Quaternion.identity);
                break;
        }
        
    }
}