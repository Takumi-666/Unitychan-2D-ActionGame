using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timerText; // UI Textへの参照
    private float totalTime = 60f; // タイマーの総時間（60秒）
    private float countdown = 3f; // カウントダウンの時間
    private bool isCountingDown = true; // カウントダウン中かどうか

    void Start()
    {
        // ゲーム開始時にタイマーを開始
        isCountingDown = true;
        countdown = 3f; // カウントダウンをリセット
        totalTime = 60f; // タイマーをリセット
    }

    void Update()
    {
        if (isCountingDown)
        {
            // カウントダウン処理
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
                timerText.text = "Time: " + Mathf.CeilToInt(countdown).ToString();
            }
            else
            {
                // 60秒タイマーの開始
                totalTime -= Time.deltaTime;
                timerText.text = "Time: " + totalTime.ToString("F1"); // 小数点以下1桁まで表示

                if (totalTime <= 0)
                {
                    // タイマー終了時の処理
                    timerText.text = "Time's Up!";
                    isCountingDown = false; // カウントダウン停止
                    // ここにスコア表示のロジックを追加
                }
            }
        }
    }
}
