using UnityEngine;
using System.Collections;

public class ScaleGrow : MonoBehaviour
{
    [Tooltip("커지기 전 대기 시간 (초)")]
    public float waitBeforeGrow = 1f;

    [Tooltip("커지는 데 걸리는 시간 (초)")]
    public float growDuration = 1f;

    public Vector3 smallScale = Vector3.one;
    public Vector3 largeScale = Vector3.one * 1.2f;

    private void OnEnable()
    {
        transform.localScale = smallScale;  // 초기 크기 설정
        StartCoroutine(GrowRoutine());
    }

    private IEnumerator GrowRoutine()
    {
        // 대기
        yield return new WaitForSeconds(waitBeforeGrow);

        float elapsed = 0f;

        while (elapsed < growDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / growDuration);
            t = t * t * (3f - 2f * t); // 부드러운 Ease In/Out 보간

            transform.localScale = Vector3.Lerp(smallScale, largeScale, t);

            yield return null;
        }

        // 최종 크기 보정
        transform.localScale = largeScale;
    }
}
