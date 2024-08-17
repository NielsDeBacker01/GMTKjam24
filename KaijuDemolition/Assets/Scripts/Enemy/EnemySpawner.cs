using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float cooldown = 1.5f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float randomAngle = Random.Range(0f, Mathf.PI * 2);
            Vector3 spawnPosition = new Vector3(
                Mathf.Cos(randomAngle) * radius,    
                Mathf.Sin(randomAngle) * radius,    
                0f                                  
            );
            spawnPosition += this.gameObject.transform.position;
            Instantiate(theEnemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(cooldown);
        }
    }
}