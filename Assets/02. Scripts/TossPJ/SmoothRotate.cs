using UnityEngine;

public class SmoothRotate : MonoBehaviour
{
    public bool rotateRight = true;      // 방향: true = 시계방향, false = 반시계방향
    public float initialSpeed = 720f;    // 초기 회전 속도 (도/초)
    public float deceleration = 360f;    // 감속 속도 (도/초^2)

    private float currentSpeed;
    private float rotatedAngle = 0f;
    private bool isRotating = true;

    public bool isStartrot = false;

    void Start()
    {
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        if (!isStartrot) return;
        if (!isRotating) return;

        float direction = rotateRight ? 1f : -1f;

        // 이번 프레임 회전 각도 = 현재 속도 * deltaTime
        float deltaAngle = currentSpeed * Time.deltaTime;

        // 회전 완료 체크 (이번 프레임 돌 각도 더하면 360 이상이면 남은 각도만 회전 후 종료)
        if (rotatedAngle + deltaAngle >= 360f)
        {
            float remain = 360f - rotatedAngle;
            transform.Rotate(0f, 0f, direction * remain);
            isRotating = false;
            isStartrot = false;
            return;
        }
        else
        {
            transform.Rotate(0f, 0f, direction * deltaAngle);
            rotatedAngle += deltaAngle;
        }

        // 감속 (속도 감소, 0 이하 되면 0으로 고정)
        currentSpeed -= deceleration * Time.deltaTime;
        if (currentSpeed < 0f)
            currentSpeed = 0f;
    }
}