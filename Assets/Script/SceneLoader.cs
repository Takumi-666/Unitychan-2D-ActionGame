using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadStageSelectScene()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    public void Load1StageScene()
    {
        SceneManager.LoadScene("1StageScene");
    }
    public void LoadRankingScene()
    {
        SceneManager.LoadScene("RankingScene");
    }
    public void LoadInstructionsScene()
    {
        SceneManager.LoadScene("InstructionsScene");
    }
}
