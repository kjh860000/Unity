using UnityEngine;

public class Blink : MonoBehaviour
{
    public float blinkSpeed = 3f;  // 깜빡임 속도
    public float minAlpha = 0.5f;  // 최소 투명도
    public float maxAlpha = 1f;    // 최대 투명도

    private SpriteRenderer spriteRenderer;
    private Color originColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originColor = spriteRenderer.color;
    }

    private void Update()
    {
        // Mathf.PingPong으로 0~1 반복 → Lerp으로 알파값 변화
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.PingPong(Time.time * blinkSpeed, 1f));
        spriteRenderer.color = new Color(originColor.r, originColor.g, originColor.b, alpha);
    }
}
