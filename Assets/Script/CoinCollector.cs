using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int scoreValue = 100;
    public ScoreManager scoreManager; // ScoreManagerへの参照

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scoreManager.AddScore(scoreValue);
            gameObject.SetActive(false);
        }
    }
}

