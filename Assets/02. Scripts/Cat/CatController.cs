using UnityEngine;

public class CatController : MonoBehaviour
{
    Rigidbody2D CatRb;
    public float JumpPower = 10;
    public bool isGround = false;

    public int jumpCount = 0;

    void Start()
    {
        CatRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2) 
        {
            CatRb.AddForceY(JumpPower, ForceMode2D.Impulse); // ForceMode2D.Impulse : 순간적으로 힘을 가하는 방식
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
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
