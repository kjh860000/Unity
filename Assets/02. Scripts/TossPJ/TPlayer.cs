using UnityEngine;
using System.Collections;

public class TPlayer : MonoBehaviour
{
    [SerializeField] private JudgeManager JM;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private bool canAnim = true;
    void Awake()
    {
        if (JM == null)
        {
            JM = FindObjectOfType<JudgeManager>();
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //if (!JM.canPress) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && canAnim)
        {
            spriteRenderer.flipX = true;
            anim.SetTrigger("Attack");
            if (!JM.canPress)
            {
                StartCoroutine(WaitAnim());
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canAnim)
        {
            spriteRenderer.flipX = false;
            anim.SetTrigger("Attack");
            if (!JM.canPress)
            {
                StartCoroutine(WaitAnim());
            }
        }
    }
    public void OnLeftButton()
    {
        if (!canAnim) return;

        spriteRenderer.flipX = true;
        anim.SetTrigger("Attack");
        if (!JM.canPress)
        {
            StartCoroutine(WaitAnim());
        }
    }

    public void OnRightButton()
    {
        if (!canAnim) return;

        spriteRenderer.flipX = false;
        anim.SetTrigger("Attack");
        if (!JM.canPress)
        {
            StartCoroutine(WaitAnim());
        }
    }
    private IEnumerator WaitAnim()
    {
        canAnim = false;
        yield return new WaitForSeconds(JM.inputCooldown);
        canAnim = true;
    }
}
