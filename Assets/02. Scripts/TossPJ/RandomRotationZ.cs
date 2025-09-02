using UnityEngine;

public class RandomRotationZ : MonoBehaviour
{
    void Start()
    {
        // 0 ~ 360도 사이에서 랜덤 각도 생성
        float randomZ = Random.Range(0f, 360f);

        // 기존 X,Y 각도 유지하면서 Z축 각도만 랜덤 설정
        Vector3 currentEuler = transform.eulerAngles;
        currentEuler.z = randomZ;
        transform.eulerAngles = currentEuler;
    }
}
