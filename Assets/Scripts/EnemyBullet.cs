using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform player; // Reference to the player's transform
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float destroyTime = 2f;
    [SerializeField] private float fireRange = 10f; // Distance at which the enemy detects the player

    private float nextFireTime;
    
    void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (player == null) return;

        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Fire only if the player is within range and in front of the enemy
        if (distanceToPlayer <= fireRange && IsFacingPlayer(directionToPlayer))
        {
            if (Time.time >= nextFireTime)
            {
                Fire(directionToPlayer);
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    private bool IsFacingPlayer(Vector2 directionToPlayer)
    {
        return (transform.localScale.x > 0 && directionToPlayer.x > 0) || 
               (transform.localScale.x < 0 && directionToPlayer.x < 0);
    }

    private void Fire(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        if (bullet.TryGetComponent(out Rigidbody2D rb))
        {
            rb.linearVelocity = direction * bulletSpeed;
        }

        Destroy(bullet, destroyTime);
    }
}
