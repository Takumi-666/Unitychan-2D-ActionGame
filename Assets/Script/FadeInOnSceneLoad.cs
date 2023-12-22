using UnityEngine;
using System.Collections;

public class FadeInOnSceneLoad : MonoBehaviour
{
    public static FadeInOnSceneLoad Instance; // シングルトンインスタンス

    public CanvasGroup blackPanel; // フェード用のパネル
    public float fadeSpeed = 0.8f; // フェードの速さ
    private bool hasFadedInOnce = false; // フェードインがすでに実行されたかを追跡

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーン遷移時に破棄しない
        }
        else
        {
            Destroy(gameObject); // 重複するインスタンスを破棄
        }
    }

    void Start()
    {
        if (!hasFadedInOnce)
        {
            StartCoroutine(FadeInAndDisable());
        }
        else
        {
            blackPanel.gameObject.SetActive(false); // 以前にフェードインした場合は非アクティブにする
        }
    }

    IEnumerator FadeInAndDisable()
    {
        float alpha = blackPanel.alpha;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            blackPanel.alpha = alpha;
            yield return null;
        }

        blackPanel.gameObject.SetActive(false);
        hasFadedInOnce = true; // フェードインが完了したことを記録
    }
}
