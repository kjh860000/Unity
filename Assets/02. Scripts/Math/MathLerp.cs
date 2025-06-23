using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 targetPos;
    public float smoothValue;

    private Vector3 startPos;
    private float timer, percent, lerpTime;

    private void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        timer += Time.deltaTime;    // deltaTime: 시간조각
        timer = Time.time;     // 유니티 에디터 플레이 이후 누적시간
        percent = timer / lerpTime;

        transform.position = Vector3.Lerp(startPos, targetPos, smoothValue);
    }
}
