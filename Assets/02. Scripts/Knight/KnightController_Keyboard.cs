using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class KnightController_Keyboard : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 10f;

    private float atkDamage = 3;

    private bool isGround;
    private bool isLadder;

    private bool isCombo;
    private bool isAttack;
    private bool isRolling;

    private bool isJumping;
    private float jumpTimer;
    public float maxJumpTime = 0.35f; // 최대 점프 유지 시간

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
        Roll();
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

        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
            knightRb.gravityScale = 0;
            knightRb.linearVelocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = false;
            knightRb.gravityScale = 10;
            knightRb.linearVelocity = Vector2.zero;
        }
    }
    void InputKeyboard()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        inputDir = new Vector3 (h, v, 0);

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);

/*        if(inputDir.y < 0)
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.68f, 0.23f);
        }
        else
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.68f, 1.17f);
        }*/
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
        else if(inputDir.x == 0 && !isRolling)
        {
            // 키보드 입력 없으면 멈춤
            velocity.x = 0;
        }

        knightRb.linearVelocity = velocity;

        // 블렌드 트리 연동용 파라미터 설정 (필요 시)
        animator.SetFloat("Speed", Mathf.Abs(velocity.x));

        if (isLadder && inputDir.y != 0)
        {
            knightRb.linearVelocityY = inputDir.y * moveSpeed;
        }
        else if(inputDir.y == 0 && isLadder)
        {
            knightRb.linearVelocityY = 0;
        }


        if (inputDir.y < 0)
        {
            moveSpeed = 5f;
        }
        else
        {
            moveSpeed = 10f;
        }
    }

    void Jump()
    {
        // 점프 시작
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isJumping = true;
            jumpTimer = maxJumpTime;
            knightRb.linearVelocity = new Vector2(knightRb.linearVelocity.x, jumpPower);
            animator.SetTrigger("Jump");
        }

        // 누르고 있는 동안 힘 유지
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimer > 0)
            {
                knightRb.linearVelocity = new Vector2(knightRb.linearVelocity.x, jumpPower);
                jumpTimer -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        // 점프 중지
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
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

    private void Roll()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)&&!isRolling)
        {
            StartCoroutine(RollRoutine());
        }
    }

    IEnumerator RollRoutine()
    {
        isRolling = true;
        var direction = transform.localScale.x > 0 ? 1 : -1;

        animator.SetTrigger("Roll");
        knightRb.AddForce(new Vector2(jumpPower * direction, 0));

        yield return new WaitForSeconds(0.45f);
        isRolling = false;
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
