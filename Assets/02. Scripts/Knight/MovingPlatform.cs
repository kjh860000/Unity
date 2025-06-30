using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float theta;     //부드러운 이동
    public float power = 0.1f;  //이동거리
    public float speed = 1f;

    private Vector3 initPos;

    private void Start()
    {
        initPos = transform.position;
    }
    private void Update()
    {
        theta += Time.deltaTime * speed;
        transform.position = new Vector3(initPos.x + power * Mathf.Sin(theta), initPos.y, initPos.z);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
