using UnityEngine;
using Cat;
public class CatController : MonoBehaviour
{
    public SoundManager soundManager;

    Rigidbody2D CatRb;
    public float JumpPower = 10;
    public bool isGround = false;

    public int jumpCount = 0;
    Animator catAnim;

    void Start()
    {
        CatRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("isGround", false);
            CatRb.AddForceY(JumpPower, ForceMode2D.Impulse);
            jumpCount++; // 1¾¿ Áõ°¡

            soundManager.OnJumpSound();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}