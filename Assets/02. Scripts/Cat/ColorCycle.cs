using UnityEngine;

public class ColorCycle : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float cycleSpeed = 1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * cycleSpeed, 1f); // 0~1 반복

        float g = Mathf.Lerp(1f, 0f, t); // G: 1→0→1
        float b = Mathf.Lerp(0f, 1f, t); // B: 0→1→0

        spriteRenderer.color = new Color(1f, g, b, 1f); // R=1, A=1 고정
    }
}
