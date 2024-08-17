using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDestroy : MonoBehaviour
{
    public GameObject mass;
    private Building building;
    private bool isQuitting = false;

    void Start()
    {
        building = GetComponent<Building>();
    }

    void FixedUpdate()
    {
        if (building != null)
        {
            if (building.HP <= 0)
                Destroy(this.gameObject);
        }
    }
    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(mass, new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z), Quaternion.identity);

        }
    }
}
