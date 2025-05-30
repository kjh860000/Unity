using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRb;
    public SpriteRenderer[] renderers;

    public GameObject[] renderObj;

    public float moveSpeed;
    public float jumpPower;
    public int jumpCount = 0;
    private float h;

    private bool isGround;

    private void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();
        renderers = GetComponentsInChildren<SpriteRenderer>(true);
    }
    private void Update()
    {
        h = Input.GetAxis("Horizontal");

        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        renderers[2].gameObject.SetActive(false); // jump
        jumpCount = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;

        renderers[0].gameObject.SetActive(false); // idle
        renderers[1].gameObject.SetActive(false); // run
        renderers[2].gameObject.SetActive(true); // jump

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            characterRb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);

            renderers[2].gameObject.SetActive(true); // jump
            jumpCount++;
        }
    }
    void Move()
    {


        if (h != 0) // 움직일때
        {
            characterRb.linearVelocityX = h * moveSpeed;

            if (h > 0) // 오른쪽
            {
                renderers[0].flipX = false;
                renderers[1].flipX = false;
                renderers[2].flipX = false;
            }
            else if (h < 0) // 왼쪽
            {
                renderers[0].flipX = true;
                renderers[1].flipX = true;
                renderers[2].flipX = true;
            }

            if (isGround)
            {
                renderers[0].gameObject.SetActive(false); // idle
                renderers[1].gameObject.SetActive(true); // run
                renderers[2].gameObject.SetActive(false); // jump
            }
            else if(!isGround)
            {
                renderers[0].gameObject.SetActive(false); // idle
                renderers[1].gameObject.SetActive(false); // run
                renderers[2].gameObject.SetActive(true); // jump
            }

        }
        else if (h == 0) // 안움직일때
        {
            if (isGround)
            {
                renderers[0].gameObject.SetActive(true); // idle
                renderers[1].gameObject.SetActive(false); // run
                renderers[2].gameObject.SetActive(false); // jump
            }
            else if (!isGround)
            {
                renderers[0].gameObject.SetActive(false); // idle
                renderers[1].gameObject.SetActive(false); // run
                renderers[2].gameObject.SetActive(true); // jump
            }
        }
    }
}
