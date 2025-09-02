using UnityEngine;
using System.Collections;

public class EffectSpawner : MonoBehaviour
{
    [SerializeField] public float spawnTimer = 0.1f;
    [SerializeField] public GameObject effect;
    [SerializeField] private NoteSoundManager NoteSM;


    private void OnEnable()
    {
        StartCoroutine(SpawnStart());
        NoteSM.IntroBombSound();
    }

    public IEnumerator SpawnStart()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
