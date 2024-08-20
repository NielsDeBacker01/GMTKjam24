using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicControls: MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    [SerializeField] Player player;
    Vector2 movement;
    Vector2 movementInput;
    public Animator animator;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = false;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        movement = movementInput * player.getSpeed();
        rigidbody2D.velocity = movement;

        if (movement != new Vector2(0, 0)) animator.SetBool("moving", true);
        else animator.SetBool("moving", false);
    }
}