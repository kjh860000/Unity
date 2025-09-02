using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern5 : MonoBehaviour
{
    [SerializeField] private NoteSpawner noteSpawner;
    [SerializeField] private GameObject[] fogObjects;

    private List<GameObject> transparencyObjs = new List<GameObject>();

    private void Update()
    {
        PatternOff();
    }

    private void OnEnable()
    {
        // NoteSpawner의 노트 생성 이벤트 구독
        noteSpawner.OnNoteSpawned += HandleNoteSpawned;

        // Fog 객체 페이드 인
        foreach (var obj in fogObjects)
        {
            var fade = obj.GetComponent<BoolFadeInOut>();
            if (fade != null)
            {
                fade.isStart = true;
                fade.isFadeIn = true;
                fade.StartFade(true);
            }
        }

        // NoteSpawner 활성화
        noteSpawner.gameObject.SetActive(true);
    }

    private void HandleNoteSpawned(GameObject parentObj)
    {
        // 부모 포함해서 자식까지 탐색
        foreach (Transform child in parentObj.GetComponentsInChildren<Transform>(true)) // true -> 비활성화 오브젝트 포함
        {
            GameObject obj = child.gameObject;

            // 태그 필터링
            if (obj.CompareTag("Note") || obj.CompareTag("JudgeLine") || obj.CompareTag("Transparency"))
            {
                if (!transparencyObjs.Contains(obj))
                {
                    transparencyObjs.Add(obj);
                    Debug.Log($"Added to transparencyObjs: {obj.name} (total: {transparencyObjs.Count})");

                    // Fade 코루틴 실행
                    StartCoroutine(FadeNoteAfterDelay(obj, noteSpawner.baseWaitTimer / noteSpawner.speedMultiplier));
                }
            }
        }
    }

    private IEnumerator FadeNoteAfterDelay(GameObject note, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Fade 적용
        if (note != null) // 삭제된 오브젝트 체크
        {
            var fade = note.GetComponent<BoolFadeInOut>();
            if (fade != null)
            {
                fade.isStart = true;
                fade.isFadeIn = false;
                fade.StartFade(false);
                //Debug.Log($"Fade applied to: {note.name}");
            }
        }
    }

    private void OnDisable()
    {
        // 이벤트 구독 해제
        noteSpawner.OnNoteSpawned -= HandleNoteSpawned;
    }

    private void PatternOff()
    {
        if (!noteSpawner.startSpawn)
        {
            // Fog 페이드 아웃
            foreach (var obj in fogObjects)
            {
                var fade = obj.GetComponent<BoolFadeInOut>();
                if (fade != null)
                {
                    fade.isFadeIn = false;
                    fade.StartFade(false);
                }
            }

            // 패턴 종료
            gameObject.SetActive(false);
        }
    }
}
