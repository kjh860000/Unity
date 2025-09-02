using UnityEngine;
using System.Collections;
using TMPro;  // TextMeshPro 사용

public class TextFadeInOut : MonoBehaviour
{
    [SerializeField] private NoteSpawner noteSpawner;
    [SerializeField] private TextMeshProUGUI text;  // SpriteRenderer → TextMeshProUGUI

    [Tooltip("페이드 시작 여부")]
    public bool isStart = false;

    private void Awake()
    {
        if (text == null)
            text = GetComponent<TextMeshProUGUI>();

        if (text == null)
            UnityEngine.Debug.LogWarning("TextMeshProUGUI가 할당되지 않았습니다.");
    }

    public void PlayFade()
    {
        if (!isStart)
        {
            isStart = true;
            StartCoroutine(FadeInRoutine());
        }
    }
    private IEnumerator FadeInRoutine()
    {
        Color c = text.color;
        float duration = (noteSpawner.baseWaitTimer / noteSpawner.speedMultiplier); // 2초
        float elapsed = 0f;

        // Fade In
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsed / duration);
            text.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }
        text.color = new Color(c.r, c.g, c.b, 1f);

        yield return new WaitForSeconds(noteSpawner.baseWaitTimer / noteSpawner.speedMultiplier);

        // Fade Out
        elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            text.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }
        text.color = new Color(c.r, c.g, c.b, 0f);

        isStart = false;
    }

}
