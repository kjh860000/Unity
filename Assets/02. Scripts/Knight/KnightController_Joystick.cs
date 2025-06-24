using UnityEngine;
using UnityEngine.UI;

public class KnightController_Joystick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    [SerializeField] private Button jumpButton;
    [SerializeField] private Button atkButton;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 10f;

    private bool isGround;
    private bool isCombo;
    private bool isAttack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();

        jumpButton.onClick.AddListener(Jump);
        atkButton.onClick.AddListener(Attack);
    }
    private void Update()   // 일반적인 작업
    {

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

    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3 (x, y, 0).normalized;

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);

        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }

    }

    void Move()
    {
        knightRb.linearVelocityX = inputDir.x * moveSpeed;
    }
    void Jump()
    {
        if (isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    void Attack()
    {
        if (!isAttack)
        {
            isAttack = true;
            animator.SetTrigger("Attack");
        }
        else
        {
            isCombo = true;
            Debug.Log("combo 확인");
        }
    }

    public void CheckCombo()
    {
        Debug.Log("combo");
        if (isCombo)
        {
            animator.SetBool("isCombo", true);
        }
        else
        {
            animator.SetBool("isCombo", false);
            isAttack = false;
        }
    }
    public void EndCombo()
    {
        isAttack = false;
        isCombo = false;
    }
}
