using UnityEngine;

public class KnightController_Joystick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 10f;

    private bool isGround;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
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


    void Move()
    {
        knightRb.linearVelocityX = inputDir.x * moveSpeed;
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }

        /*        if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetTrigger("Jump");
                    knightRb.linearVelocity = Vector2.up * jumpPower;
                }*/
    }
    void SetAnimation()
    {
        if (inputDir.x != 0)
        {
            animator.SetBool("isRun", true);

            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
        else if (inputDir.x == 0)
        {
            animator.SetBool("isRun", false);
        }
    }
}
