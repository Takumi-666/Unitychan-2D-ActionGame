using UnityEngine;
public class PanelController : MonoBehaviour
{
    public GameObject panel;
    public AudioClip sound; // 再生するサウンドエフェクト
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = sound; // クリップを設定
    }

    // ボタンクリック時に呼び出されるメソッド
    public void TogglePanel()
    {
        bool isPanelActive = panel.activeSelf;
        panel.SetActive(!isPanelActive); // パネルの表示状態を切り替え
        audioSource.Play(); // 効果音を再生
    }
}
