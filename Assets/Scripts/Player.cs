using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    private Vector2 move;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Animator animation;
    public float delaytime = 2f; 
    public float jumpForce = 1f;
    private BoxCollider2D myFeetCollider;
    private bool isAlive = true;
    private SpriteRenderer playerSpriteRenderer; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Run();
        flipSprite();
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>(); // the value of the input is stored in the vector accessing them
        // giving them into the new move
        move = new Vector2(moveInput.x, moveInput.y);
    }

    void Run()
    {
        rb.linearVelocity = new Vector2(move.x * moveSpeed, rb.linearVelocity.y);
        
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gate"))
        {
            Debug.Log("You have reached the gate");
            StartCoroutine(LoadNextScene()); // Correct coroutine usage
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(delaytime); 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        
        if (value.isPressed)
        {
            rb.linearVelocity += new Vector2(0f, jumpForce);
        }
    }

    void flipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            playerSpriteRenderer.flipX = rb.linearVelocity.x < 0;
            // for the changing the direction using the linear velocity of the player 
            // best method instead of the tranform.loaclscale 
        }
    }
}