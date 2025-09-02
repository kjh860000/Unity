using UnityEngine;

public class LightningFlash : MonoBehaviour
{
    public float flashDuration = 0.5f;
    public float maxAlpha = 0.8f;

    private SpriteRenderer spriteRenderer;
    private float timer = 0f;
    private bool _isFlashing = false;
    public bool isFlashing
    {
        get => _isFlashing;
        set
        {
            if (value && !_isFlashing)
            {
                timer = 0f; // 타이머 초기화
            }
            _isFlashing = value;
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            UnityEngine.Debug.LogWarning("LightningFlash: SpriteRenderer가 없습니다.");
        }
    }

    private void Update()
    {
        if (!_isFlashing) return;

        timer += Time.deltaTime;

        float alpha = Mathf.Lerp(maxAlpha, 0f, timer / flashDuration);
        SetAlpha(alpha);

        if (timer >= flashDuration)
        {
            SetAlpha(0f);
            _isFlashing = false;
        }
    }

    private void SetAlpha(float alpha)
    {
        if (spriteRenderer != null)
        {
            var c = spriteRenderer.color;
            c.a = alpha;
            spriteRenderer.color = c;
        }
    }
}
