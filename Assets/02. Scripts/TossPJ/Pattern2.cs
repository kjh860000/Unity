using UnityEngine;

public class Pattern2 : MonoBehaviour
{
    [SerializeField] private NoteSpawner noteSpawner;

    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject BlankPrefab;

    [SerializeField] private GameObject[] smokeObjects;
    [SerializeField] private GameObject[] objects;

    GameObject blankToRemove = null;
    private void Update()
    {
        PatternOff();
    }
    private void OnEnable()
    {
        foreach (var obj in smokeObjects)
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
            var ps = obj.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }
            obj.SetActive(true);
        }

        noteSpawner.gameObject.SetActive(true);

        noteSpawner.Notes.Add(bombPrefab);

        foreach (var note in noteSpawner.Notes)
        {
            if (note.name == "Blank")  // 이름 비교
            {
                blankToRemove = note;
                break;
            }
        }
        if (blankToRemove != null)
        {
            noteSpawner.Notes.Remove(blankToRemove);
        }
    }
    void PatternOff()
    {
        if (!noteSpawner.startSpawn)
        {
            foreach (var obj in smokeObjects)
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
                var ps = obj.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    // 파티클 생성 중지, 이미 생성된 파티클은 남김
                    ps.Stop(withChildren: false, ParticleSystemStopBehavior.StopEmitting);
                }
                else
                {
                    // 만약 파티클 컴포넌트 없으면 그냥 비활성화 (예외 처리)
                    obj.SetActive(false);
                }
            }

            gameObject.SetActive(false);

            noteSpawner.Notes.Remove(bombPrefab); // bombPrefab 객체를 리스트에서 제거
            noteSpawner.Notes.Add(BlankPrefab);
        }
    }
}
