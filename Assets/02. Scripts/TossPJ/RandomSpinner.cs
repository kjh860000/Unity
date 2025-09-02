using UnityEngine;

public class RandomSpinner2D : MonoBehaviour
{
    private float randomSpeed; // 회전 속도 (양수면 시계, 음수면 반시계)

    [SerializeField] private float minSpeed = 30f;  // 최소 속도 (deg/sec)
    [SerializeField] private float maxSpeed = 180f; // 최대 속도 (deg/sec)

    private void Start()
    {
        // 속도와 방향 랜덤 (-max ~ +max)
        float speed = Random.Range(minSpeed, maxSpeed);
        float direction = Random.value > 0.5f ? 1f : -1f; // 시계 or 반시계
        randomSpeed = speed * direction;
    }

    private void Update()
    {
        // Z축 기준 회전
        transform.Rotate(0f, 0f, randomSpeed * Time.deltaTime);
    }
}
