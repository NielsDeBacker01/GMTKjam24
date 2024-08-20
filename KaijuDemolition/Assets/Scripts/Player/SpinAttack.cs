using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAttack : MonoBehaviour
{

    public float spinSpeed;

    void FixedUpdate()
    {
        transform.RotateAround(this.transform.position, Vector3.forward, spinSpeed * Time.deltaTime);
    }
}
