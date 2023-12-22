using UnityEngine;

public class StageButtonController : MonoBehaviour
{
    public GameObject square;
    public GameObject startButton;
    public GameObject[] texts;
    public AudioSource audioSource; // AudioSourceの参照

    public void ShowContent(int buttonIndex)
    {
        // サウンド再生
        if (audioSource != null)
        {
            audioSource.Play();
        }

        square.SetActive(true);
        startButton.SetActive(true);

        foreach (var text in texts)
        {
            text.SetActive(false);
        }

        if (buttonIndex >= 0 && buttonIndex < texts.Length)
        {
            texts[buttonIndex].SetActive(true);
        }
    }
}
