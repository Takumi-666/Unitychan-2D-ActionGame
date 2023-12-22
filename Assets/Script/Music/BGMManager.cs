using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance = null;

    public static BGMManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            // 既にインスタンスが存在する場合、この新しいインスタンスを破棄
            Destroy(this.gameObject);
            return;
        }

        instance = this;

        // このGameObjectをシーン遷移で破棄されないように設定
        DontDestroyOnLoad(this.gameObject);
    }
}
