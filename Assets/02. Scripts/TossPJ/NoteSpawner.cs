using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using TMPro;
using Unity.Mathematics;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private NoteSoundManager noteSoundManager;
    public List<GameObject> Notes = new List<GameObject>();
    public AudioSource BGM;
    public AudioSource BEAT;

    [SerializeField] private TextMeshProUGUI infoText;

    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private Transform judgeLinePos1;
    [SerializeField] private Transform judgeLinePos2;

    [SerializeField] public float baseSpawnTimer = 0.5f;
    [SerializeField] public float offbeatOffset = 0.25f;

    [SerializeField] private float baseFallDuration = 4f;
    [SerializeField] public float baseWaitTimer = 2f;

    [SerializeField] public float speedMultiplier = 1f; // 속도
    [SerializeField] private float nextRoundTime = 4f;

    [SerializeField] private float baseBPM = 120f; // 기준 BPM
    [SerializeField] private float targetBPM = 120f; // 첫 세트 목표 BPM

    [SerializeField] public int notesPerSet = 7;

    [SerializeField] public int setsCount = 3;  // 세트수
    [SerializeField] public int repsCount = 3;  // 횟수

    public Action<GameObject> OnNoteSpawned;
    public TextMeshProUGUI bpmText;

    public bool startSpawn = true;

    public bool canFireDecrease = false;

    public bool startStorm = false;
    public bool isStorming = false;

    private void OnEnable()
    {
        //Debug.Log("NoteSpawner On");
        speedMultiplier = 1f;
        targetBPM = 120f;
        repsCount = 3;
        StartCoroutine(PatternStartAccurate());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public IEnumerator PatternStartAccurate()
    {
        startSpawn = true;
        int count = 0;

        // 현재 시간에서 시작
        float nextActionTime = Time.time;

        while (count < setsCount)   // count < 3 세트
        {
            speedMultiplier = targetBPM / baseBPM;
            noteSoundManager.SetBgmPitch(speedMultiplier);

            TextFadeInOut fadeScript = infoText.GetComponent<TextFadeInOut>();
            if (speedMultiplier != 1f)
            {
                infoText.text = "Speed Up!";
                fadeScript.PlayFade();
            }

            if (bpmText != null)
                bpmText.text = targetBPM.ToString();

            //BEAT.Stop();  // 재생 중인 BGM을 즉시 정지
            //BEAT.Play();  // 바로 다시 재생 시작
            BGM.Stop();  // 재생 중인 BGM을 즉시 정지
            BGM.Play();  // 바로 다시 재생 시작
            BEAT.Stop();  // 재생 중인 BGM을 즉시 정지

            canFireDecrease = false;

            // 패턴 시작 전 대기
            nextActionTime += (baseWaitTimer / speedMultiplier) * 4f;
            yield return WaitUntilTime(nextActionTime);

            canFireDecrease = true;

            Debug.Log($"{count + 1} 세트");

            for (int j = 0; j < repsCount; j++) // j < 5 횟수
            {
                Debug.Log($"세트 {count + 1}");
                Debug.Log($"targetBPM = {targetBPM}, speedMultiplier = {speedMultiplier:F3}");

                Debug.Log($"{j + 1} 회");

                BEAT.Play();  // 바로 다시 재생 시작
                BGM.Stop();  // 재생 중인 BGM을 즉시 정지
                BGM.Play();  // 바로 다시 재생 시작

                //-------------------- 노트 생성 --------------------
                for (int i = 0; i < notesPerSet; i++)
                {
                    GameObject selectedNote = Notes[Random.Range(0, Notes.Count)];
                    bool isOffbeat = selectedNote.name.Contains("[Note] Mon2");

                    float delay = isOffbeat ? offbeatOffset : 0f;

                    // delay를 nextActionTime에 미리 반영하여 정확한 시간에 생성
                    float spawnTime = nextActionTime + delay;
                    yield return WaitUntilTime(spawnTime);

                    // 노트 생성 (delay 반영 후 정확한 시간에 바로 생성)
                    int spawnIndex = Random.Range(0, spawnPos.Length);
                    DropNote(selectedNote, spawnIndex);

                    nextActionTime += baseSpawnTimer / speedMultiplier;
                    yield return WaitUntilTime(nextActionTime);
                }

                // 8번째 노트 빈칸
                nextActionTime += baseSpawnTimer / speedMultiplier;
                yield return WaitUntilTime(nextActionTime);
                //-------------------- 노트 생성 --------------------

                BEAT.Stop();  // 재생 중인 BGM을 즉시 정지
                BEAT.Play();  // 바로 다시 재생 시작

                //-------------------- 플레이 시간 --------------------
                nextActionTime += (baseWaitTimer / speedMultiplier)*2f;
                yield return WaitUntilTime(nextActionTime);
                //-------------------- 플레이 시간 --------------------
            }
            count++;

            targetBPM += 10;
            repsCount += 1;

            //nextActionTime += nextRoundTime;
            //yield return WaitUntilTime(nextActionTime);

            // 속도 증가

            UnityEngine.Debug.Log("다음 세트");
        }

        startSpawn = false;
        gameObject.SetActive(false);
    }

    private IEnumerator WaitUntilTime(float targetTime)
    {
        while (Time.time < targetTime)
        {
            yield return null; // 다음 프레임까지 대기
        }
    }

    public void DropNote(GameObject notePrefab, int spawnIndex)
    {
        Vector3 dropPos = spawnPos[spawnIndex].position;

        Pattern6 pattern6 = FindObjectOfType<Pattern6>();
        if (pattern6 != null && startStorm)
        {
            dropPos.y = pattern6.GetRandomY(spawnIndex);
        }

        GameObject note = Instantiate(notePrefab, dropPos, Quaternion.identity);

        OnNoteSpawned?.Invoke(note);

        Note noteScript = note.GetComponent<Note>();

        if (noteScript != null)
        {
            // 랜덤 점프 높이 적용
            if (pattern6 != null && startStorm)
            {
                pattern6.GetRandomJumpFallY();
            }

            float adjustedFallDuration = baseFallDuration / speedMultiplier;

            Transform judgeLine = (spawnIndex == 0) ? judgeLinePos1 :
                                  (spawnIndex == 1) ? judgeLinePos2 : judgeLinePos1;

            float targetTime = Time.time + adjustedFallDuration;

            noteScript.Init(dropPos, judgeLine.position, adjustedFallDuration, targetTime,
                spawnIndex == 0 ? Note.Lane.Left : Note.Lane.Right);

            noteScript.NoteSound();
        }
    }

}
