using UnityEngine;

public class SmoothScaleDown : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(0.6f, 0.6f, 0.6f); // 직접 지정하는 목표 스케일
    public float speed = 0.5f;

    public bool isScaleDown = false;
    private void Update()
    {
        if (!isScaleDown)
            return;
        if (transform.localScale.x > targetScale.x)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, speed * Time.deltaTime);
        }
        else
        {
            isScaleDown = false;
        }
    }
}
