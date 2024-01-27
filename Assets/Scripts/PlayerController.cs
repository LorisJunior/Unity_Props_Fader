using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public float speed = 5f;

    private Vector2 move;
    private Vector2 lookDirection;
    private Rigidbody2D rigidbody2d;
    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        moveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        #region Player input

        move = moveAction.ReadValue<Vector2>();
        PlayerDirection();
        UpdateAnimations();

        #endregion
    }

    private void FixedUpdate()
    {
        rigidbody2d.MovePosition(rigidbody2d.position + move * speed * Time.deltaTime);
    }

    private void PlayerDirection()
    {
        if (!Mathf.Approximately(move.x, 0f) || !Mathf.Approximately(move.y, 0f))
        {
            lookDirection = move;
            lookDirection.Normalize();
        }
    }

    private void UpdateAnimations()
    {
        animator.SetFloat(Animations.moveX, lookDirection.x);
        animator.SetFloat(Animations.moveY, lookDirection.y);
        animator.SetFloat(Animations.speed, move.magnitude);
    }
}
