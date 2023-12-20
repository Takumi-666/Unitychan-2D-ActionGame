using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectSound : MonoBehaviour
{
    public AudioClip soundEffect; // 再生するサウンドエフェクト
    private AudioSource audioSource;

    void Start()
    {
        // AudioSourceコンポーネントの取得、なければ追加
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // サウンドを再生し、指定されたシーンに遷移する
    public void PlayAndLoadScene(string sceneName)
    {
        StartCoroutine(PlaySoundAndLoadScene(sceneName));
    }

    private IEnumerator PlaySoundAndLoadScene(string sceneName)
    {
        if (soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
            // サウンドエフェクトの長さだけ待つ
            yield return new WaitForSeconds(soundEffect.length);
        }
        SceneManager.LoadScene(sceneName);
    }
}

