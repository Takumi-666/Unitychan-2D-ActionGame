using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance = null;
    public AudioSource audioSource;
    public AudioClip[] bgmClips; // シーンごとのBGMクリップ

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int sceneNumber = GetSceneNumber(scene.name);
        if (audioSource.clip != bgmClips[sceneNumber])
        {
            audioSource.clip = bgmClips[sceneNumber];
            audioSource.Play();
        }
    }

int GetSceneNumber(string sceneName)
{
    switch (sceneName)
    {
        case "TitleScene":
        case "InstructionsScene":
        case "StageSelectScene":
            return 0; // ➀のBGM
        case "1StageScene":
            return 1; // ➁のBGM
        case "ScoreScene":
        case "RankingScene":
            return 2; // ③のBGM
        default:
            return -1; // 該当しない場合
    }
}


    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
