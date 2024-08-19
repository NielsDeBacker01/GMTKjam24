using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDeath : MonoBehaviour
{
    public GameObject exp;
    private Enemy enemy;
    [SerializeField] private bool boss = false;
    [SerializeField] private EnemyCounter enemyCounter;
    void Start()
    {
        enemy = GetComponent<Enemy>();
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
                    
                }
                Instantiate(exp, new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z), Quaternion.identity);
                enemyCounter.counter--;
                Destroy(this.gameObject);
            }
        }
    }
}
