using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;  
    [SerializeField] private float thresholdX = 4f;  
    [SerializeField] private float thresholdY = 4f;  
    [SerializeField] private float smoothSpeed = 0.125f; 

    private Vector3 offset;  

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        Vector3 currentPosition = transform.position;
        float deltaX = Mathf.Abs(currentPosition.x - targetPosition.x);
        float deltaY = Mathf.Abs(currentPosition.y - targetPosition.y);
        if (deltaX > thresholdX)
        {
            currentPosition.x = Mathf.Lerp(currentPosition.x, targetPosition.x, smoothSpeed);
        }
        if (deltaY > thresholdY)
        {
            currentPosition.y = Mathf.Lerp(currentPosition.y, targetPosition.y, smoothSpeed);
        }
        transform.position = currentPosition;
    }
}
