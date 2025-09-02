using UnityEngine;

public class Pattern6 : MonoBehaviour
{
    [SerializeField] private NoteSpawner noteSpawner;

    [SerializeField] private GameObject spawnPosL;
    [SerializeField] private GameObject spawnPosR;

    [SerializeField] private GameObject bgObjects;
    [SerializeField] private GameObject[] objects;


    public float randomY_L { get; private set; }
    public float randomY_R { get; private set; }

    public float randomY;
    private void Update()
    {
        PatternOff();
    }
    private void OnEnable()
    {
        foreach (var obj in objects)
        {
            var ps1 = obj.GetComponent<ParticleSystem>();
            if (ps1 != null)
            {
                ps1.Play();
            }
            obj.SetActive(true);
        }

        var fade = bgObjects.GetComponent<BoolFadeInOut>();
        if (fade != null)
        {
            fade.isStart = true;
            fade.isFadeIn = true;
            fade.StartFade(true);
        }
        
        noteSpawner.startStorm = true;
        noteSpawner.gameObject.SetActive(true);
    }
    public float GetRandomY(int spawnIndex)
    {
        randomY = Random.Range(0f, 2.5f);

        Vector3 pos = (spawnIndex == 0) ? spawnPosL.transform.position : spawnPosR.transform.position;
        pos.y = randomY;

        if (spawnIndex == 0)
            spawnPosL.transform.position = pos;
        else
            spawnPosR.transform.position = pos;

        return randomY;
    }
    public void UpdateRandomY()
    {
        randomY_L = Random.Range(0f, 2.5f);
        randomY_R = Random.Range(0f, 2.5f);

        spawnPosL.transform.position = new Vector3(-4f, randomY_L, 0f);
        spawnPosR.transform.position = new Vector3(4f, randomY_R, 0f);
    }

    public void GetRandomJumpFallY()
    {
        Note noteScript = FindObjectOfType<Note>();
        TMonster monsterScript = FindObjectOfType<TMonster>();


        if (noteScript != null)
        {
            noteScript.jumpHeight = (randomY + 1f) * 2f;
            noteScript.judgeGracePeriod = (2.5f / (randomY + 1f)) * 0.3f;
        }

        if (monsterScript != null)
        {
            monsterScript.fallSpeed = (randomY + 1f) * 2.4f;
        }
    }

    void PatternOff()
    {
        if (!noteSpawner.startSpawn)
        {
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

            var fade = bgObjects.GetComponent<BoolFadeInOut>();
            if (fade != null)
            {
                fade.isFadeIn = false;
                fade.StartFade(false);
            }

            noteSpawner.startStorm = false;
            spawnPosL.transform.position = new Vector3(-4f, 2.5f, 0f);
            spawnPosR.transform.position = new Vector3(4f, 2.5f, 0f);

            gameObject.SetActive(false);
            //noteSpawner.speedMultiplier = 1f;
        }
    }
}
