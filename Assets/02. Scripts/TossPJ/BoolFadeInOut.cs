using UnityEngine;
using System.Collections;

public class BoolFadeInOut : MonoBehaviour
{
    private NoteSpawner noteSpawner;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Tooltip("페이드 인 여부 (true: 페이드 인, false: 페이드 아웃)")]
    public bool isFadeIn = true;

    [Tooltip("페이드 시작 여부")]
    public bool isStart = false;

    private Coroutine fadeCoroutine;

    private void Awake()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
            UnityEngine.Debug.LogWarning("SpriteRenderer가 할당되지 않았습니다.");

        noteSpawner = FindObjectOfType<NoteSpawner>();
    }

    private void OnEnable()
    {
        if (isStart)
            StartFade(isFadeIn);
    }

    public void StartFade(bool fadeIn)
    {
        if (!isStart)
            return;  // isStart가 false면 페이드 실행 안함

        isFadeIn = fadeIn;

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(fadeIn ? FadeInRoutine() : FadeOutRoutine());
    }

    private IEnumerator FadeInRoutine()
    {
        Color c = spriteRenderer.color;
        float startAlpha = c.a;  // 현재 알파값을 시작점으로
        float elapsed = 0f;
        float duration = noteSpawner.baseWaitTimer / noteSpawner.speedMultiplier;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 1f, elapsed / duration);
            spriteRenderer.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }
        spriteRenderer.color = new Color(c.r, c.g, c.b, 1f);
    }

    private IEnumerator FadeOutRoutine()
    {
        Color c = spriteRenderer.color;
        float elapsed = 0f;
        while (elapsed < (noteSpawner.baseWaitTimer / noteSpawner.speedMultiplier))
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / (noteSpawner.baseWaitTimer / noteSpawner.speedMultiplier));
            spriteRenderer.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }
        spriteRenderer.color = new Color(c.r, c.g, c.b, 0f);
        isStart = false;
    }
}
