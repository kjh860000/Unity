using UnityEngine;
using UnityEngine.UI;

public class KnightController_Joystick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    [SerializeField] private Button atkButton;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 10f;

    private bool isCombo;
    private bool isAttack;

    private float atkDamage = 3;
    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();

        atkButton.onClick.AddListener(Attack);
    }
    private void Update()   // 일반적인 작업
    {

    }

    private void FixedUpdate()  // 물리적인 작업(rigidbody 활용)
    {
        Move();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster"))
        {
            Debug.Log($"{atkDamage} 대미지");
        }
    }
    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3 (x, y, 0).normalized;

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);
    }

    void Move()
    {
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            knightRb.linearVelocity = inputDir * moveSpeed;
        }
    }


    void Attack()
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
