using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class LookAt : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPos;

    public float fireDelay = 0.1f; // 발사 간격
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

        yield return new WaitForSeconds(fireDelay); // 딜레이 후 발사 가능
        canFire = true;
    }

    public void Look()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mouseWorldPos - transform.position).normalized;
        direction.z = 0;

        // 총이 바라보는 방향 계산
        transform.right = direction;

        // 좌우 뒤집기: 총이 오른쪽을 보면 x축 스케일을 반전
        Vector3 scale = transform.localScale;
        scale.y = Mathf.Abs(scale.y); // 위아래는 그대로

        if (direction.x < 0)
            scale.y *= -1; // 왼쪽 보면 y 스케일 뒤집기

        transform.localScale = scale;
    }
}
