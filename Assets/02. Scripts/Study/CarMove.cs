using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D carRb;

    private float h;
    private float v;

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //transform 이동
/*        transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;
        transform.position += Vector3.up * v * moveSpeed * Time.deltaTime;*/

        //rigidbody 이동
        //carRb.linearVelocityX = h * moveSpeed * Time.deltaTime;
        //carRb.linearVelocityY = v * moveSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        carRb.linearVelocityX = h * moveSpeed;
        carRb.linearVelocityY = v * moveSpeed;

    }

    void OnCollisionEnter2D(Collision2D other) // 충돌한 순간 1번 실행
    {
        Debug.Log("Enter");
        //Debug.Log($"{other.gameObject.name} 충돌");
        //other.gameObject.SetActive(false);
    }
    void OnCollisionStay2D(Collision2D other) // 충돌 중 계속 실행
    {
        Debug.Log("Stay");
        //Debug.Log($"{other.gameObject.name} 충돌");
        //other.gameObject.SetActive(false);
    }
    void OnCollisionExit2D(Collision2D other) // 충돌 후 1번 실행
    {
        Debug.Log("Exit");
        //Debug.Log($"{other.gameObject.name} 충돌");
        //other.gameObject.SetActive(false);
    }



}
