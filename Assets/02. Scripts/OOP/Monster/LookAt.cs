using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class LookAt : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPos;

    public float fireDelay = 0.1f; // �߻� ����
    public float BulletPow = 50f;
    private bool canFire = true;

    void Update()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            StartCoroutine(Use());
        }

        Look();
    }

    IEnumerator Use()
    {
        canFire = false;

        GameObject bullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(shootPos.right * BulletPow, ForceMode2D.Impulse);

        yield return new WaitForSeconds(fireDelay); // ������ �� �߻� ����
        canFire = true;
    }

    public void Look()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mouseWorldPos - transform.position).normalized;
        direction.z = 0;

        // ���� �ٶ󺸴� ���� ���
        transform.right = direction;

        // �¿� ������: ���� �������� ���� x�� �������� ����
        Vector3 scale = transform.localScale;
        scale.y = Mathf.Abs(scale.y); // ���Ʒ��� �״��

        if (direction.x < 0)
            scale.y *= -1; // ���� ���� y ������ ������

        transform.localScale = scale;
    }
}
