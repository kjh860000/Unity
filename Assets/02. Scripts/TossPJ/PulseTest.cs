using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PulseTest : MonoBehaviour
{
    public Vector3 smallScale = Vector3.one;
    public Vector3 largeScale = Vector3.one * 1.2f;

    public float interval = 0.5f; // 변화 주기 (0.5초)

    private bool isLarge = false;
    private AudioSource audioSource;

    private void OnEnable()
    {
        transform.localScale = smallScale;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PulseRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator PulseRoutine()
    {
        float nextTime = Time.realtimeSinceStartup + interval;
        // Time.realtimeSinceStartup는 게임 일시정지 영향을 받지 않는 실시간 타이머

        while (true)
        {
            // 다음 토글 시간까지 남은 시간 계산
            float waitTime = nextTime - Time.realtimeSinceStartup;
            if (waitTime > 0)
                yield return new WaitForSeconds(waitTime);
            else
                yield return null; // 이미 시간 지났으면 바로 다음 프레임 실행

            // 토글 처리
            isLarge = !isLarge;
            transform.localScale = isLarge ? largeScale : smallScale;

            // 사운드 재생 (AudioSource 필요)
            if (audioSource != null)
                audioSource.Play();

            // 다음 인터벌 시간 계산
            nextTime += interval;
        }
    }
}
