using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;  // Use SerializeField for better encapsulation
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float destroyTime = 1f;
    
    private float nextFireTime;
    private bool facingRight = true;
    private Rigidbody2D playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleShooting();
        UpdateFacingDirection();
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void UpdateFacingDirection()
    {
        if (playerRb.linearVelocity.x > 0)
            facingRight = true;
        else if (playerRb.linearVelocity.x < 0)
            facingRight = false;
    }

    private void Fire()
    {
        Vector2 direction = facingRight ? Vector2.right : Vector2.left;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        
        if (bullet.TryGetComponent(out Rigidbody2D rb))
        {
            rb.linearVelocity = direction * bulletSpeed;
        }

        Destroy(bullet, destroyTime);
    }
}
