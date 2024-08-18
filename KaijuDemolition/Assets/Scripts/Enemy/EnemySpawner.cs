using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject boss;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float cooldown = 1.5f;
    [SerializeField] private Transform player;
    private float timerValue = 0;
    private bool bossSpawned;

    private void Start()
    {
        timerValue = 0;
        StartCoroutine(SpawnEnemies());
        bossSpawned = false;
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if(timerValue < 50)
            {
                for (int i = (int)Math.Ceiling(timerValue/10); i > 0; i--)
                {
                    spawnEnemy();
                }
            }
            else if(timerValue > 50 && 100 > timerValue)
            {
                if(!bossSpawned)
                {
                    spawnBoss();
                    bossSpawned = true;
                }
            }

            yield return new WaitForSeconds(cooldown);
            Debug.Log(timerValue);
        }
    }

    private void FixedUpdate() {
        timerValue += Time.deltaTime;
    }

    private void spawnEnemy()
    {
        float randomAngle = UnityEngine.Random.Range(0f, Mathf.PI * 2);
        Vector3 spawnPosition = new Vector3(
            Mathf.Cos(randomAngle) * (float)(radius * Math.Sqrt(player.lossyScale.x )),    
            Mathf.Sin(randomAngle) * (float)(radius * Math.Sqrt(player.lossyScale.x )),    
            0f                                  
        );
        spawnPosition += this.gameObject.transform.position;
        Instantiate(enemy1, spawnPosition, Quaternion.identity);
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
        Instantiate(boss, spawnPosition, Quaternion.identity);
    }
}