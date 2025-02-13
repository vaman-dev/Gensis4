using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign the bullet prefab in the Inspector
    public Transform firePoint; // Assign the fire point (empty GameObject where the bullet spawns)
    public float bulletSpeed = 20f; // Speed of the bullet
    public float fireRate = 0.5f; // Time between shots
    public float destroyTime = 1f; // Time before bullet destroys itself
    public Rigidbody2D playerRb; // Reference to the player's Rigidbody2D
    private float nextFireTime = 0f;
    private bool facingRight = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }

        // Check player movement direction to update facing direction
        if (playerRb.linearVelocity.x > 0)
            facingRight = true;
        else if (playerRb.linearVelocity.x < 0)
            facingRight = false;
    }

    void Fire()
    {
        Vector2 direction = facingRight ? Vector2.right : Vector2.left;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }
        Destroy(bullet, destroyTime); // Destroy bullet after specified time
    }

    
}
