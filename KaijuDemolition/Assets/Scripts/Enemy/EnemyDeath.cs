using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject prefab;
    private Enemy enemy;

    void Update()
    {
        if (this.gameObject.GetComponent<Enemy>().HP <= 0)
            Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        Instantiate(prefab, new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z), Quaternion.identity);
    }
}
