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

        //transform �̵�
/*        transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;
        transform.position += Vector3.up * v * moveSpeed * Time.deltaTime;*/

        //rigidbody �̵�
        //carRb.linearVelocityX = h * moveSpeed * Time.deltaTime;
        //carRb.linearVelocityY = v * moveSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        carRb.linearVelocityX = h * moveSpeed;
        carRb.linearVelocityY = v * moveSpeed;

    }

    void OnCollisionEnter2D(Collision2D other) // �浹�� ���� 1�� ����
    {
        Debug.Log("Enter");
        //Debug.Log($"{other.gameObject.name} �浹");
        //other.gameObject.SetActive(false);
    }
    void OnCollisionStay2D(Collision2D other) // �浹 �� ��� ����
    {
        Debug.Log("Stay");
        //Debug.Log($"{other.gameObject.name} �浹");
        //other.gameObject.SetActive(false);
    }
    void OnCollisionExit2D(Collision2D other) // �浹 �� 1�� ����
    {
        Debug.Log("Exit");
        //Debug.Log($"{other.gameObject.name} �浹");
        //other.gameObject.SetActive(false);
    }



}
