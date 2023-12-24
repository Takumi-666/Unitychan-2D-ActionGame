using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

public class PlayFabSubmitter : MonoBehaviour
{
    public InputField usernameInput; // ユーザーネーム入力用のInputField
    public Text messageText; // メッセージを表示するテキスト

    public void SubmitScore()
    {
        string username = usernameInput.text;
        if (username.Length < 3 || username.Length > 8)
        {
            messageText.text = "名前は2文字以上8文字以下で";
            return;
        }

        UpdatePlayerStatistics();
        UpdateDisplayName(username);
    }


    private void UpdatePlayerStatistics()
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
        {
            new StatisticUpdate { StatisticName = "test", Value = ScoreManager.score }
        }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnStatisticsUpdate, OnPlayFabError);
    }


    private void UpdateDisplayName(string displayName)
    {
        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = displayName };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnPlayFabError);
    }

    private void OnStatisticsUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("スコア更新成功");
    }

    private void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("表示名更新成功");
    }

    private void OnPlayFabError(PlayFabError error)
    {
        Debug.LogError("PlayFabエラー: " + error.GenerateErrorReport());
    }
}
