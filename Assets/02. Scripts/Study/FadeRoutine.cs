using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeRoutine : MonoBehaviour
{
    public Image fadePanel;
    public bool isFadeIn = false;
    private void Start()
    {
        StartCoroutine(FadeRoutineA(3));
    }
    IEnumerator FadeRoutineA(float fadeTime)
    {
        float timer = 0f;
        float percent = 0f;
        float value = 0f;

        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime; // Fade ÆÛ¼¾Æ®
            value = isFadeIn ? percent : 1 - percent;

            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, value);
            yield return null;
        }
    }
}
