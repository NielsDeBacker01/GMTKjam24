using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    [SerializeField]
    private float lowerLimit;
    [SerializeField]
    private float upperLimit;
    private bool isFacingRight = false;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= lowerLimit)
            isFacingRight = false;
        if (transform.position.x >= upperLimit)
            isFacingRight = true;

    }

    private void FixedUpdate()
    {
        if (isFacingRight)
        {
            transform.position += new Vector3(-0.2f, 0f, 0f);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (!isFacingRight)
        {
            transform.position += new Vector3(0.2f, 0f, 0f);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }


}
