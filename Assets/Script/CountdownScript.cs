using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownScript : MonoBehaviour
{
    public Text countdownText;

    void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(1);
        countdownText.text = "3";
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        countdownText.text = "スタート！";
        yield return new WaitForSeconds(1); // スタートの表示後に待つ

        // カウントダウン後にテキストとパネルを非表示にする
        countdownText.gameObject.SetActive(false);
    }
}
