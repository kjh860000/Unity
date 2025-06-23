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
        timer += Time.deltaTime;    // deltaTime: �ð�����
        timer = Time.time;     // ����Ƽ ������ �÷��� ���� �����ð�
        percent = timer / lerpTime;

        transform.position = Vector3.Lerp(startPos, targetPos, smoothValue);
    }
}
