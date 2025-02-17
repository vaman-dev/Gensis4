using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Enemy dies");
            Destroy(gameObject); // Destroy the enemy
        }
    }
}
