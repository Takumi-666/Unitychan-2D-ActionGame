using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bgm1, bgm2, bgm3;
    public string nextSceneName; // 移動するシーンの名前
    public PlayerController playerController; // PlayerControllerへの参照

    void Start()
    {
        StartCoroutine(PlayBGM());
    }

    IEnumerator PlayBGM()
    {
        // 1秒待機
        yield return new WaitForSeconds(1);

        // 最初のBGMを再生
        audioSource.clip = bgm1;
        audioSource.Play();

        // 4秒待機
        yield return new WaitForSeconds(4);
        // BGM2の再生
        audioSource.clip = bgm2;
        audioSource.Play();

        yield return new WaitForSeconds(60);
        // BGM3の再生と同時にプレイヤーの入力を無効にする
        audioSource.clip = bgm3;
        audioSource.Play();
        if (playerController != null)
        {
            playerController.enabled = false; // プレイヤー制御を無効化
        }
        yield return new WaitForSeconds(3);

        // 次のシーンへ移動
        SceneManager.LoadScene(nextSceneName);
    }
}
