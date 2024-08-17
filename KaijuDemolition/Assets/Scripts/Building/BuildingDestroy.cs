using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDestroy : MonoBehaviour
{
    public GameObject mass;
    private Building building;

    void Start()
    {
        building = GetComponent<Building>();
    }

    void FixedUpdate()
    {
        if (building != null)
        {
            if (building.HP <= 0)
            {
                Instantiate(mass, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
