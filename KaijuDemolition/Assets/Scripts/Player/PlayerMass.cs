using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMass : MonoBehaviour
{
    public float currentMass = 1.0f;
    private Vector3 targetScale;
    public float scaleSpeed = 1f;
    public float zoom = 5f;
    [SerializeField] private new Camera camera;

    void Start()
    {
        targetScale = new Vector3(1f, 1f, 1f);
    }

    public void AddMass(float amount)
    {
        currentMass += amount;
        targetScale = new Vector3(currentMass, currentMass, 1f);
    }

    private void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
        if(camera.orthographicSize - zoom <= targetScale.x)
        {
            camera.orthographicSize += scaleSpeed * Time.deltaTime;
        }
    }
}
