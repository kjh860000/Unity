using UnityEngine;
using System.Collections;

public class BoolColorChange : MonoBehaviour
{
    private NoteSpawner noteSpawner;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Tooltip("색 변화 방향 (true: 목표색으로, false: 원래색으로 복귀)")]
    public bool isToTargetColor = true;

    [Tooltip("색 변화 시작 여부")]
    public bool isStart = false;

    public float R = 255;
    public float G = 200;
    public float B = 200;

    private Coroutine colorCoroutine;

    // 원래 색상
    private Color originalColor;
    // 목표 색상 (255, 200, 200)
    private Color targetColor;

    private void Awake()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
            Debug.LogWarning("SpriteRenderer가 할당되지 않았습니다.");

        noteSpawner = FindObjectOfType<NoteSpawner>();
        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;

        targetColor = new Color(R / 255f, G / 255f, B / 255f);
    }

    private void OnEnable()
    {
        if (isStart)
            StartColorChange(isToTargetColor);
    }

    public void StartColorChange(bool toTarget)
    {
        if (!isStart)
            return; // isStart가 false면 실행 안 함

        isToTargetColor = toTarget;

        if (colorCoroutine != null)
            StopCoroutine(colorCoroutine);

        colorCoroutine = StartCoroutine(toTarget ? ColorToTargetRoutine() : ColorToOriginalRoutine());
    }

    private IEnumerator ColorToTargetRoutine()
    {
        Color startColor = spriteRenderer.color;
        float elapsed = 0f;
        //float duration = noteSpawner.baseWaitTimer / noteSpawner.speedMultiplier;

        //while (elapsed < duration)
        //{
        elapsed += Time.deltaTime;
        Color lerped = Color.Lerp(startColor, targetColor, elapsed); // / duration);
        spriteRenderer.color = lerped;
        yield return null;
        //}
        spriteRenderer.color = targetColor;
    }

    private IEnumerator ColorToOriginalRoutine()
    {
        Color startColor = spriteRenderer.color;
        float elapsed = 0f;
        //float duration = noteSpawner.baseWaitTimer / noteSpawner.speedMultiplier;

        //while (elapsed < duration)
        //{
        elapsed += Time.deltaTime;
        Color lerped = Color.Lerp(startColor, originalColor, elapsed); // / duration);
        spriteRenderer.color = lerped;
        yield return null;
        //}
        spriteRenderer.color = originalColor;
        isStart = false;
    }
}
