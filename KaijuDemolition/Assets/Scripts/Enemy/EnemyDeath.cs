using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject exp;
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FixedUpdate()
    {
        if (enemy != null)
        {
            if (enemy.HP <= 0)
                Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        Instantiate(exp, new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z), Quaternion.identity);
    }
}
