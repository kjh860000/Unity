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

        //부드럽게 증감하는 값
        float h = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        //딱 떨어지는 값
/*        float h = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical");*/

        Vector3 dir = new Vector3 (h, 0, V);

        Vector3 normalDir = dir.normalized; // 정규화 과정 (0~1)

        //Debug.Log($"현재 입력 : {normalDir}");

        transform.position += normalDir * moveSpeed * Time.deltaTime;
        transform.LookAt(transform.position + normalDir);
    }
}
