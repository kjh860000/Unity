using UnityEngine;
using System.Collections;

public class ScaleShrink : MonoBehaviour
{
    [Tooltip("작아지기 전 대기 시간 (초)")]
    public float waitBeforeShrink = 1f;

    [Tooltip("작아지는 데 걸리는 시간 (초)")]
    public float shrinkDuration = 1f;

    public Vector3 smallScale = Vector3.one;
    public Vector3 largeScale = Vector3.one * 1.2f;

    private void OnEnable()
    {
        transform.localScale = largeScale;  // 초기 크기 설정 (크게 시작)
        StartCoroutine(ShrinkRoutine());
    }

    private IEnumerator ShrinkRoutine()
    {
        // 대기
        yield return new WaitForSeconds(waitBeforeShrink);

        float elapsed = 0f;

        while (elapsed < shrinkDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / shrinkDuration);
            t = t * t * (3f - 2f * t); // 부드러운 Ease In/Out 보간

            transform.localScale = Vector3.Lerp(largeScale, smallScale, t);

            yield return null;
        }

        // 최종 크기 보정
        transform.localScale = smallScale;
    }
}
