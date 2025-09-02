using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    public bool isRight = true;
    public bool isStart = false;
    public float speed = 1f; // 이동 속도

    private Vector3 moveDir;
    private float moveTimer = 0f;

    void Start()
    {
        // 방향 설정
        moveDir = isRight ? Vector3.right : Vector3.left;
    }

    void Update()
    {
        if (isStart)
        {
            // 타이머 증가
            moveTimer += Time.deltaTime;

            // 이동
            transform.Translate(moveDir.normalized * speed * Time.deltaTime);

            // 1초가 지나면 종료
            if (moveTimer >= 1f)
            {
                isStart = false;
                moveTimer = 0f; // 다음에 다시 실행할 수 있도록 초기화
            }
        }
    }
}
