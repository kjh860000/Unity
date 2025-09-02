using UnityEngine;
using System.Collections;

public class Pattern3 : MonoBehaviour
{
    [SerializeField] private NoteSpawner noteSpawner;
    [SerializeField] private JudgeManager judgeManager;
    [SerializeField] private NoteSoundManager NoteSM;

    [SerializeField] private GameObject[] judgeLines;

    [SerializeField] private GameObject[] darkObjects;
    [SerializeField] private GameObject[] objects;

    [SerializeField] private GameObject[] flashEffects;
    [SerializeField] private GameObject thunder;

    [SerializeField] private float minDelay = 0.5f;
    [SerializeField] private float maxDelay = 1.5f;

    private Coroutine lightningCoroutine;

    private void Update()
    {
        PatternOff();
        ScaleNote();
    }

    private void OnEnable()
    {
        foreach (var obj in darkObjects)
        {
            var fade = obj.GetComponent<BoolFadeInOut>();
            if (fade != null)
            {
                fade.isStart = true;
                fade.isFadeIn = true;
                fade.StartFade(true);
            }
        }

        foreach (var obj in objects)
        {
            var ps1 = obj.GetComponent<ParticleSystem>();
            if (ps1 != null)
            {
                ps1.Play();
            }
            obj.SetActive(true);
        }

        StartCoroutine(LineScaleChange());

        if (lightningCoroutine != null)
            StopCoroutine(lightningCoroutine);
        lightningCoroutine = StartCoroutine(LightningRoutine());

        noteSpawner.gameObject.SetActive(true);

        judgeManager.perfectThreshold *= 0.5f;
        judgeManager.greatThreshold *= 0.5f;
        judgeManager.goodThreshold *= 0.5f;
        judgeManager.underPerfectThreshold *= 0.5f;
        judgeManager.underGreatThreshold *= 0.5f;
        judgeManager.underGoodThreshold *= 0.5f;
    }

    IEnumerator LineScaleChange()
    {
        yield return new WaitForSeconds(noteSpawner.baseWaitTimer / noteSpawner.speedMultiplier);
        foreach (var obj in judgeLines)
        {
            var scaleDown = obj.GetComponent<SmoothScaleDown>();
            if (scaleDown != null)
            {
                scaleDown.isScaleDown = true;
            }
        }
    }
    void PatternOff()
    {
        if (!noteSpawner.startSpawn)
        {
            if (lightningCoroutine != null)
            {
                StopCoroutine(lightningCoroutine);
                lightningCoroutine = null;
            }

            foreach (var obj in darkObjects)
            {
                var fade = obj.GetComponent<BoolFadeInOut>();
                if (fade != null)
                {
                    fade.isFadeIn = false;
                    fade.StartFade(false);
                }
            }
            // SetActive(false) 대신 파티클 생성만 멈추고 유지
            foreach (var obj in objects)
            {
                var ps1 = obj.GetComponent<ParticleSystem>();
                if (ps1 != null)
                {
                    // 파티클 생성 중지, 이미 생성된 파티클은 남김
                    ps1.Stop(withChildren: false, ParticleSystemStopBehavior.StopEmitting);
                }
                else
                {
                    // 만약 파티클 컴포넌트 없으면 그냥 비활성화 (예외 처리)
                    obj.SetActive(false);
                }
            }

            var ps2 = thunder.GetComponent<ParticleSystem>();
            if (ps2 != null)
            {
                // 파티클 생성 중지, 이미 생성된 파티클은 남김
                ps2.Stop(withChildren: false, ParticleSystemStopBehavior.StopEmitting);
            }
            else
            {
                // 만약 파티클 컴포넌트 없으면 그냥 비활성화 (예외 처리)
                thunder.SetActive(false);
            }

            foreach (var obj in judgeLines)
            {
                var scaleUp = obj.GetComponent<SmoothScaleUp>();
                if (scaleUp != null)
                {
                    scaleUp.isScaleUp = true;
                }
            }

            judgeManager.perfectThreshold *= 2f;
            judgeManager.greatThreshold *= 2f;
            judgeManager.goodThreshold *= 2f;
            judgeManager.underPerfectThreshold *= 2f;
            judgeManager.underGreatThreshold *= 2f;
            judgeManager.underGoodThreshold *= 2f;

            gameObject.SetActive(false);
        }
    }

    void ScaleNote()
    {
        // 현재 씬에 존재하는 모든 Note 오브젝트를 찾음 (태그 필요)
        GameObject[] notes = GameObject.FindGameObjectsWithTag("JudgeLine");
        foreach (GameObject note in notes)
        {
            note.transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
        }
    }

    private IEnumerator LightningRoutine()
    {
        while (gameObject.activeSelf)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // thunder 파티클 재생
            var ps = thunder.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }
            thunder.SetActive(true);

            yield return new WaitForSeconds(1f);

            // flashEffects 모두 isFlashing true로
            foreach (var obj in flashEffects)
            {
                var flash = obj.GetComponent<LightningFlash>();
                if (flash != null)
                {
                    flash.isFlashing = true;
                }
                NoteSM.ThunderSound();
            }
        }
    }
}
