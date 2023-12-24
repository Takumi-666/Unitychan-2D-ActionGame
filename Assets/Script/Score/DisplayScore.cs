using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        // 保存されたスコアを表示
        scoreText.text = "Score: " + ScoreManager.score + "円 ";
    }
}
