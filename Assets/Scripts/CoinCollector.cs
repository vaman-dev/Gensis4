using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Assign in the Inspector
    private int collectedCoins = 0;

    void Start()
    {
        UpdateCoinUI();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            collectedCoins++;
            Destroy(other.gameObject);
            UpdateCoinUI();
        }
    }

    void UpdateCoinUI()
    {
        coinText.text = "Coins: " + collectedCoins;
    }
}