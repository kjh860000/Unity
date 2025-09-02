using UnityEngine;

public class SmoothScaleUp : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(0.8f, 0.8f, 0.8f); // 직접 지정하는 목표 스케일
    public float speed = 0.5f;

    public bool isScaleUp = false;
    private void Update()
    {
        if (!isScaleUp)
            return;
        if (transform.localScale.x < targetScale.x)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, speed * Time.deltaTime);
        }
        else
        {
            isScaleUp = false;
        }
    }
}
