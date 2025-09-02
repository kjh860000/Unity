using UnityEngine;
using System.Collections;

public class HeartBlink : MonoBehaviour
{
    [SerializeField]
    private float invincibilityDuration;
    private bool isInvincibility = false;

    private SpriteRenderer spriteRenderer;
    private Color originColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originColor = spriteRenderer.color;
    }

    public void BlinkObj()
    {
        OnInvincibility();
    }

    private IEnumerator OnInvincibility()
    {
        isInvincibility = true;

        float elapsed = 0;
        float flashInterval = 0.1f; // 색상 변경 간격

        while (elapsed < invincibilityDuration)
        {
            // 반투명하게 만들기
            spriteRenderer.color = new Color(originColor.r, originColor.g, originColor.b, 0.5f);
            yield return new WaitForSeconds(flashInterval);
            // 원래 색상으로 복원
            spriteRenderer.color = originColor;
            yield return new WaitForSeconds(flashInterval);

            elapsed += flashInterval * 2;
        }

        spriteRenderer.color = originColor;
        isInvincibility = false;
    }
}
