using UnityEngine;

public class AimAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackObject;   
    public Player playerValues;
    [SerializeField] SpriteRenderer player;
    [SerializeField] SpriteRenderer attack;
    [SerializeField] private bool alwaysSpin = false;
    float attackAngle;
    public void Start()
    {
        playerValues = GameObject.FindGameObjectWithTag("PlayerCore").GetComponent<Player>();
    }
    private void FixedUpdate()
    {
        attackObject.transform.localScale = new Vector3(1,playerValues.getAoe(),1);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(alwaysSpin || !attackObject.activeInHierarchy)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            if(direction.x > 0.1)
            {
                player.flipX = false;
                if(!alwaysSpin)
                {
                    attack.flipY = false;
                }
            }
            else if(direction.x < -0.1)
            {
                player.flipX = true;
                if(!alwaysSpin)
                {
                    attack.flipY = false;
                }
            }
        }
    }
}
