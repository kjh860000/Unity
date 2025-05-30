using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public static int coinCount = 0;
    void Start()
    {
    }

    void Update()
    {

/*        if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }*/

        //�ε巴�� �����ϴ� ��
        float h = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        //�� �������� ��
/*        float h = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical");*/

        Vector3 dir = new Vector3 (h, 0, V);

        Vector3 normalDir = dir.normalized; // ����ȭ ���� (0~1)

        //Debug.Log($"���� �Է� : {normalDir}");

        transform.position += normalDir * moveSpeed * Time.deltaTime;
        transform.LookAt(transform.position + normalDir);
    }
}
