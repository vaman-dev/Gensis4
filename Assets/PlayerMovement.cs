using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 move;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Animator animation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>(); // the value of the input is stored in the vector accessing them
        // giving them into the new move
        move = new Vector2(moveInput.x, moveInput.y);
    }

    void Run()
    {
        rb.linearVelocity = new Vector2(move.x * moveSpeed, move.y * moveSpeed);
        
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            animation.SetBool("Idle", false);
            animation.SetBool("Moving", true);
        }
        else
        {
            animation.SetBool("Idle", true);
            animation.SetBool("Moving", false);
        }
    }
}