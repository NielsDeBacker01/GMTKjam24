using UnityEngine;

public class AimAttack : MonoBehaviour
{
    [SerializeField] SpriteRenderer player;
    private void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if(direction.x > 0.1)
        {
            player.flipX = false;
        }
        else if(direction.x < -0.1)
        {
            player.flipX = true;
        }
    }
}
