using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour
{
    [Tooltip("사라지는 데 걸리는 시간 (초)")]
    public float fadeDuration = 1f;

    [Tooltip("사라지기 전 대기 시간 (초)")]
    public float waitBeforeFade = 1f;

    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            StartCoroutine(FadeOutRoutine());
        }
        else
        {
            UnityEngine.Debug.LogWarning("SpriteRenderer 컴포넌트가 없습니다.");
        }
    }

    private IEnumerator FadeOutRoutine()
    {
        // 대기
        yield return new WaitForSeconds(waitBeforeFade);

        float elapsed = 0f;
        Color originalColor = spriteRenderer.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);

            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            yield return null;
        }

        // 완전히 투명해졌으면 오브젝트 파괴
        Destroy(gameObject);
    }
}
