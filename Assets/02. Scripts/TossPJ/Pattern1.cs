using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pattern1 : MonoBehaviour
{
    [SerializeField] private NoteSpawner noteSpawner;

    [SerializeField] private GameObject blank;

    [SerializeField] private GameObject[] bloodObjects;

    private List<GameObject> bloodmobs = new List<GameObject>();

    private void Update()
    {
        PatternOff();
    }

    private void OnEnable()
    {
        // NoteSpawner의 노트 생성 이벤트 구독
        noteSpawner.OnNoteSpawned += HandleNoteSpawned;

        foreach (var obj in bloodObjects)
        {
            var fade = obj.GetComponent<BoolFadeInOut>();
            if (fade != null)
            {
                fade.isStart = true;
                fade.isFadeIn = true;
                fade.StartFade(true);
            }
        }

        noteSpawner.Notes.Add(blank);
        noteSpawner.Notes.Add(blank);

        noteSpawner.gameObject.SetActive(true);

        noteSpawner.notesPerSet = 15;
        noteSpawner.baseSpawnTimer = 0.25f;
        noteSpawner.offbeatOffset = 0.125f;
    }
    private void HandleNoteSpawned(GameObject parentObj)
    {
        // 부모 포함해서 자식까지 탐색
        foreach (Transform child in parentObj.GetComponentsInChildren<Transform>(true)) // true -> 비활성화 오브젝트 포함
        {
            GameObject obj = child.gameObject;

            // 태그 필터링
            if (obj.CompareTag("Note") || obj.CompareTag("Transparency"))
            {
                if (!bloodmobs.Contains(obj))
                {
                    bloodmobs.Add(obj);
                    Debug.Log($"Added to transparencyObjs: {obj.name} (total: {bloodmobs.Count})");

                    StartCoroutine(colorNoteAfterDelay(obj, 0f)); //noteSpawner.baseWaitTimer / noteSpawner.speedMultiplier));
                }
            }
        }
    }
    private IEnumerator colorNoteAfterDelay(GameObject note, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (note != null) // 삭제된 오브젝트 체크
        {
            var color = note.GetComponent<BoolColorChange>();
            if (color != null)
            {
                color.isStart = true;
                color.isToTargetColor = true;
                color.StartColorChange(true);
                Debug.Log($"color changed to: {note.name}");
            }
        }
    }

    private void OnDisable()
    {
        // 이벤트 구독 해제
        noteSpawner.OnNoteSpawned -= HandleNoteSpawned;
    }
    void PatternOff()
    {
        if (!noteSpawner.startSpawn)
        {
            foreach (var obj in bloodObjects)
            {
                var fade = obj.GetComponent<BoolFadeInOut>();
                if (fade != null)
                {
                    fade.isFadeIn = false;
                    fade.StartFade(false);
                }
            }

            gameObject.SetActive(false);

            noteSpawner.Notes.Remove(blank);
            noteSpawner.Notes.Remove(blank);

            noteSpawner.notesPerSet = 7;
            noteSpawner.baseSpawnTimer = 0.5f;
            noteSpawner.offbeatOffset = 0.25f;
        }
    }
}