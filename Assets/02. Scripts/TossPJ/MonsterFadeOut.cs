using UnityEngine;
using System.Collections;

public class MonsterFadeOut : MonoBehaviour
{
    [Tooltip("사라지는 데 걸리는 시간 (초)")]
    public float fadeDuration = 1f;

    private SpriteRenderer spriteRenderer;
    private TMonster tM;

    private bool isFading = false; // 중복 실행 방지

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tM = FindObjectOfType<TMonster>();
    }

    private void Update()
    {
        if (tM.isfade && !isFading)
        {
            StartCoroutine(FadeOutRoutine());
            Debug.Log("Monster Fade");
        }
    }

    private IEnumerator FadeOutRoutine()
    {
        isFading = true;  // 코루틴 실행 시작

        float elapsed = 0f;
        Color originalColor = spriteRenderer.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);

            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            yield return null;
        }

        tM.isfade = false;

        Destroy(transform.root.gameObject);

        //tM.dontEffect = false;  // 여기서 false로 변경
        isFading = false; // 코루틴 종료
    }
}
