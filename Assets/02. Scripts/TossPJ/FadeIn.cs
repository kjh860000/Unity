using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    [Tooltip("나타나기 전 대기 시간 (초)")]
    public float waitBeforeFade = 1f;

    [Tooltip("나타나는 데 걸리는 시간 (초)")]
    public float fadeDuration = 1f;

    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // 초기 알파 0으로 설정 (완전 투명)
            Color c = spriteRenderer.color;
            spriteRenderer.color = new Color(c.r, c.g, c.b, 0f);

            StartCoroutine(FadeInRoutine());
        }
        else
        {
            UnityEngine.Debug.LogWarning("SpriteRenderer 컴포넌트가 없습니다.");
        }
    }

    private IEnumerator FadeInRoutine()
    {
        // 대기
        yield return new WaitForSeconds(waitBeforeFade);

        float elapsed = 0f;
        Color originalColor = spriteRenderer.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration); // 0에서 1로 증가

            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            yield return null;
        }

        // 완전히 나타나면 알파 1로 고정
        Color finalColor = spriteRenderer.color;
        spriteRenderer.color = new Color(finalColor.r, finalColor.g, finalColor.b, 1f);
    }
}
