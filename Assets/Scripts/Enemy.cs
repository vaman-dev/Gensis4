using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float detectionRange = 5f;
    private Animator enemyAnimator;
    private SpriteRenderer enemySpriteRenderer; 

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        EnemyRun();
    }

    void EnemyRun()
    {
        if (player == null) return;

        Vector2 directionToPlayer = (player.position - transform.position).normalized;
         // for calulating the direction of the player .normalized is used to get the direction of the player and the difference for the direction 
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // If player is within detection range, move towards them
        if (distanceToPlayer < detectionRange)
        {
            transform.position += (Vector3)directionToPlayer * speed * Time.deltaTime;
            enemyAnimator.SetBool("Moving", true);
            enemyAnimator.SetBool("Idle", false);

            // Flip enemy based on direction
           enemySpriteRenderer.flipX = directionToPlayer.x < 0;
            // if the direction of the player is less than 0 then the sprite will flip to the left

        }
        else
        {
            enemyAnimator.SetBool("Moving", false);
            enemyAnimator.SetBool("Idle", true);
        }
    }
}
