using UnityEngine;
using System.Collections;

public class LightningSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] flashEffects;
    [SerializeField] private GameObject thunder;

    [SerializeField] private float minDelay = 0.5f;  // 최소 딜레이
    [SerializeField] private float maxDelay = 1.0f;  // 최대 딜레이


    private void OnEnable()
    {
        StartCoroutine(SpawnAllLightningRoutine());
    }

    private IEnumerator SpawnAllLightningRoutine()
    {
        while (gameObject.activeSelf)  // 게임 오브젝트가 활성화된 동안 반복
        {
            // 랜덤 딜레이
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // flashEffects 모두 isFlashing = true
            foreach (var obj in flashEffects)
            {
                var flash = obj.GetComponent<LightningFlash>();
                if (flash != null)
                {
                    flash.isFlashing = true;
                    UnityEngine.Debug.Log("isFlashing true");
                }
            }

            var ps = thunder.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }
            //thunder.SetActive(true);
        }
    }
    private void OnDisable()
    {
        var ps = thunder.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            // 파티클 생성 중지, 이미 생성된 파티클은 남김
            ps.Stop(withChildren: false, ParticleSystemStopBehavior.StopEmitting);
        }
        else
        {
        // 만약 파티클 컴포넌트 없으면 그냥 비활성화 (예외 처리)
            //thunder.SetActive(false);
        }
    }
}
        
