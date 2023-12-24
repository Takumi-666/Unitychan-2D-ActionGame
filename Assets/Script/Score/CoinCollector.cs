using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int scoreValue = 100;
    public AudioClip soundEffect; // 再生するサウンドエフェクト

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // ScoreManagerのインスタンスを取得してスコアを追加
            ScoreManager.Instance.AddScore(scoreValue);
            SoundManager.Instance.PlaySound(soundEffect);
            gameObject.SetActive(false);
        }
    }
}
