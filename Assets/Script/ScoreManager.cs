using UnityEngine;
using UnityEngine.UI; // UI要素を使用するために必要

public class ScoreManager : MonoBehaviour
{
    public static int score; // スコアを保持する変数
    public Text scoreText; // スコアを表示するテキスト

    void Start()
    {
        score = 0; // スコアの初期化
        UpdateScore(); // スコア表示の更新
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue; // スコアの追加
        UpdateScore(); // スコア表示の更新
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score; // スコアのテキストを更新
    }
}