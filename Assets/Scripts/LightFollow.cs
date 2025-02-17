using UnityEngine;

public class LightFollow : MonoBehaviour
{
  private Light myLight;  
    [SerializeField] private GameObject Player;

    void Update()
    {
        if (Player != null)  // if the player is present or not 

        {
            transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime * 5);

        }
    }
}
