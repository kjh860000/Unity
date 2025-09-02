using UnityEngine;
using System.Collections;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private TGameManager tGameManager;

    [SerializeField]
    private JudgeManager jManager;

    [SerializeField]
    private GameObject[] imageHP;
    private int currentHP;

    [SerializeField]
    public float invincibilityDuration;
    public bool isInvincibility = false;

    private SpriteRenderer spriteRenderer;
    private Color originColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = imageHP.Length;
        originColor = spriteRenderer.color;
    }

    public void TakeDamage()
    {
        if (isInvincibility) return;

        if (currentHP > 1)
        {
            StartCoroutine(nameof(OnInvincibility));
            currentHP--;
            imageHP[currentHP].SetActive(false);
        }
        else
        {
            tGameManager.GameOver();
            UnityEngine.Debug.Log("Die");
        }
    }

    private IEnumerator OnInvincibility()
    {
        isInvincibility = true;

        jManager.inputCooldown = 0;

        float elapsed = 0;
        float flashInterval = 0.1f; // 색상 변경 간격

        while (elapsed < invincibilityDuration)
        {
            // 반투명하게 만들기
            spriteRenderer.color = new Color(originColor.r, originColor.g, originColor.b, 0.25f);
            yield return new WaitForSeconds(flashInterval);
            // 원래 색상으로 복원
            spriteRenderer.color = originColor;
            yield return new WaitForSeconds(flashInterval);

            elapsed += flashInterval * 2;
        }

        spriteRenderer.color = originColor;

        jManager.inputCooldown = 0.3f;

        isInvincibility = false;
    }
}
