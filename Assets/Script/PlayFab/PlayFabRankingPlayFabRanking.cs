using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System.Text;

public class PlayFabRanking : MonoBehaviour
{
    public Text Nameinput; // Nameinput用のText UI要素
    public Text Scoreinput; // Scoreinput用のText UI要素

    void Start()
    {
        GetLeaderboard();
    }

    public void GetLeaderboard()
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "test",
            StartPosition = 0, // ランキングの開始位置
            MaxResultsCount = 10 // 取得する最大結果数
        }, result =>
        {
            StringBuilder names = new StringBuilder();
            StringBuilder scores = new StringBuilder();

            foreach (var item in result.Leaderboard)
            {
                string displayName = item.DisplayName ?? "NoName";
                names.AppendLine($"{item.Position + 1}位: {displayName}");
                scores.AppendLine($"スコア {item.StatValue}");
            }

            // Text UI要素に値を設定
            Nameinput.text = names.ToString();
            Scoreinput.text = scores.ToString();
        }, error =>
        {
            Debug.Log("ランキングデータ取得失敗: " + error.GenerateErrorReport());
        });
    }
}
