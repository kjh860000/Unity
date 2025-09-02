using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class JudgeManager : MonoBehaviour
{
    public List<Note> activeNotes = new List<Note>();

    [SerializeField] public float perfectThreshold = 0.04f;
    [SerializeField] public float greatThreshold = 0.08f;
    [SerializeField] public float goodThreshold = 0.12f;

    [SerializeField] public float underPerfectThreshold = 0.04f;
    [SerializeField] public float underGreatThreshold = 0.08f;
    [SerializeField] public float underGoodThreshold = 0.12f;

    [SerializeField] private NoteSpawner NS;
    [SerializeField] private TGameManager TGM;
    [SerializeField] private PlayerHP PHP;
    [SerializeField] private NoteSoundManager SM;
    [SerializeField] private TGameManager GM;

    [SerializeField] private GameObject[] objects;

    [SerializeField] public float fireCritCount = 0; // 클래스 멤버 변수 (누적용)
    public Slider critSlider;      // Inspector에서 연결
    public float maxCrit = 125;       // 최대값
    public bool isOver30 = false; // 30 이상 상태인지 체크

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject x2Text;
    [SerializeField] private TextMeshProUGUI fireText;


    public JudgeLine leftJudgeLine;
    public JudgeLine rightJudgeLine;

    public bool canPress = true;
    public bool isCrit = false;
    public float inputCooldown;

    public int killcount = 0;
    public int critcount = 0;

    private void Awake()
    {
        //NS = FindObjectOfType<NoteSpawner>();
        if (NS == null)
            UnityEngine.Debug.LogError("NoteSpawner 컴포넌트를 찾을 수 없습니다!");

        if (leftJudgeLine == null)
            UnityEngine.Debug.LogError("Left JudgeLine이 할당되지 않았습니다!");
        if (rightJudgeLine == null)
            UnityEngine.Debug.LogError("Right JudgeLine이 할당되지 않았습니다!");
    }

    void Update()
    {
        if (fireCritCount > 0 && NS.canFireDecrease)
        {
            Fire(-((NS.baseWaitTimer * NS.speedMultiplier) / 2) * Time.deltaTime);

            critSlider.maxValue = maxCrit;
            critSlider.value = fireCritCount;
        }

        //AutoHitNotes(); //테스트용 auto

        if (!canPress) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SM.SwingSound();
            bool hit = JudgeNote(Note.Lane.Left);
            if (!hit) StartCoroutine(WaitJudge());
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SM.SwingSound();
            bool hit = JudgeNote(Note.Lane.Right);
            if (!hit) StartCoroutine(WaitJudge());
        }
    }

/*    private void AutoHitNotes()
    {
        foreach (var note in new List<Note>(activeNotes))
        {
            if (note.IsMissed) continue;

            float diff = Time.time - note.GetTargetTime();
            float absDiff = Mathf.Abs(diff);

            // perfect 범위 안이면 자동 판정
            if (diff < 0 && absDiff <= perfectThreshold ||
                diff >= 0 && absDiff <= underPerfectThreshold)
            {
                JudgeNote(note.lane);
            }
        }
    }*/
    public void OnLeftButton()
    {
        if (!canPress) return;

        SM.SwingSound();
        bool hit = JudgeNote(Note.Lane.Left);
        if (!hit) StartCoroutine(WaitJudge());
    }

    public void OnRightButton()
    {
        if (!canPress) return;

        SM.SwingSound();
        bool hit = JudgeNote(Note.Lane.Right);
        if (!hit) StartCoroutine(WaitJudge());
    }

    public void RegisterNote(Note note)
    {
        if (!activeNotes.Contains(note))
            activeNotes.Add(note);
    }

    public void UnregisterNote(Note note)
    {
        if (activeNotes.Contains(note))
            activeNotes.Remove(note);
    }

    bool JudgeNote(Note.Lane lane)
    {
        Note bestNote = null;
        float bestDiff = float.MaxValue;

        foreach (var note in activeNotes)
        {
            if (note.lane != lane || note.IsMissed)
                continue;

            float diff = Time.time - note.GetTargetTime();
            float absDiff = Mathf.Abs(diff);

            // 최대 판정 범위를 벗어나면 후보로 선택하지 않음
            float maxThreshold = Mathf.Max(perfectThreshold, greatThreshold, goodThreshold,
                                           underPerfectThreshold, underGreatThreshold, underGoodThreshold);

            Debug.Log($"판정 시간차: {diff:F3}s, 절대값 {absDiff:F3}s, 최대 판정 범위: {maxThreshold:F3}s");


            if (absDiff > maxThreshold)
                continue;

            if (absDiff < bestDiff)
            {
                bestDiff = absDiff;
                bestNote = note;
            }
        }

        if (bestNote != null)
        {
            if (bestNote.CompareTag("Bomb"))
            {
                UnityEngine.Debug.Log("Boom!");
                TGM.MinusScore(100);
                PHP.TakeDamage();
                SM.ExplodeSound();
                bestNote.HitNote();
                Fire(-50f);
                return true;
            }

            float diff = Time.time - bestNote.GetTargetTime();
            float absDiff = Mathf.Abs(diff);


            // diff < 0이면 perfect, great, good 체크
            if (diff < 0)
            {
                if (absDiff <= perfectThreshold)
                {
                    TGM.PlusScore(100);
                    SM.CritSound();
                    critcount++;
                    isCrit = true;
                    Fire(4f);
                    StartCoroutine(scoreScaleChange());
                }
                else if (absDiff <= greatThreshold)
                {
                    TGM.PlusScore(50);
                    Fire(-10f);
                }
                else
                {
                    TGM.PlusScore(10);
                    Fire(-20f);
                }
            }
            else
            {
                if (absDiff <= underPerfectThreshold)
                {
                    TGM.PlusScore(100);
                    SM.CritSound();
                    critcount++;
                    isCrit = true;
                    Fire(4f);
                    StartCoroutine(scoreScaleChange());
                }
                else if (absDiff <= underGreatThreshold)
                {
                    TGM.PlusScore(50);
                    Fire(-10f);
                }
                else
                {
                    TGM.PlusScore(10);
                    Fire(-20f);
                }
            }

            bestNote.HitNote();
            killcount++;
            return true;
        }

        return false;
    }

    private IEnumerator WaitJudge()
    {
        canPress = false;

        // 판정 처리
        //Debug.Log("노트 판정됨!");

        yield return new WaitForSeconds(inputCooldown);
        canPress = true;
    }


    public void Fire(float crit)
    {
        // crit이 양수일 때는 항상 누적
        if (crit > 0)
        {
            fireCritCount += crit;
        }
        else if (crit < 0 )// && fireCritCount >= 100) // 100 미만일때 안떨어짐
        {
            // crit이 음수일 때는 fireCritCount가 30 이상일 때만 누적
            fireCritCount += crit;
        }

        fireCritCount = Mathf.Clamp(fireCritCount, 0, maxCrit);

        critSlider.maxValue = maxCrit;
        critSlider.value = fireCritCount;

        //Debug.Log("현재 Crit Count: " + fireCritCount);

        if (fireCritCount >= 100 && !isOver30)
        {
            isOver30 = true; // 30 이상 상태 진입

            SM.overDriveSound();
            GM.scoreMultiplier = 2f;

            x2Text.SetActive(true);

            foreach (var obj in objects)
            {
                var ps1 = obj.GetComponent<ParticleSystem>();
                if (ps1 != null)
                {
                    ps1.Play();
                }
                obj.SetActive(true);
            }
        }

        else if (fireCritCount < 100 && isOver30)
        {
            // 30 이상이던 상태에서 30 미만으로 떨어졌을 때만 초기화
            isOver30 = false;
            //fireCritCount = 0; 초기화
            GM.scoreMultiplier = 1f;

            critSlider.maxValue = maxCrit;
            critSlider.value = fireCritCount;

            x2Text.SetActive(false);

            foreach (var obj in objects)
            {
                var ps1 = obj.GetComponent<ParticleSystem>();
                if (ps1 != null)
                {
                    ps1.Stop(withChildren: false, ParticleSystemStopBehavior.StopEmitting);
                }
                obj.SetActive(false);
            }
        }
    }

    IEnumerator scoreScaleChange()
    {
        var scaleUp = scoreText.GetComponent<SmoothScaleUp>();
        var scaleDown = scoreText.GetComponent<SmoothScaleDown>();
        var fscaleUp = fireText.GetComponent<SmoothScaleUp>();
        var fscaleDown = fireText.GetComponent<SmoothScaleDown>();


        scaleUp.isScaleUp = true;
        fscaleUp.isScaleUp = true;
        yield return new WaitForSeconds(0.1f);
        scaleDown.isScaleDown = true;
        fscaleDown.isScaleDown = true;
        
    }
}
