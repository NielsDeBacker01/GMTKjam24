using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float cooldown = 1.5f;
    [SerializeField] private Transform player;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float randomAngle = UnityEngine.Random.Range(0f, Mathf.PI * 2);
            Vector3 spawnPosition = new Vector3(
                Mathf.Cos(randomAngle) * (float)(radius * Math.Sqrt(player.lossyScale.x )),    
                Mathf.Sin(randomAngle) * (float)(radius * Math.Sqrt(player.lossyScale.x )),    
                0f                                  
            );
            spawnPosition += this.gameObject.transform.position;
            Instantiate(theEnemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
        }
    }
}