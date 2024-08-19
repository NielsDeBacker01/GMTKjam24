using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounterReset : MonoBehaviour
{
    [SerializeField] private EnemyCounter enemyCounter;
    public void Initialize()
    {
        enemyCounter.counter = 0;
    }

    public void Start()
    {
        Initialize();
    }


}
