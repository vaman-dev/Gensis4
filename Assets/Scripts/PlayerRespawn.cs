using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 respawnPoint; 
    // public GameObject deathCanvas;

    void Start()
    {
        respawnPoint = transform.position; 
        // if (deathCanvas != null)
        // {
        //     deathCanvas.SetActive(false);
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint")) 
        {
            respawnPoint = other.transform.position; 
            Debug.Log("Checkpoint updated to: " + respawnPoint);
        }
        else if (other.CompareTag("EnemyBullet")) 
        {
            Die();
        }
    }

    public void Die()
    {
        
       
        
            Respawn(); 
        
    }

    public void Respawn()
    {
        
        transform.position = respawnPoint; 
        }
    }

