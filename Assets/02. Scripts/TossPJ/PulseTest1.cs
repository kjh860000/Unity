using UnityEngine;
using System.Collections;

public class PulseTest1 : MonoBehaviour
{
    public Vector3 smallScale = Vector3.one;      // 기본 크기
    public Vector3 largeScale = Vector3.one * 1.2f; // 커질 때 크기
    public float interval = 0.5f; // 간격(초)

    private void OnEnable()
    {
        StartCoroutine(ScaleRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(ScaleRoutine());
    }

    private IEnumerator ScaleRoutine()
    {
        bool isLarge = false;

        while (true)
        {
            transform.localScale = isLarge ? smallScale : largeScale;
            isLarge = !isLarge;
            yield return new WaitForSeconds(interval);
        }
    }
}
