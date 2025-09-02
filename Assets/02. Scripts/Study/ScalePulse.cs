using UnityEngine;
using System.Collections;

public class ScalePulse : MonoBehaviour
{
    [SerializeField] private NoteSpawner noteSpawner;

    public Vector3 smallScale = Vector3.one;          // 기본 크기
    public Vector3 largeScale = Vector3.one * 1.2f;   // 커질 때 크기

    [Range(0f, 1f)]
    public float growRatio = 0.3f;  // 커질 때 걸리는 시간 비율

    [Range(0f, 1f)]
    public float shrinkRatio = 0.7f; // 작아질 때 걸리는 시간 비율

    private Coroutine routine;
    private float pulseTimer;
    //public bool pulseStart = false;
    void Awake()
    {
        if (noteSpawner == null)
        {
            noteSpawner = FindObjectOfType<NoteSpawner>();
        }
    }
    private void OnEnable()
    {
/*        if (!pulseStart)
            return;*/
        routine = StartCoroutine(ScaleRoutine());
    }

    private void OnDisable()
    {
        if (routine != null)
            StopCoroutine(routine);
    }

    private IEnumerator ScaleRoutine()
    {
        if (noteSpawner.baseSpawnTimer == 0.5f)
        {
            pulseTimer = noteSpawner.baseSpawnTimer;
        }
        else if(noteSpawner.baseSpawnTimer == 0.25f)
        {
            pulseTimer = noteSpawner.baseSpawnTimer * 2f;
        }

        bool isLarge = false;
        float totalDuration = (pulseTimer / noteSpawner.speedMultiplier)/2;
        float cycleStartTime = Time.time; // 첫 사이클 시작 시간

        while (true)
        {
            totalDuration = (pulseTimer / noteSpawner.speedMultiplier)/2;
            float growDuration = totalDuration * growRatio;
            float shrinkDuration = totalDuration * shrinkRatio;

            Vector3 startScale = transform.localScale;
            Vector3 targetScale = isLarge ? smallScale : largeScale;

            float duration = isLarge ? shrinkDuration : growDuration;

            // GrowRatio나 ShrinkRatio가 0일 경우 즉시 변경
            if (duration <= 0f)
            {
                transform.localScale = targetScale;
            }
            else
            {
                float startTime = Time.time;
                float endTime = startTime + duration;

                while (Time.time < endTime)
                {
                    float t = Mathf.InverseLerp(startTime, endTime, Time.time);
                    t = t * t * (3f - 2f * t); // Ease In/Out
                    transform.localScale = Vector3.Lerp(startScale, targetScale, t);
                    yield return null;
                }
                transform.localScale = targetScale;
            }

            // 다음 비트까지 절대 시간 기반 대기
            cycleStartTime += totalDuration;
            yield return new WaitUntil(() => Time.time >= cycleStartTime);

            isLarge = !isLarge;
        }
    }
}
