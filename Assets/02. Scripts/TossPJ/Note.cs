using UnityEngine;

public class Note : MonoBehaviour
{
    public enum Lane { Left, Right }

    public Lane lane;

    private NoteSoundManager NoteSM;
    private PlayerHP PHP;
    private JudgeManager jM;

    private Vector3 spawnPos;
    private Vector3 judgeLinePos;
    private float fallDuration;
    private float spawnTime;
    public float targetTime;
    private bool isMissed = false;
    public bool IsMissed => isMissed; // isMissed는 private bool 필드

    [SerializeField] public float jumpHeight = 1f;
    [SerializeField] private float missFallSpeed = 5f;

    // 저지라인 도달 후 판정 가능 시간(초)
    [SerializeField] public float judgeGracePeriod = 0.3f;

    private float judgeLineReachTime = -1f; // 저지라인 도달 시각 기록

    void Awake()
    {
        NoteSM = FindObjectOfType<NoteSoundManager>();
        PHP = FindObjectOfType<PlayerHP>();
        jM = FindObjectOfType<JudgeManager>();

        if (NoteSM == null)
            UnityEngine.Debug.LogError("씬에 NoteSoundManager가 존재하지 않습니다!");
    }

    public void Init(Vector3 _spawnPos, Vector3 _judgeLinePos, float _fallDuration, float _targetTime, Lane _lane)
    {
        spawnPos = _spawnPos;
        judgeLinePos = _judgeLinePos;
        fallDuration = _fallDuration;
        targetTime = _targetTime;
        lane = _lane;

        spawnTime = Time.time;
        transform.position = spawnPos;

        JudgeManager tGameManager = FindObjectOfType<JudgeManager>();
        if (tGameManager != null)
            tGameManager.RegisterNote(this);
    }

    void Update()
    {
        if (!isMissed)
        {
            float elapsed = Time.time - spawnTime;
            float t = elapsed / fallDuration;

            if (t < 1f)
            {
                // 낙하 중
                t = Mathf.Clamp01(t);

                float yOffset = Mathf.Sin(t * Mathf.PI) * jumpHeight;

                Vector3 pos = Vector3.Lerp(spawnPos, judgeLinePos, t);
                pos.y += yOffset;

                transform.position = pos;
            }
            else
            {
                // 저지라인 도달 후 판정 유예 시간 동안 아래로 바로 떨어짐 시작
                if (judgeLineReachTime < 0f)
                    judgeLineReachTime = Time.time;

                float timeSinceJudgeLine = Time.time - judgeLineReachTime;


                if (timeSinceJudgeLine > judgeGracePeriod)
                {

                    MissNote();
                }

                if (CompareTag("Bomb"))
                    transform.position += Vector3.down * missFallSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (CompareTag("Bomb"))
            {
                // Miss 상태인 경우 계속 아래로 떨어짐
                transform.position += Vector3.down * missFallSpeed * Time.deltaTime;
            }

            if (transform.position.y < -10f)
            {
                Destroy(gameObject);
            }
        }
    }
    public float GetTargetTime() => targetTime;

    public void HitNote()
    {
        if(gameObject.CompareTag("Note"))
        {
            NoteSM.HitSound();
            switch (lane)
            {
                case Lane.Left:
                    NoteSM.HitLeftSound();
                    //Debug.Log("case left");
                    break;
                case Lane.Right:
                    NoteSM.HitRightSound();
                    //Debug.Log("case right");
                    break;
            }
        }    
        FindObjectOfType<JudgeManager>()?.UnregisterNote(this);
        Destroy(gameObject);
    }

    public void MissNote()
    {
        if (isMissed) return;

        isMissed = true;
        FindObjectOfType<JudgeManager>()?.UnregisterNote(this);

        if (this.CompareTag("Note"))
        {
            PHP.TakeDamage();
            NoteSM.EnemyAttackSound();
            jM.Fire(-50f);

            //Debug.Log("Drop Miss");
        }
    }

    public void NoteSound()
    {
        NoteSM.HitSound();
        switch (lane)
        {
            case Lane.Left:
                NoteSM.PlayLeftSound();
                //Debug.Log("case left");
                break;
            case Lane.Right:
                NoteSM.PlayRightSound();
                //Debug.Log("case right");
                break;
        }
    }
}
