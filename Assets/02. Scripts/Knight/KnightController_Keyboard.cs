using UnityEngine;

public class KnightController_Keyboard : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 10f;

    private float atkDamage = 3;

    private bool isGround;
    private bool isCombo;
    private bool isAttack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
    }
    private void Update()   // 일반적인 작업
    {
        InputKeyboard();
        Jump();
        Attack();
    }

    private void FixedUpdate()  // 물리적인 작업(rigidbody 활용)
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", true);
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", false);
            isGround = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log($"{atkDamage} 대미지");
        }
    }
    void InputKeyboard()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        inputDir = new Vector3 (h, v, 0);

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);
    }
    void Move()
    {
        Vector2 velocity = knightRb.linearVelocity;

        if (inputDir.x != 0)
        {
            // 방향 반전
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            velocity.x = inputDir.x * moveSpeed;
        }
        else
        {
            // 키보드 입력 없으면 멈춤
            velocity.x = 0;
        }

        knightRb.linearVelocity = velocity;

        // 블렌드 트리 연동용 파라미터 설정 (필요 시)
        animator.SetFloat("Speed", Mathf.Abs(velocity.x));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isAttack)
            {
                isAttack = true;
                atkDamage = 3f;
                animator.SetTrigger("Attack");
            }
            else
            {
                isCombo = true;
                Debug.Log("combo 확인");
            }
        }
    }

    public void CheckCombo()
    {
        Debug.Log("combo");
        if (isCombo)
        {
            atkDamage = 5f;
            animator.SetBool("isCombo", true);
        }
        else
        {
            isAttack = false;
            animator.SetBool("isCombo", false);
        }
    }
    public void EndCombo()
    {
        isAttack = false;
        isCombo = false;
        animator.SetBool("isCombo", false);

    }
}
