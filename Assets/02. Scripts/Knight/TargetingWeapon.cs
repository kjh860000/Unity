using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetingWeapon : MonoBehaviour
{
    private Transform target;
    public Transform Head;
    public Transform playerHand;

    public GameObject bulletPrefab;
    public Transform shootPos;
    public float BulletPow;

    private float timer;
    public float cooldownTime;

    void Start()
    {

    }

    void Update()
    {
        transform.position = playerHand.position;
        transform.rotation = playerHand.rotation;

        if (target == null) return;

        Vector2 dir = target.position - Head.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Head.localRotation = Quaternion.Euler(0, 0, angle);

        // �߻� ��Ÿ��
        timer += Time.deltaTime;
        if (timer > cooldownTime)
        {
            timer = 0f;
            Use();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            target = other.transform;
            Debug.Log("monster����");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Monster") && other.transform == target)
        {
            Debug.Log("monster ���� ���");
            target = null;
        }
    }
    void Use()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(shootPos.right * BulletPow, ForceMode2D.Impulse);
    }
}
